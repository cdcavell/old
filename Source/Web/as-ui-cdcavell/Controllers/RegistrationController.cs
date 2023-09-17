using as_ui_cdcavell.Models.AppSettings;
using as_ui_cdcavell.Models.Registration;
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
using System.Net;
using System.Threading.Tasks;

namespace as_ui_cdcavell.Controllers
{
    /// <summary>
    /// Registration Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.1 | 06/07/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class RegistrationController : ApplicationBaseController<RegistrationController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;RegistrationController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="userManager">CustomUserManager</param>
        /// <param name="roleManager">CustomRoleManager</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// RegistrationController(
        ///     ILogger&lt;RegistrationController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings,
        ///     CustomUserManager userManager,
        ///     CustomRoleManager roleManager
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        /// </method>
        public RegistrationController(
            ILogger<RegistrationController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings,
            CustomUserManager userManager,
            CustomRoleManager roleManager
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        {
        }

        /// <summary>
        /// Registration Status HttpGet method
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Status()</method>
        [HttpGet]
        public async Task<IActionResult> Status()
        {
            string subject = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(subject))
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(subject);
            if (user == null)
                return Unauthorized();

            StatusModel model = new StatusModel();
            model.Email = user.Email;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.RequestDate = user.RequestDate;
            model.Status = user.Status;
            model.TwoFactorEnabled = user.TwoFactorEnabled;
            model.RoleClaims = user.RoleClaims.OrderBy(x => x.Role.Name).ToList();

            foreach(AspNetUserRoleClaim roleClaim in model.RoleClaims)
                roleClaim.History = await _userManager.GetRoleClaimHistory(roleClaim.Id);

            return View(model);
        }

        /// <summary>
        /// Update Registration HttpGet method
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Update()</method>
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            string subject = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(subject))
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(subject);
            if (user == null)
                return Unauthorized();

            if (user.IsSysAdmin)
                return BadRequest("Update of System Administration Account not allowed");

            StatusModel model = new StatusModel();
            model.Email = user.Email;
            model.FirstName = user.FirstName ?? string.Empty;
            model.LastName = user.LastName ?? string.Empty;
            model.RequestDate = user.RequestDate;
            model.Status = user.Status;
            model.TwoFactorEnabled = user.TwoFactorEnabled;
            model.RoleClaims = user.RoleClaims.OrderBy(x => x.Role.Name).ToList();

            foreach (AspNetUserRoleClaim roleClaim in model.RoleClaims)
                roleClaim.History = await _userManager.GetRoleClaimHistory(roleClaim.Id);

            return View(model);
        }

        /// <summary>
        /// Update Registration HttpPost method
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Update(RegistrationIndexModel model)</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(StatusModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();
                if (string.IsNullOrEmpty(subject))
                    return Unauthorized();

                var user = await _userManager.FindByIdAsync(subject);
                if (user == null)
                    return Unauthorized();

                if (user.IsSysAdmin)
                    return BadRequest("Update of System Administration Account not allowed");

                user.FirstName = model.FirstName.Clean();
                user.LastName = model.LastName.Clean();

                var identityResult = await _userManager.UpdateAsync(user);
                if (!identityResult.Succeeded)
                    throw new Exception(identityResult.Errors.First().Description);

                return RedirectToAction("Status", "Registration");
            }

            return View(model);
        }

        /// <summary>
        /// Registration Administration HttpGet method
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Administration()</method>
        [HttpGet]
        [CustomAuthorize("Admin:View")]
        public async Task<IActionResult> Administration()
        {
            string subject = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(subject))
                return Unauthorized();

            var user = await _userManager.FindByIdAsync(subject);
            if (user == null)
                return Unauthorized();

            AdministrationModel model = new AdministrationModel();
            model.PendingRegistrations = await _userManager.GetPendingRegistrations();

            return View(model);
        }

        /// <summary>
        /// Administration HttpPost method
        /// </summary>
        /// <param name="model">AdministrationModel</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Administration(AdministrationModel model)</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize("Admin:View")]
        public async Task<IActionResult> Administration(AdministrationModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();
                if (string.IsNullOrEmpty(subject))
                    return Unauthorized();

                var user = await _userManager.FindByIdAsync(subject);
                if (user == null)
                    return Unauthorized();

                switch (model.Action.ToLower())
                {
                    case "approve":
                        if (user.HasRoleClaim("Admin:Edit"))
                            model = await Approve(model, user);
                        break;
                    case "reject":
                        if (user.HasRoleClaim("Admin:Edit"))
                            model = await Reject(model, user);
                        break;
                    case "search":
                        model = await Search(model, user);
                        break;
                }

                model.PendingRegistrations = (await _userManager.GetPendingRegistrations())
                    .Where(x => x.Id != user.Id)
                    .ToList();

                return View(model);
            }

            return RedirectToAction("Administration", "Registration");
        }

        /// <summary>
        /// RoleClaim HttpPost method
        /// </summary>
        /// <param name="model">AdministrationModel</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>RoleClaim(AdministrationModel model)</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize("Admin:Edit")]
        public async Task<IActionResult> RoleClaim(AdministrationModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();
                if (string.IsNullOrEmpty(subject))
                    return Unauthorized();

                var user = await _userManager.FindByIdAsync(subject);
                if (user == null)
                    return Unauthorized();

                switch (model.Action.ToLower())
                {
                    case "enableroleclaim":
                        IdentityResult enroleResult = await EnableRoleClaim (model.Id, model.RoleId, model.ClaimId, user);
                        if (!enroleResult.Succeeded)
                            throw new Exception(enroleResult.Errors.First().Description);
                        break;
                    case "disableroleclaim":
                        IdentityResult disableResult = await DisableRoleClaim(model.Id, model.RoleId, model.ClaimId, user);
                        if (!disableResult.Succeeded)
                            throw new Exception(disableResult.Errors.First().Description);
                        break;
                }

                model.Roles = _roleManager.Roles
                    .OrderBy(x => x.Name)
                    .ToList();

                string searchRequest = WebUtility.UrlDecode(model.SearchModel.SearchRequest).Trim();
                var result = await _userManager.FindByEmailAsync(searchRequest);

                model.SearchModel.SearchResult = new SearchResultModel();

                model.SearchModel.SearchResult.UserId = result.Id;
                model.SearchModel.SearchResult.Email = result.Email;
                model.SearchModel.SearchResult.FirstName = result.FirstName;
                model.SearchModel.SearchResult.LastName = result.LastName;
                model.SearchModel.SearchResult.RequestDate = result.RequestDate;
                model.SearchModel.SearchResult.Status = result.Status;
                model.SearchModel.SearchResult.IsSelf = (result.Id == user.Id);
                model.SearchModel.SearchResult.IsSysAdmin = result.IsSysAdmin;
                model.SearchModel.SearchResult.IsActive = result.IsActive;
                model.SearchModel.SearchResult.IsPending = result.IsPending;
                model.SearchModel.SearchResult.IsRevoked = result.IsRevoked;
                model.SearchModel.SearchResult.TwoFactorEnabled = result.TwoFactorEnabled;
                model.SearchModel.SearchResult.RoleClaims = result.RoleClaims.OrderBy(x => x.Role.Name).ToList();

                foreach (AspNetUserRoleClaim roleClaim in model.SearchModel.SearchResult.RoleClaims)
                    roleClaim.History = await _userManager.GetRoleClaimHistory(roleClaim.Id);

                return View(model);
            }

            return RedirectToAction("Administration", "Registration");
        }

        private async Task<AdministrationModel> Approve(AdministrationModel model, ApplicationUser user)
        {
            ApplicationUser registration = await _userManager.FindByIdAsync(model.Id);
            if (registration == null)
                throw new Exception($"Invalid Registration.Id: {model.Id}");

            registration.ApprovedById = user.Id;
            registration.ApprovedBy = user;
            registration.ApprovedDate = DateTime.Now;
            registration.RevokedById = null;
            registration.RevokedBy = null;
            registration.RevokedDate = DateTime.MinValue;

            ApplicationRole role = await _roleManager.FindByNameAsync("User");
            foreach (ApplicationRoleClaim roleClaim in role.RoleClaims)
            {
                AspNetUserRoleClaim userRoleClaim = registration.RoleClaims
                    .Where(x => x.UserId == registration.Id
                        && x.RoleId == roleClaim.RoleId
                        && x.RoleClaim.ClaimType == roleClaim.ClaimType
                    )
                    .FirstOrDefault();

                if (userRoleClaim != null)
                {
                    userRoleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;

                    AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                    history.ActionOn = DateTime.Now;
                    history.ActionById = user.Id;
                    history.ActionBy = user;
                    history.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;
                    history.UserRoleClaimId = userRoleClaim.Id;
                    history.UserRoleClaim = userRoleClaim;

                    userRoleClaim.History.Add(history);
                }
                else
                {
                    userRoleClaim = new AspNetUserRoleClaim();
                    userRoleClaim.UserId = registration.Id;
                    userRoleClaim.User = registration;
                    userRoleClaim.RoleId = role.Id;
                    userRoleClaim.Role = role;
                    userRoleClaim.RoleClaimId = roleClaim.Id;
                    userRoleClaim.RoleClaim = roleClaim;
                    userRoleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;

                    AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                    history.ActionOn = DateTime.Now;
                    history.ActionBy = user;
                    history.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;
                    history.UserRoleClaim = userRoleClaim;

                    userRoleClaim.History.Add(history);

                    registration.RoleClaims.Add(userRoleClaim);
                }
            }

            IdentityResult identityResult = await _userManager.UpdateAsync(registration);
            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.First().Description);

            return model;
        }

        private async Task<AdministrationModel> Reject(AdministrationModel model, ApplicationUser user)
        {
            var registration = await _userManager.FindByIdAsync(model.Id);
            if (registration == null)
                throw new Exception($"Invalid Registration.Id: {model.Id}");

            registration.ApprovedById = null;
            registration.ApprovedBy = null;
            registration.ApprovedDate = DateTime.MinValue;
            registration.RevokedById = user.Id;
            registration.RevokedBy = user;
            registration.RevokedDate = DateTime.Now;

            ApplicationRole role = await _roleManager.FindByNameAsync("User");
            foreach (ApplicationRoleClaim roleClaim in role.RoleClaims)
            {
                AspNetUserRoleClaim userRoleClaim = registration.RoleClaims
                    .Where(x => x.UserId == registration.Id
                        && x.RoleId == roleClaim.RoleId
                        && x.RoleClaim.ClaimType == roleClaim.ClaimType
                    )
                    .FirstOrDefault();

                if (userRoleClaim != null)
                {
                    userRoleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;

                    AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                    history.ActionOn = DateTime.Now;
                    history.ActionById = user.Id;
                    history.ActionBy = user;
                    history.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;
                    history.UserRoleClaimId = userRoleClaim.Id;
                    history.UserRoleClaim = userRoleClaim;

                    userRoleClaim.History.Add(history);
                }
                else
                {
                    userRoleClaim = new AspNetUserRoleClaim();
                    userRoleClaim.UserId = registration.Id;
                    userRoleClaim.User = registration;
                    userRoleClaim.RoleId = role.Id;
                    userRoleClaim.Role = role;
                    userRoleClaim.RoleClaimId = roleClaim.Id;
                    userRoleClaim.RoleClaim = roleClaim;
                    userRoleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;

                    AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                    history.ActionOn = DateTime.Now;
                    history.ActionById = user.Id;
                    history.ActionBy = user;
                    history.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;
                    history.UserRoleClaimId = userRoleClaim.Id;
                    history.UserRoleClaim = userRoleClaim;

                    userRoleClaim.History.Add(history);

                    registration.RoleClaims.Add(userRoleClaim);
                }
            }

            IdentityResult identityResult = await _userManager.UpdateAsync(registration);
            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.First().Description);

            return model;
        }

        private async Task<AdministrationModel> Search(AdministrationModel model, ApplicationUser user)
        {
            string searchRequest = WebUtility.UrlDecode(model.SearchModel.SearchRequest).Trim();
            if (string.IsNullOrEmpty(searchRequest))
            {
                ModelState.AddModelError("SearchModel.SearchRequest", $"Email address required");
            }
            else
            {
                var result = await _userManager.FindByEmailAsync(searchRequest);
                if (result == null)
                {
                    model.SearchModel.SearchResult = new SearchResultModel();
                    ModelState.AddModelError("SearchModel.SearchRequest", $"Email address {searchRequest} not found");
                }
                else
                {
                    model.SearchModel.SearchResult = new SearchResultModel();

                    model.SearchModel.SearchResult.UserId = result.Id;
                    model.SearchModel.SearchResult.Email = result.Email;
                    model.SearchModel.SearchResult.FirstName = result.FirstName;
                    model.SearchModel.SearchResult.LastName = result.LastName;
                    model.SearchModel.SearchResult.RequestDate = result.RequestDate;
                    model.SearchModel.SearchResult.Status = result.Status;
                    model.SearchModel.SearchResult.IsSelf = (result.Id == user.Id);
                    model.SearchModel.SearchResult.IsSysAdmin = result.IsSysAdmin;
                    model.SearchModel.SearchResult.IsActive = result.IsActive;
                    model.SearchModel.SearchResult.IsPending = result.IsPending;
                    model.SearchModel.SearchResult.IsRevoked = result.IsRevoked;
                    model.SearchModel.SearchResult.TwoFactorEnabled = result.TwoFactorEnabled;
                    model.SearchModel.SearchResult.RoleClaims = result.RoleClaims.OrderBy(x => x.Role.Name).ToList();

                    foreach (AspNetUserRoleClaim roleClaim in model.SearchModel.SearchResult.RoleClaims)
                        roleClaim.History = await _userManager.GetRoleClaimHistory(roleClaim.Id);
                }
            }

            return model;
        }

        private async Task<IdentityResult> EnableRoleClaim(string userId, string roleId, int claimId, ApplicationUser user)
        {
            try
            {
                ApplicationUser registration = await _userManager.FindByIdAsync(userId);
                if (registration != null)
                {
                    bool addRoleClaim = true;

                    foreach (AspNetUserRoleClaim roleClaim in registration.RoleClaims)
                    {
                        if (roleClaim.RoleId == roleId && roleClaim.RoleClaimId == claimId)
                        {
                            roleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;

                            AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                            history.ActionOn = DateTime.Now;
                            history.ActionBy = user;
                            history.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;
                            history.UserRoleClaim = roleClaim;

                            roleClaim.History.Add(history);

                            addRoleClaim = false;
                        }
                    }

                    if (addRoleClaim)
                    {
                        AspNetUserRoleClaim userRoleClaim = new AspNetUserRoleClaim();
                        userRoleClaim.UserId = registration.Id;
                        userRoleClaim.User = registration;
                        userRoleClaim.RoleId = roleId;
                        userRoleClaim.RoleClaimId = claimId;
                        userRoleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;

                        AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                        history.ActionOn = DateTime.Now;
                        history.ActionBy = user;
                        history.Status = AspNetUserRoleClaim.RoleClaimStatus.Approved;
                        history.UserRoleClaim = userRoleClaim;

                        userRoleClaim.History.Add(history);

                        registration.RoleClaims.Add(userRoleClaim);
                    }

                    IdentityResult identityResult = await _userManager.UpdateAsync(registration);
                    if (!identityResult.Succeeded)
                        throw new Exception(identityResult.Errors.First().Description);
                }

                return IdentityResult.Success;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = exception.Source,
                        Description = exception.Message
                    }
                );
            }
        }
        private async Task<IdentityResult> DisableRoleClaim(string userId, string roleId, int claimId, ApplicationUser user)
        {
            try
            {
                ApplicationUser registration = await _userManager.FindByIdAsync(userId);
                if (registration != null)
                {
                    foreach (AspNetUserRoleClaim roleClaim in registration.RoleClaims)
                    {
                        if (roleClaim.RoleId == roleId && roleClaim.RoleClaimId == claimId)
                        {
                            roleClaim.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;

                            AspNetUserRoleClaimHistory history = new AspNetUserRoleClaimHistory();
                            history.ActionOn = DateTime.Now;
                            history.ActionBy = user;
                            history.Status = AspNetUserRoleClaim.RoleClaimStatus.Rejected;
                            history.UserRoleClaim = roleClaim;

                            roleClaim.History.Add(history);
                        }
                    }

                    IdentityResult identityResult = await _userManager.UpdateAsync(registration);
                    if (!identityResult.Succeeded)
                        throw new Exception(identityResult.Errors.First().Description);
                }

                return IdentityResult.Success;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = exception.Source,
                        Description = exception.Message
                    }
                );
            }
        }
    }
}
