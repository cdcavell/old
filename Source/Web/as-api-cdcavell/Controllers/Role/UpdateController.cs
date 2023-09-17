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

namespace as_api_cdcavell.Controllers.Role
{
    /// <class>UpdateController</class>
    /// <summary>
    /// Identity Role UpdateAsync Controller Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [Route("Role/[controller]")]
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
                    ApplicationRole input = JsonConvert.DeserializeObject<ApplicationRole>(jsonString);

                    ApplicationRole role = _dbContext.Roles
                        .Include("RoleClaims")
                        .Where(x => x.Id == input.Id)
                        .FirstOrDefault();

                    if (role != null)
                    {
                        if (role.ConcurrencyStamp != input.ConcurrencyStamp)
                            role.ConcurrencyStamp = input.ConcurrencyStamp;
                        if (role.Name != input.Name)
                        {
                            role.Name = input.Name;
                            role.NormalizedName = input.NormalizedName.Trim().ToUpper();
                        }

                        // remove Claims
                        foreach (ApplicationRoleClaim roleClaim in role.RoleClaims.ToArray())
                        {
                            var inputClaim = input.RoleClaims
                                .Where(x => x.ClaimType.Trim().ToUpper() == roleClaim.ClaimType.Trim().ToUpper() && x.ClaimValue.Trim().ToUpper() == roleClaim.ClaimValue.Trim().ToUpper())
                                .FirstOrDefault();

                            if (inputClaim == null)
                            {
                                role.RoleClaims.Remove(roleClaim);
                                _dbContext.Entry(roleClaim).State = EntityState.Deleted;
                            }
                        }

                        // add Claims
                        foreach (ApplicationRoleClaim inputClaim in input.RoleClaims)
                        {
                            var roleClaim = role.RoleClaims
                                .Where(x => x.ClaimType.Trim().ToUpper() == inputClaim.ClaimType.Trim().ToUpper() && x.ClaimValue.Trim().ToUpper() == inputClaim.ClaimValue.Trim().ToUpper())
                                .FirstOrDefault();

                            if (roleClaim == null)
                                role.RoleClaims.Add(inputClaim);
                        }

                        // save changes
                        if (_dbContext.HasUnsavedChanges())
                        {
                            _dbContext.Roles.Update(role);
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
