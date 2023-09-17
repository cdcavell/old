using as_ui_cdcavell.Models.AppSettings;
using as_ui_cdcavell.Models.RoleClaims;
using CDCavell.ClassLibrary.Web.Identity.Authorization;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Identity.Services;
using IdentityModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace as_ui_cdcavell.Controllers
{
    /// <summary>
    /// RoleClaims Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.3 | 06/30/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class RoleClaimsController : ApplicationBaseController<RoleClaimsController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;RoleClaimsController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="userManager">CustomUserManager</param>
        /// <param name="roleManager">CustomRoleManager</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// RoleClaimsController(
        ///     ILogger&lt;RoleClaimsController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings,
        ///     CustomUserManager userManager,
        ///     CustomRoleManager roleManager
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        /// </method>
        public RoleClaimsController(
            ILogger<RoleClaimsController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings,
            CustomUserManager userManager,
            CustomRoleManager roleManager
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        {
        }

        /// <summary>
        /// RoleClaims HttpGet View method
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <method>Index()</method>
        [HttpGet]
        [CustomAuthorize("Admin:View")]
        public IActionResult Index()
        {
            var model = new ViewModel();
            model.Roles = _roleManager.Roles
                .OrderBy(x => x.Name)
                .ToList();

            return View(model);
        }

        /// <summary>
        /// RoleClaims HttpGet Disable View method
        /// </summary>
        /// <param name="role">string</param>
        /// <param name="claim">int</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Disable()</method>
        [HttpGet]
        [CustomAuthorize("Admin:Edit")]
        public async Task<IActionResult> Disable(string role, int claim)
        {
            var applicationRole = await _roleManager.FindByIdAsync(role.Clean());
            if (applicationRole != null)
            {
                var roleClaim = applicationRole.RoleClaims.Where(x => x.Id == claim).FirstOrDefault();
                if (roleClaim != null)
                {
                    roleClaim.ClaimValue = "Inactive";

                    var identityResult = await _roleManager.UpdateAsync(applicationRole);
                    if (!identityResult.Succeeded)
                        throw new Exception(identityResult.Errors.First().Description);
                }
            }

            return RedirectToAction("Index", "RoleClaims");
        }

        /// <summary>
        /// RoleClaims HttpGet Enable View method
        /// </summary>
        /// <param name="role">string</param>
        /// <param name="claim">int</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Enable()</method>
        [HttpGet]
        [CustomAuthorize("Admin:Edit")]
        public async Task<IActionResult> Enable(string role, int claim)
        {
            var applicationRole = await _roleManager.FindByIdAsync(role.Clean());
            if (applicationRole != null)
            {
                var roleClaim = applicationRole.RoleClaims.Where(x => x.Id == claim).FirstOrDefault();
                if (roleClaim != null)
                {
                    roleClaim.ClaimValue = "Active";

                    var identityResult = await _roleManager.UpdateAsync(applicationRole);
                    if (!identityResult.Succeeded)
                        throw new Exception(identityResult.Errors.First().Description);
                }
            }

            return RedirectToAction("Index", "RoleClaims");
        }

        /// <summary>
        /// RoleClaims HttpGet Users View method
        /// </summary>
        /// <param name="role">string</param>
        /// <param name="claim">int</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Users()</method>
        [HttpGet]
        [CustomAuthorize("Admin:Edit")]
        public async Task<IActionResult> Users(string role, int claim)
        {
            var model = new ViewModel();
            model.Users = await _roleManager.GetApprovedUsersAsync(role.Clean(), claim);
            
            var applicationRole = await _roleManager.FindByIdAsync(role.Clean());
            model.RoleDescription = applicationRole.Name.Trim();
            model.RoleId = applicationRole.Id;
            model.ClaimDescription = applicationRole.RoleClaims
                .Where(x => x.Id == claim)
                .Select(x => x.ClaimType)
                .FirstOrDefault()
                .Trim();
            model.ClaimId = applicationRole.RoleClaims
                .Where(x => x.Id == claim)
                .Select(x => x.Id)
                .FirstOrDefault();

            return View(model);
        }

        /// <summary>
        /// RoleClaims HttpPost RevokeClaim method
        /// </summary>
        /// <param name="model">ViewModel</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>RevokeClaim(ViewModel model)</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize("Admin:Edit")]
        public async Task<IActionResult> RevokeClaim(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();
                if (string.IsNullOrEmpty(subject))
                    return Unauthorized();

                var user = await _userManager.FindByIdAsync(subject);
                if (user == null)
                    return Unauthorized();

                var registration = await _userManager.FindByIdAsync(model.RevokeId);
                if (registration != null)
                {
                    foreach (AspNetUserRoleClaim roleClaim in registration.RoleClaims)
                    {
                        if (roleClaim.RoleClaimId == model.ClaimId)
                        {
                            roleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;

                            AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                            history.ActionOn = DateTime.Now;
                            history.ActionById = user.Id;
                            history.ActionBy = user;
                            history.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;
                            history.UserRoleClaimId = roleClaim.Id;
                            history.UserRoleClaim = roleClaim;

                            roleClaim.History.Add(history);
                        }
                    }

                    IdentityResult identityResult = await _userManager.UpdateAsync(registration);
                    if (!identityResult.Succeeded)
                        throw new Exception(identityResult.Errors.First().Description);
                }

                model.Users = await _roleManager.GetApprovedUsersAsync(model.RoleId, model.ClaimId);

                var applicationRole = await _roleManager.FindByIdAsync(model.RoleId);
                model.RoleDescription = applicationRole.Name.Trim();
                model.RoleId = applicationRole.Id;
                model.ClaimDescription = applicationRole.RoleClaims
                    .Where(x => x.Id == model.ClaimId)
                    .Select(x => x.ClaimType)
                    .FirstOrDefault()
                    .Trim();
                model.ClaimId = applicationRole.RoleClaims
                    .Where(x => x.Id == model.ClaimId)
                    .Select(x => x.Id)
                    .FirstOrDefault();

                return View("Users", model);
            }

            return BadRequest(ModelState);
        }
    }
}
