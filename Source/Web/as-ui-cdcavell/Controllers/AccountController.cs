using as_ui_cdcavell.Models.Account;
using as_ui_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Http;
using CDCavell.ClassLibrary.Web.Identity.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace as_ui_cdcavell.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.3.0 | 02/04/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |~ 
    /// | Christopher D. Cavell | 1.0.3.1 | 02/08/2021 | User Authorization Web Service |~ 
    /// | Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.2.0 | 07/08/2021 | SignalR streaming |~ 
    /// | Christopher D. Cavell | 1.1.2.0 | 07/21/2021 | Migrate to AWS Lightsail |~ 
    /// </revision>
    public class AccountController : ApplicationBaseController<AccountController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;AccountController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="userManager">CustomUserManager</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="roleManager">CustomRoleManager</param>
        /// <method>
        /// AccountController(
        ///     ILogger&lt;AccountController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings,
        ///     CustomUserManager userManager,
        ///     CustomRoleManager roleManager
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        /// </method>
        public AccountController(
            ILogger<AccountController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings,
            CustomUserManager userManager,
            CustomRoleManager roleManager
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        {
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <method>Login()</method>
        [HttpGet]
        public IActionResult Login()
        {
            string url = _appSettings.Authorization.AuthorizationService.MainTrim;
            url += "/Home/Login";
            return Redirect(url);
        }

        /// <summary>
        /// Validate returned captcha token
        /// </summary>
        /// <param name="captchaToken">string</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>ValidateCaptchaToken(string captchaToken)</method>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateCaptchaToken(string captchaToken)
        {
            if (ModelState.IsValid)
            {
                string request = "siteverify";
                request += "?secret=" + _appSettings.Authentication.reCAPTCHA.SecretKey;
                request += "&response=" + captchaToken.Trim().Clean();
                request += "&remoteip=" + _httpContextAccessor.HttpContext.GetRemoteAddress().MapToIPv4().ToString();

                JsonClient client = new JsonClient(" https://www.google.com/recaptcha/api/");
                HttpStatusCode statusCode = await client.SendRequest(HttpMethod.Post, request, string.Empty);
                if (client.IsResponseSuccess)
                {
                    CaptchaResponse response = client.GetResponseObject<CaptchaResponse>();
                    if (response.success)
                        if (response.action.Equals("submit", StringComparison.OrdinalIgnoreCase))
                            if (response.score > 0.6)
                                return Ok(client.GetResponseString());
                }

                return BadRequest(client.GetResponseString());
            }

            return BadRequest("Invalid request");
        }

        /// <summary>
        /// Logout method
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Logout()</method>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            DiscoveryCache discoveryCache = (DiscoveryCache)HttpContext
                .RequestServices.GetService(typeof(IDiscoveryCache));
            DiscoveryDocumentResponse discovery = await discoveryCache.GetAsync();
            if (!discovery.IsError)
                return Redirect(discovery.EndSessionEndpoint);
            else
                _logger.Warning(discovery.Error);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync("oidc");

            foreach (var cookie in Request.Cookies)
                Response.Cookies.Delete(cookie.Key);

            string url = _appSettings.Authorization.AuthorizationService.MainTrim;
            url += "/Home/Index";
            return Redirect(url);
        }

        /// <summary>
        /// Front Channel SLO Logout method
        /// &lt;br /&gt;&lt;br /&gt;
        /// https://andersonnjen.com/2019/03/22/identityserver4-global-logout/
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>FrontChannelLogout(string sid)</method>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> FrontChannelLogout(string sid)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentSid = User.FindFirst("sid")?.Value ?? "";
                if (string.Equals(currentSid, sid, StringComparison.Ordinal))
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignOutAsync("oidc");
                }
            }

            foreach (var cookie in Request.Cookies)
                Response.Cookies.Delete(cookie.Key);

            return NoContent();
        }
    }
}
