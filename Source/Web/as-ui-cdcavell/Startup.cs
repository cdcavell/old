using as_ui_cdcavell.Filters;
using as_ui_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Commons.Logging;
using CDCavell.ClassLibrary.Web.Identity.Extensions;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Identity.Services;
using CDCavell.ClassLibrary.Web.Mvc.Filters;
using CDCavell.ClassLibrary.Web.Security;
using CDCavell.ClassLibrary.Web.Services.AppSettings;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace as_ui_cdcavell
{
    /// <summary>
    /// The Startup class configures services and the application's request pipeline&lt;br /&gt;&lt;br /&gt;
    /// _Services_ are components that are used by the app. For example, a logging component is a service. Code to configure (_or register_) services is added to the ```Startup.ConfigureServices``` method.&lt;br /&gt;&lt;br /&gt;
    /// The request handling pipeline is composed as a series of _middleware_ components. For example, a middleware might handle requests for static files or redirect HTTP requests to HTTPS. Each middleware performs asynchronous operations on an ```HttpContext``` and then either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is added to the ```Startup.Configure``` method.
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.3.0 | 02/06/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |~
    /// | Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Web Service |~ 
    /// | Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.2.0 | 07/08/2021 | SignalR streaming |~ 
    /// | Christopher D. Cavell | 1.1.2.0 | 07/21/2021 | Migrate to AWS Lightsail |~ 
    /// </revision>
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private Logger _logger;
        private AppSettings _appSettings;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <method>Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)</method>
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// This optional method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <method>ConfigureServices(IServiceCollection services)</method>
        public void ConfigureServices(IServiceCollection services)
        {
            // Register appsettings.json
            AppSettings appSettings = new AppSettings();
            _configuration.Bind("AppSettings", appSettings);
            _appSettings = appSettings;
            services.AddSingleton(_appSettings);

            // cache authority discovery and add to DI
            services.AddHttpClient();
            services.AddSingleton<IDiscoveryCache>(options =>
            {
                var factory = options.GetRequiredService<IHttpClientFactory>();
                return new DiscoveryCache(_appSettings.Authentication.IdP.Authority, () => factory.CreateClient());
            });

            // Register IHttpContextAccessor
            services.AddHttpContextAccessor();

            // Register controller fillters
            services.AddScoped<SecurityHeadersAttribute>();
            services.AddScoped<ControllerActionLogFilter>();
            services.AddScoped<ControllerActionUserFilter>();
            services.AddScoped<ControllerActionPageFilter>();

            // Register Web Services
            services.AddAppSettingsService(options =>
            {
                options.AppSettings = _appSettings;
            });

            services.AddCustomUserStore(options =>
            {
                options.ISDBaseUrl = _appSettings.Authentication.IdP.Authority;
                options.ApiBaseUrl = _appSettings.Authorization.AuthorizationService.ApiTrim;
                options.ApiAccessToken = string.Empty;
            });

            services.AddCustomRoleStore(options =>
            {
                options.ISDBaseUrl = _appSettings.Authentication.IdP.Authority;
                options.ApiBaseUrl = _appSettings.Authorization.AuthorizationService.ApiTrim;
                options.ApiAccessToken = string.Empty;
            });

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddUserStore<CustomUserStore>()
                .AddRoleStore<CustomRoleStore>()
                .AddUserManager<CustomUserManager>()
                .AddRoleManager<CustomRoleManager>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, cookieOptions => {
                    cookieOptions.Events.OnRedirectToAccessDenied = context =>
                    {
                        context.Response.StatusCode = (int)(HttpStatusCode.Unauthorized);
                        return Task.CompletedTask;
                    };
                    cookieOptions.Events.OnSigningOut = context =>
                    {
                        context.CookieOptions.Expires = DateTime.Now.AddDays(-1);
                        return Task.CompletedTask;
                    };
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    options.Authority = appSettings.Authentication.IdP.Authority;
                    options.RequireHttpsMetadata = true;

                    options.ClientId = appSettings.Authentication.IdP.ClientId;
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    options.ResponseMode = "form_post";

                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("email");
                    options.Scope.Add("Authorization.Service.API.Read");
                    options.Scope.Add("Authorization.Service.API.Write");
                    options.SaveTokens = true;

                    options.Events = new OpenIdConnectEvents
                    {
                        OnTicketReceived = ticketReceivedContext =>
                        {
                            try
                            {
                                OpenIdConnectOptions connectOptions = (OpenIdConnectOptions)ticketReceivedContext.Options;

                                List<Claim> additionalClaims = new List<Claim>();
                                var clientId = connectOptions.ClientId.TrimEnd(".DEV");
                                if (!string.IsNullOrEmpty(clientId))
                                    additionalClaims.Add(new Claim("client_id", clientId));

                                var accessToken = ticketReceivedContext.Properties.Items[".Token.access_token"];
                                if (!string.IsNullOrEmpty(accessToken))
                                    additionalClaims.Add(new Claim("access_token", accessToken));

                                ticketReceivedContext.Principal.AddIdentity(new ClaimsIdentity(additionalClaims));
                            }
                            catch (Exception exception)
                            {
                                _logger.Exception(exception);
                                ticketReceivedContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                ticketReceivedContext.HandleResponse();
                            }

                            return Task.FromResult(ticketReceivedContext.Result);
                        }
                    };
                });

            if (_webHostEnvironment.EnvironmentName.Equals("Production"))
            {
                services.AddHsts(options =>
                {
                    options.Preload = true;
                    options.IncludeSubDomains = true;
                    options.MaxAge = TimeSpan.FromDays(730);
                });

                services.AddHttpsRedirection(options =>
                {
                    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                    options.HttpsPort = 443;
                });
            }

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
                options.ConsentCookie.Expiration = TimeSpan.FromDays(30);

                if (_webHostEnvironment.EnvironmentName.Equals("Production"))
                    options.ConsentCookie.Domain = "cdcavell.name";
            });

            services.AddMvc();
            services.AddControllersWithViews();
        }

        /// <summary>
        /// This required method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IWebHostEnvironment</param>
        /// <param name="logger">ILogger&lt;Startup&gt;</param>
        /// <param name="lifetime">IHostApplicationLifetime</param>
        /// <method>Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger&lt;Startup&gt; logger, IHostApplicationLifetime lifetime)</method>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, IHostApplicationLifetime lifetime)
        {
            _logger = new Logger(logger);
            _logger.Trace($"Configure(IApplicationBuilder: {app}, IWebHostEnvironment: {env}, ILogger<Startup> {logger}, IHostApplicationLifetime: {lifetime})");

            AESGCM.Seed(_appSettings.SecretKey);

            lifetime.ApplicationStarted.Register(OnAppStarted);
            lifetime.ApplicationStopping.Register(OnAppStopping);
            lifetime.ApplicationStopped.Register(OnAppStopped);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseExceptionHandler("/Home/Error/500");
            app.UseStatusCodePagesWithRedirects("~/Home/Error/{0}");

            if (env.EnvironmentName.Equals("Production"))
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24 * 365;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        /// <summary>
        /// Exposed IApplicationLifetime interface method.
        /// </summary>
        /// <method>OnAppStarted()</method>
        public void OnAppStarted()
        {
            _logger.Information($"{Assembly.GetEntryAssembly().GetName().Name} Application Started");
            _logger.Information($"Hosting Environment: {_webHostEnvironment.EnvironmentName}");
        }

        /// <summary>
        /// Exposed IApplicationLifetime interface method.
        /// </summary>
        /// <method>OnAppStopping()</method>
        public void OnAppStopping()
        {
            _logger.Information($"{Assembly.GetEntryAssembly().GetName().Name} Application Shutdown");
        }

        /// <summary>
        /// Exposed IApplicationLifetime interface method.
        /// </summary>
        /// <method>OnAppStopped()</method>
        public void OnAppStopped()
        {
            _logger.Information($"{Assembly.GetEntryAssembly().GetName().Name} Application Ended");
        }
    }
}
