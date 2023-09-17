using CDCavell.ClassLibrary.Commons;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Services.Email;
using dis5_cdcavell.Models.AppSettings;
using dis5_cdcavell.Models.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace dis5_cdcavell.Controllers
{
    /// <summary>
    /// Registration Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [AllowAnonymous]
    public class RegistrationController : ApplicationBaseController<RegistrationController>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private IEmailService _emailService;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;RegistrationController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="userManager">UserManager&lt;ApplicationUser&gt;</param>
        /// <param name="emailService">EmailService</param>
        /// <method>
        /// RegistrationController(
        ///     ILogger&lt;RegistrationController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor
        ///     AppSettings appSettings,
        ///     UserManager&lt;ApplicationUser&gt; userManager,
        ///     IEmailService emailService
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        /// </method>
        public RegistrationController(
            ILogger<RegistrationController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings,
            UserManager<ApplicationUser> userManager,
            IEmailService emailService
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        /// <summary>
        /// TwoFactor Authentication Configuration
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>TwoFactorConfiguration()</method>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var email = TempData["Email"]?.ToString();
            if (string.IsNullOrEmpty(email))
                return Unauthorized();

            var user = await _userManager.FindByEmailAsync(email.Clean());
            if (user == null)
                return Unauthorized();

            RegistrationIndexModel model = new RegistrationIndexModel();
            model.Email = user.Email;
            model.FirstName = user.FirstName ?? string.Empty;
            model.LastName = user.LastName ?? string.Empty;
            model.Status = user.Status;

            return View(model);
        }

        /// <summary>
        /// New Registration HttpPost method
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Index(RegistrationIndexModel model)</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegistrationIndexModel model)
        {
            if (ModelState.IsValid)
            {
                var email = model.Email.Clean();
                if (string.IsNullOrEmpty(email))
                    return Unauthorized();

                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return Unauthorized();

                user.FirstName = model.FirstName.Clean();
                user.LastName = model.LastName.Clean();
                user.RequestDate = DateTime.Now;

                var identityResult = await _userManager.UpdateAsync(user);
                if (!identityResult.Succeeded)
                {
                    _logger.Exception(new Exception(identityResult.Errors.First().Description));
                    return BadRequest(identityResult.Errors.First().Description);
                }

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Registration", new { token, email = user.Email }, Request.Scheme);

                MailMessage mailMessage = new MailMessage(
                    _appSettings.EmailService.Email,
                    user.Email
                );

                mailMessage.Subject = "Email Validation";
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = AsciiCodes.CRLF
                    + "Please submit following link in your web browser for email validation:"
                    + AsciiCodes.CRLF + AsciiCodes.CRLF + confirmationLink
                    + AsciiCodes.CRLF + AsciiCodes.CRLF;

                await _emailService.Send(mailMessage);
                TempData["Email"] = user.Email;
                return RedirectToAction(nameof(EmailValidation));
            }

            return View(model);
        }

        /// <summary>
        /// Email validation notice 
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>EmailValidation()</method>
        [HttpGet]
        public async Task<IActionResult> EmailValidation()
        {
            var email = TempData["Email"]?.ToString();
            if (string.IsNullOrEmpty(email))
                return Unauthorized();

            var user = await _userManager.FindByEmailAsync(email.Clean());
            if (user == null)
                return Unauthorized();

            ViewData["Email"] = user.Email;
            return View();
        }

        /// <summary>
        /// Email verification of external authentication
        /// </summary>
        /// <param name="token">string</param>
        /// <param name="email">string</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>ConfirmEmail(string token, string email)</method>
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Unauthorized();

            if (await _userManager.IsEmailConfirmedAsync(user))
                return Redirect(_appSettings.Application.MainSiteUrlTrim + "/Account/Login");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
                return Unauthorized();

            ViewData["Email"] = user.Email;
            ViewData["LoginUrl"] = _appSettings.Application.MainSiteUrlTrim + "/Account/Login";
            return View();
        }

    }
}
