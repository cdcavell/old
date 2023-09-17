using CDCavell.ClassLibrary.Commons;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Services.Email;
using dis5_cdcavell.Models.AppSettings;
using dis5_cdcavell.Models.TwoFactor;
using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dis5_cdcavell.Controllers
{
    /// <summary>
    /// Two-Factor Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [AllowAnonymous]
    public class TwoFactorController : ApplicationBaseController<TwoFactorController>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;

        private IEmailService _emailService;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;TwoFactorController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="userManager">UserManager&lt;ApplicationUser&gt;</param>
        /// <param name="signInManager">SignInManager&lt;ApplicationUser&gt;</param>
        /// <param name="interaction">IIdentityServerInteractionService</param>
        /// <param name="events">IEventService</param>
        /// <param name="emailService">EmailService</param>
        /// <method>
        /// TwoFactorController(
        ///     ILogger&lt;TwoFactorController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor
        ///     AppSettings appSettings,
        ///     UserManager&lt;ApplicationUser&gt; userManager,
        ///     SignInManager&lt;ApplicationUser&gt; signInManager,
        ///     IIdentityServerInteractionService interaction,
        ///     IEventService events,
        ///     IEmailService emailService
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        /// </method>
        public TwoFactorController(
            ILogger<TwoFactorController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IEventService events,
            IEmailService emailService
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _events = events;
            _emailService = emailService;
        }

        /// <summary>
        /// TwoFactor Authentication Configuration
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Configuration()</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Configuration()
        {
            if (!Request.Form.ContainsKey("Email"))
                return Unauthorized();

            var email = Request.Form
                .Where(x => x.Key == "Email")
                .Select(x => x.Value)
                .FirstOrDefault()
                .ToString()
                .Clean();

            if (string.IsNullOrEmpty(email))
                return Unauthorized();

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Unauthorized();

            // check for existing token
            var existingToken = user.Tokens.Where(x => x.LoginProvider == "Two-Factor").FirstOrDefault();
            if (existingToken != null)
                user.Tokens.Remove(existingToken);

            // generate new token
            var secret = Base32Encoding.ToString(KeyGeneration.GenerateRandomKey(20));
            user.TwoFactorEnabled = true;
            user.Tokens.Add(new IdentityUserToken<string>()
            {
                LoginProvider = "Two-Factor",
                Name = user.Email,
                UserId = user.Id,
                Value = secret
            });

            var identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                _logger.Exception(new Exception(identityResult.Errors.First().Description));
                return BadRequest(identityResult.Errors.First().Description);
            }

            ViewData["Email"] = user.Email;
            ViewData["Token"] = secret;
            ViewData["LoginUrl"] = _appSettings.Application.MainSiteUrlTrim + "/Account/Login";
            return View();
        }

        /// <summary>
        /// TwoFactor Authentication Validate
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Validate()</method>
        [HttpGet]
        public async Task<IActionResult> Validate()
        {
            if (TempData["TwoFactorValidateModel"] == null)
                return Unauthorized();

            var twoFactorValidateModel = TempData["TwoFactorValidateModel"].ToString();
            if (string.IsNullOrEmpty(twoFactorValidateModel))
                return Unauthorized();

            var model = JsonConvert.DeserializeObject<TwoFactorValidateModel>(twoFactorValidateModel);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized();

            return View(model);
        }

        /// <summary>
        /// TwoFactor Authentication Validate
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Validate(TwoFactorValidateModel model)</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Validate(TwoFactorValidateModel model)
        {
            if (ModelState.IsValid)
            {
                var email = model.Email.Clean();
                if (string.IsNullOrEmpty(email))
                    return Unauthorized();

                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return Unauthorized();

                var totpCode = model.TotpCode?.Replace(" ", string.Empty).Replace("-", string.Empty) ?? string.Empty;
                var twoFactorToken = user.Tokens.Where(x => x.LoginProvider == "Two-Factor").Select(x => x.Value).FirstOrDefault();
                if (string.IsNullOrEmpty(twoFactorToken))
                    return Unauthorized();

                var totp = new Totp(Base32Encoding.ToBytes(twoFactorToken));
                var computeTotp = totp.ComputeTotp(DateTime.UtcNow);

                if (totpCode.Equals(computeTotp))
                {
                    var additionalLocalClaims = new List<Claim>();
                    var localSignInProps = new AuthenticationProperties();
                    if (model.AuthenticationToken != null)
                        localSignInProps.StoreTokens(new[] { new AuthenticationToken { Name = "id_token", Value = model.AuthenticationToken } });

                    // issue authentication cookie for user
                    // we must issue the cookie maually, and can't use the SignInManager because
                    // it doesn't expose an API to issue additional claims from the login workflow
                    var principal = await _signInManager.CreateUserPrincipalAsync(user);
                    additionalLocalClaims.AddRange(principal.Claims);
                    var name = user.FullName; //principal.FindFirst(JwtClaimTypes.Name)?.Value ?? user.Id;

                    var isuser = new IdentityServerUser(user.Id)
                    {
                        DisplayName = name,
                        IdentityProvider = model.Provider,
                        AdditionalClaims = additionalLocalClaims
                    };

                    await HttpContext.SignInAsync(isuser, localSignInProps);
                    // delete temporary cookie used during external authentication
                    await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

                    // retrieve return URL
                    var returnUrl = model.ReturnUrl ?? _appSettings.Application.MainSiteUrlTrim + "/Home/Index";

                    // check if external login is in the context of an OIDC request
                    var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
                    await _events.RaiseAsync(new UserLoginSuccessEvent(model.Provider, model.ProviderUserId, user.Id, name, true, context?.Client.ClientId));

                    if (context != null)
                    {
                        if (context.IsNativeClient())
                        {
                            // The client is native, so this change in how to
                            // return the response is for better UX for the end user.
                            return this.LoadingPage("Redirect", returnUrl);
                        }
                    }

                    return Redirect(returnUrl);
                }

                return Unauthorized();
            }

            return View(model);
        }

        /// <summary>
        /// TwoFactor Authentication Disable
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Disable()</method>
        [HttpGet]
        public async Task<IActionResult> Disable()
        {
            var email = TempData["email"]?.ToString();
            if (string.IsNullOrEmpty(email))
                return Unauthorized();

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Unauthorized();

            user.TwoFactorEnabled = false;

            // check for existing tokens
            List<IdentityUserToken<string>> existingTokens = user
                .Tokens.Where(x => x.LoginProvider == "Two-Factor")
                .ToList();
            foreach (IdentityUserToken<string> existingToken in existingTokens)
                user.Tokens.Remove(existingToken);

            var identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                _logger.Exception(new Exception(identityResult.Errors.First().Description));
                return BadRequest(identityResult.Errors.First().Description);
            }

            ViewData["LoginUrl"] = _appSettings.Application.MainSiteUrlTrim + "/Account/Login";
            return View();
        }

        /// <summary>
        /// TwoFactor Authentication Retrive
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Retrive()</method>
        [HttpGet]
        public async Task<IActionResult> Retrive()
        {
            var email = TempData["Email"]?.ToString();
            if (string.IsNullOrEmpty(email))
                return Unauthorized();

            var user = await _userManager.FindByEmailAsync(email.Clean());
            if (user == null)
                return Unauthorized();

            var token = await _userManager.GenerateUserTokenAsync(user, "Default", "Two-Factor-Retrive");
            var confirmationLink = Url.Action(nameof(RetriveConfirm), "TwoFactor", new { token, email = user.Email }, Request.Scheme);

            MailMessage mailMessage = new MailMessage(
                _appSettings.EmailService.Email,
                user.Email
            );

            mailMessage.Subject = "Retrive Two-Factor Authentication";
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = AsciiCodes.CRLF
                + "Please submit following link in your web browser to retrive two-factor authentication configuration:"
                + AsciiCodes.CRLF + AsciiCodes.CRLF + confirmationLink
                + AsciiCodes.CRLF + AsciiCodes.CRLF;

            await _emailService.Send(mailMessage);
            ViewData["Email"] = user.Email;

            return View();
        }

        /// <summary>
        /// TwoFactor Authentication Retrive Confirm
        /// </summary>
        /// <param name="token">string</param>
        /// <param name="email">string</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>RetriveConfirm(string token, string email)</method>
        [HttpGet]
        public async Task<IActionResult> RetriveConfirm(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email.Clean());
            if (user == null)
                return Unauthorized();

            var result = await _userManager.VerifyUserTokenAsync(user, "Default", "Two-Factor-Retrive", token.Clean());
            if (!result)
                return Unauthorized();

            var twoFactorToken = user.Tokens.Where(x => x.LoginProvider == "Two-Factor").Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(twoFactorToken))
                return Unauthorized();

            ViewData["Email"] = user.Email;
            ViewData["Token"] = twoFactorToken;
            ViewData["LoginUrl"] = _appSettings.Application.MainSiteUrlTrim + "/Account/Login";
            return View();
        }
    }
}
