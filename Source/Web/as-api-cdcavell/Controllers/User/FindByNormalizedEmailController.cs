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
using System.Linq;

namespace as_api_cdcavell.Controllers.User
{
    /// <class>FindByNormalizedEmailController</class>
    /// <summary>
    /// Identity User FindByNormalizedEmailAsync Controller Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |~ 
    /// </revision>
    [Route("User/[controller]")]
    public class FindByNormalizedEmailController : ApplicationBaseController<FindByNormalizedEmailController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;FindByNormalizedEmailController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="authorizationService">IAuthorizationService</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="dbContext">AuthorizationServiceDbContext</param>
        /// <method>
        /// public FindByNormalizedEmailController(
        ///     ILogger&lt;FindByNormalizedEmailController&gt; logger,
        ///     IWebHostEnvironment webHostEnvironment,
        ///     IHttpContextAccessor httpContextAccessor,
        ///     IAuthorizationService authorizationService,
        ///     AppSettings appSettings,
        ///     AuthorizationServiceDbContext dbContext
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        /// </method>
        public FindByNormalizedEmailController(
            ILogger<FindByNormalizedEmailController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService,
            AppSettings appSettings,
            AuthorizationServiceDbContext dbContext
        ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        {
        }

        /// <summary>
        /// FindByNormalizedEmail Post Method
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
                string input = JsonConvert.DeserializeObject<string>(jsonString);

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
                    .Where(x => x.NormalizedEmail.Trim().ToUpper() == input.Trim().ToUpper())
                    .FirstOrDefault();

                jsonString = JsonConvert.SerializeObject(user, new JsonSerializerSettings()
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
