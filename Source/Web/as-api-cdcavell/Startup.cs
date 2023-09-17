using as_api_cdcavell.Authorization;
using as_api_cdcavell.Data;
using as_api_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Commons.Logging;
using CDCavell.ClassLibrary.Web.Mvc.Filters;
using CDCavell.ClassLibrary.Web.Security;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace as_api_cdcavell
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
    /// | Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Service |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |~ 
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

            // Register DBContext
            services.AddDbContext<AuthorizationServiceDbContext>(options =>
                options.UseSqlite(
                    _appSettings.ConnectionStrings.AuthorizationConnection,
                    x => x.MigrationsAssembly("as-api-cdcavell")
                ));

            // Register IHttpContextAccessor
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register controller fillters
            services.AddScoped<ControllerActionLogFilter>();

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
             
            services.AddControllers();

            // Register Application Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Read", policy =>
                {
                    policy.Requirements.Add(new ReadRequirement(true));
                });
                options.AddPolicy("Write", policy =>
                {
                    policy.Requirements.Add(new WriteRequirement(true));
                });
            });

            // Registered authorization handlers
            services.AddTransient<IAuthorizationHandler, ReadHandler>();
            services.AddTransient<IAuthorizationHandler, WriteHandler>();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = _appSettings.Authentication.IdP.Authority;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = tokenContext =>
                        {
                            try
                            {
                                var receivedClaims = tokenContext.Principal.Claims;
                                var exceptedClaims = new List<Claim>();

                                Claim readClaim = tokenContext.Principal.Claims
                                    .Where(x => x.Type == "scope")
                                    .Where(x => x.Value == "Authorization.Service.API.Read")
                                    .FirstOrDefault();

                                if (readClaim != null)
                                    exceptedClaims.Add(new Claim("scope", readClaim.Value.Clean()));

                                Claim writeClaim = tokenContext.Principal.Claims
                                    .Where(x => x.Type == "scope")
                                    .Where(x => x.Value == "Authorization.Service.API.Write")
                                    .FirstOrDefault();

                                if (writeClaim != null)
                                    exceptedClaims.Add(new Claim("scope", writeClaim.Value.Clean()));

                                tokenContext.Principal.AddIdentity(new ClaimsIdentity(exceptedClaims));
                                tokenContext.Success();
                            }
                            catch (Exception exception)
                            {
                                _logger.Exception(exception);
                                tokenContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                tokenContext.Response.Redirect("/Home/Error/500");
                                tokenContext.Fail(exception);
                            }

                            return Task.FromResult(tokenContext.Result);
                        }
                    };
                });
        }

        /// <summary>
        /// This required method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IWebHostEnvironment</param>
        /// <param name="logger">ILogger&lt;Startup&gt;</param>
        /// <param name="lifetime">IHostApplicationLifetime</param>
        /// <param name="dbContext">AuthorizationServiceDbContext</param>
        /// <method>Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger&lt;Startup&gt; logger, IHostApplicationLifetime lifetime, AuthorizationServiceDbContext dbContext)</method>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, IHostApplicationLifetime lifetime, AuthorizationServiceDbContext dbContext)
        {
            _logger = new Logger(logger);
            _logger.Trace($"Configure(IApplicationBuilder: {app}, IWebHostEnvironment: {env}, ILogger<Startup> {logger}, IHostApplicationLifetime: {lifetime})");

            AESGCM.Seed(_appSettings.SecretKey);
            DbInitializer.Initialize(dbContext, _appSettings.SiteAdministrator);

            lifetime.ApplicationStarted.Register(OnAppStarted);
            lifetime.ApplicationStopping.Register(OnAppStopping);
            lifetime.ApplicationStopped.Register(OnAppStopped);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.EnvironmentName.Equals("Production"))
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
