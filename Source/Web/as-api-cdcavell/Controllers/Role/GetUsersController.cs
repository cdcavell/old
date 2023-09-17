using as_api_cdcavell.Data;
using as_api_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace as_api_cdcavell.Controllers.Role
{
    /// <class>GetUsersController</class>
    /// <summary>
    /// Identity Role GetUsersAsync Controller Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [Route("Role/[controller]")]
    public class GetUsersController : ApplicationBaseController<GetUsersController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;GetUsersController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="authorizationService">IAuthorizationService</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="dbContext">AuthorizationServiceDbContext</param>
        /// <method>
        /// public GetUsersController(
        ///     ILogger&lt;GetUsersController&gt; logger,
        ///     IWebHostEnvironment webHostEnvironment,
        ///     IHttpContextAccessor httpContextAccessor,
        ///     IAuthorizationService authorizationService,
        ///     AppSettings appSettings,
        ///     AuthorizationServiceDbContext dbContext
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        /// </method>
        public GetUsersController(
            ILogger<GetUsersController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService,
            AppSettings appSettings,
            AuthorizationServiceDbContext dbContext
        ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        {
        }

        /// <summary>
        /// GetUsers Post Method
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "Read")]
        public IActionResult Post(object encryptObject)
        {
            try
            {
                IHeaderDictionary headers = _httpContextAccessor.HttpContext.Request.Headers;
                string accessToken = headers.Where(x => x.Key == "Authorization").Select(x => x.Value).FirstOrDefault();
                if (string.IsNullOrEmpty(accessToken))
                    return BadRequest("Invalid Authorization");

                accessToken = accessToken.Substring(7);

                string jsonString = AESGCM.Decrypt(encryptObject.ToString(), accessToken);
                KeyValuePair<string, int> input = JsonConvert.DeserializeObject<KeyValuePair<string, int>>(jsonString);
                
                List<ApplicationUser> users = _dbContext.Users
                    .Join(_dbContext.UserRoleClaims, Users => Users.Id, UserRoleClaims => UserRoleClaims.UserId, (Users, UserRoleClaims) => new { Users, UserRoleClaims })
                    .Where(x => x.UserRoleClaims.RoleId == input.Key)
                    .Where(x => x.UserRoleClaims.RoleClaimId == input.Value)
                    .Select(x => x.Users)
                    .Include("Claims")
                    .Include("Logins")
                    .Include("Tokens")
                    .Include("RoleClaims")
                    .Include("RoleClaims.Role")
                    .Include("RoleClaims.RoleClaim")
                    .ToList();

                jsonString = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);
                return new JsonResult(encryptString);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                return BadRequest(exception);
            }
        }
    }
}
