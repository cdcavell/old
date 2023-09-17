using as_api_cdcavell.Data;
using as_api_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace as_api_cdcavell.Controllers.User
{
    /// <class>UpdateController</class>
    /// <summary>
    /// Identity User UpdateAsync Controller Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |~ 
    /// | Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [Route("User/[controller]")]
    public class UpdateController : ApplicationBaseController<UpdateController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;UpdateController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="authorizationService">IAuthorizationService</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="dbContext">AuthorizationServiceDbContext</param>
        /// <method>
        /// public UpdateController(
        ///     ILogger&lt;UpdateController&gt; logger,
        ///     IWebHostEnvironment webHostEnvironment,
        ///     IHttpContextAccessor httpContextAccessor,
        ///     IAuthorizationService authorizationService,
        ///     AppSettings appSettings,
        ///     AuthorizationServiceDbContext dbContext
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        /// </method>
        public UpdateController(
            ILogger<UpdateController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService,
            AppSettings appSettings,
            AuthorizationServiceDbContext dbContext
        ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        {
        }

        /// <summary>
        /// Update Post Method
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "Write")]
        public IActionResult Post(object encryptObject)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    IHeaderDictionary headers = _httpContextAccessor.HttpContext.Request.Headers;
                    string accessToken = headers.Where(x => x.Key == "Authorization").Select(x => x.Value).FirstOrDefault();
                    if (string.IsNullOrEmpty(accessToken))
                        return BadRequest("Invalid Authorization");

                    accessToken = accessToken.Substring(7);

                    string jsonString = AESGCM.Decrypt(encryptObject.ToString(), accessToken);
                    ApplicationUser input = JsonConvert.DeserializeObject<ApplicationUser>(jsonString);

                    ApplicationUser user = _dbContext.Users
                        .Include("Claims")
                        .Include("Logins")
                        .Include("Tokens")
                        .Include("RoleClaims")
                        //.Include("RoleClaims.User")
                        .Include("RoleClaims.Role")
                        .Include("RoleClaims.RoleClaim")
                        .Include("RoleClaims.History")
                        .Include("RoleClaims.History.ActionBy")
                        //.Include("RoleClaims.History.UserRoleClaim")
                        .Where(x => x.Id == input.Id)
                        .FirstOrDefault();

                    if (user != null)
                    {
                        if (user.AccessFailedCount != input.AccessFailedCount)
                            user.AccessFailedCount = input.AccessFailedCount;                       
                        if (user.ApprovedById != input.ApprovedById)
                            user.ApprovedById = input.ApprovedById;
                        if (user.ApprovedDate != input.ApprovedDate)
                            user.ApprovedDate = input.ApprovedDate;
                        if (user.ConcurrencyStamp != input.ConcurrencyStamp)
                            user.ConcurrencyStamp = input.ConcurrencyStamp;
                        if (user.Email != input.Email)
                        {
                            user.Email = input.Email;
                            user.NormalizedEmail = input.Email.Trim().ToUpper();
                        }
                        if (user.EmailConfirmed != input.EmailConfirmed)
                            user.EmailConfirmed = input.EmailConfirmed;
                        if (user.UserName != input.UserName)
                        {
                            user.UserName = input.UserName;
                            user.NormalizedUserName = input.UserName.Trim().ToUpper();
                        }
                        if (user.FirstName != input.FirstName)
                            user.FirstName = input.FirstName;
                        if (user.LastName != input.LastName)
                            user.LastName = input.LastName;
                        if (user.LockoutEnabled != input.LockoutEnabled)
                            user.LockoutEnabled = input.LockoutEnabled;
                        if (user.LockoutEnd != input.LockoutEnd)
                            user.LockoutEnd = input.LockoutEnd;
                        if (user.PasswordHash != input.PasswordHash)
                            user.PasswordHash = input.PasswordHash;
                        if (user.PhoneNumber != input.PhoneNumber)
                            user.PhoneNumber = input.PhoneNumber;
                        if (user.PhoneNumberConfirmed != input.PhoneNumberConfirmed)
                            user.PhoneNumberConfirmed = input.PhoneNumberConfirmed;
                        if (user.RequestDate != input.RequestDate)
                            user.RequestDate = input.RequestDate;
                        if (user.RevokedById != input.RevokedById)
                            user.RevokedById = input.RevokedById;
                        if (user.RevokedDate != input.RevokedDate)
                            user.RevokedDate = input.RevokedDate;
                        if (user.TwoFactorEnabled != input.TwoFactorEnabled)
                            user.TwoFactorEnabled = input.TwoFactorEnabled;

                        // remove Claims
                        foreach (IdentityUserClaim<string> userClaim in user.Claims.ToArray())
                        {
                            var inputClaim = input.Claims
                                .Where(x => x.ClaimType.Trim().ToUpper() == userClaim.ClaimType.Trim().ToUpper() && x.ClaimValue.Trim().ToUpper() == userClaim.ClaimValue.Trim().ToUpper())
                                .FirstOrDefault();

                            if (inputClaim == null)
                            {
                                user.Claims.Remove(userClaim);
                                _dbContext.Entry(userClaim).State = EntityState.Deleted;
                            }
                        }

                        // add Claims
                        foreach (IdentityUserClaim<string> inputClaim in input.Claims)
                        {
                            var userClaim = user.Claims.ToArray()
                                .Where(x => x.ClaimType.Trim().ToUpper() == inputClaim.ClaimType.Trim().ToUpper() && x.ClaimValue.Trim().ToUpper() == inputClaim.ClaimValue.Trim().ToUpper())
                                .FirstOrDefault();

                            if (userClaim == null)
                                user.Claims.Add(inputClaim);
                        }

                        // remove Logins
                        foreach (IdentityUserLogin<string> userLogin in user.Logins.ToArray())
                        {
                            var inputLogin = input.Logins
                                .Where(x => x.LoginProvider.Trim().ToUpper() == userLogin.LoginProvider.Trim().ToUpper() && x.ProviderKey.Trim().ToUpper() == userLogin.ProviderKey.Trim().ToUpper())
                                .FirstOrDefault();

                            if (inputLogin == null)
                            {
                                user.Logins.Remove(userLogin);
                                _dbContext.Entry(userLogin).State = EntityState.Deleted;
                            }
                        }

                        // add Logins
                        foreach (IdentityUserLogin<string> inputLogin in input.Logins)
                        {
                            var userLogin = user.Logins.ToArray()
                                .Where(x => x.LoginProvider.Trim().ToUpper() == inputLogin.LoginProvider.Trim().ToUpper() && x.ProviderKey.Trim().ToUpper() == inputLogin.ProviderKey.Trim().ToUpper())
                                .FirstOrDefault();

                            if (userLogin == null)
                                user.Logins.Add(inputLogin);
                        }

                        // remove Tokens
                        foreach (IdentityUserToken<string> userToken in user.Tokens.ToArray())
                        {
                            var inputToken = input.Tokens
                                .Where(x => x.LoginProvider.Trim().ToUpper() == userToken.LoginProvider.Trim().ToUpper() && x.Name.Trim().ToUpper() == userToken.Name.Trim().ToUpper() && x.Value.Trim().ToUpper() == userToken.Value.Trim().ToUpper())
                                .FirstOrDefault();

                            if (inputToken == null)
                            {
                                user.Tokens.Remove(userToken);
                                _dbContext.Entry(userToken).State = EntityState.Deleted;
                            }
                        }

                        // add Tokens
                        foreach (IdentityUserToken<string> inputToken in input.Tokens)
                        {
                            var userToken = user.Tokens.ToArray()
                                .Where(x => x.LoginProvider.Trim().ToUpper() == inputToken.LoginProvider.Trim().ToUpper() && x.Name.Trim().ToUpper() == inputToken.Name.Trim().ToUpper() && x.Value.Trim().ToUpper() == inputToken.Value.Trim().ToUpper())
                                .FirstOrDefault();

                            if (userToken == null)
                                user.Tokens.Add(inputToken);
                        }

                        // remove RoleClaims
                        foreach (AspNetUserRoleClaim userRoleClaim in user.RoleClaims.ToArray())
                        {
                            user.RoleClaims.Remove(userRoleClaim);
                            _dbContext.Entry(userRoleClaim).State = EntityState.Deleted;
                        }

                        // add RoleClaims
                        foreach (AspNetUserRoleClaim inputRoleClaim in input.RoleClaims)
                        {
                            var userRoleClaim = user.RoleClaims
                                .Where(x => x.RoleId == inputRoleClaim.RoleId
                                    && x.RoleClaimId == inputRoleClaim.RoleClaimId)
                                .FirstOrDefault();

                            if (userRoleClaim == null)
                            {
                                if (inputRoleClaim.User == null)
                                    inputRoleClaim.User = user;

                                foreach (AspNetUserRoleClaimHistory inputHistory in inputRoleClaim.History)
                                {
                                    if (inputHistory.UserRoleClaim == null)
                                        inputHistory.UserRoleClaim = inputRoleClaim;
                          
                                    _dbContext.Entry(inputHistory).State = EntityState.Added;
                                }

                                user.RoleClaims.Add(inputRoleClaim);
                                _dbContext.Entry(inputRoleClaim).State = EntityState.Added;
                            }
                        }

                        // save changes
                        if (_dbContext.HasUnsavedChanges())
                        {
                            _dbContext.Users.Update(user);
                            _dbContext.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                    }

                    return Ok();
                }
                catch (Exception exception)
                {
                    dbContextTransaction.Rollback();
                    _logger.Exception(exception);
                    return BadRequest(exception);
                }
            }
        }
    }
}
