using cdcavell.Models.Account;
using cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Http;
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

namespace cdcavell.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.0.0 | 10/19/2020 | Initial build |~ 
    /// | Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |~ 
    /// | Christopher D. Cavell | 1.0.0.9 | 11/12/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |~ 
    /// | Christopher D. Cavell | 1.0.3.0 | 02/04/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache |~ 
    /// | Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | User Authorization Web Service |~ 
    /// | Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |~ 
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
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// AccountController(
        ///     ILogger&lt;AccountController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        /// </method>
        public AccountController(
            ILogger<AccountController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        {
        }

        /// <summary>
        /// Index method
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <method>Index()</method>
        [HttpGet]
        public IActionResult Index()
        {
            string url = _appSettings.Authorization.AuthorizationService.UiTrim;
            url += "/Registration/Status";
            return Redirect(url);
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <method>Login()</method>
        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Account");
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
