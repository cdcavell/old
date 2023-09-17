using as_ui_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Identity.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace as_ui_cdcavell.Controllers
{
    /// <summary>
    /// Two-Factor Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class TwoFactorController : ApplicationBaseController<TwoFactorController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;TwoFactorController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="userManager">CustomUserManager</param>
        /// <param name="roleManager">CustomRoleManager</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// TwoFactorController(
        ///     ILogger&lt;TwoFactorController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings,
        ///     CustomUserManager userManager,
        ///     CustomRoleManager roleManager
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        /// </method>
        public TwoFactorController(
            ILogger<TwoFactorController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings,
            CustomUserManager userManager,
            CustomRoleManager roleManager
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        {
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
                throw new Exception(identityResult.Errors.First().Description);

            return RedirectToAction("Status", "Registration");
        }

        /// <summary>
        /// TwoFactor Authentication Enable
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Enable()</method>
        [HttpGet]
        public async Task<IActionResult> Enable()
        {
            var email = TempData["email"]?.ToString();
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
                throw new Exception(identityResult.Errors.First().Description);

            ViewData["Email"] = user.Email;
            ViewData["Token"] = secret;
            return View();
        }
    }
}
