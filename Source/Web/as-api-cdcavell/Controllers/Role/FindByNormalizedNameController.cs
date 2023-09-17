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

namespace as_api_cdcavell.Controllers.Role
{
    /// <class>FindByNormalizedNameController</class>
    /// <summary>
    /// Identity Role FindByNormalizedNameAsync Controller Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [Route("Role/[controller]")]
    public class FindByNormalizedNameController : ApplicationBaseController<FindByNormalizedNameController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;FindByNormalizedNameController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="authorizationService">IAuthorizationService</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="dbContext">AuthorizationServiceDbContext</param>
        /// <method>
        /// public FindByNormalizedNameController(
        ///     ILogger&lt;FindByNormalizedNameController&gt; logger,
        ///     IWebHostEnvironment webHostEnvironment,
        ///     IHttpContextAccessor httpContextAccessor,
        ///     IAuthorizationService authorizationService,
        ///     AppSettings appSettings,
        ///     AuthorizationServiceDbContext dbContext
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        /// </method>
        public FindByNormalizedNameController(
            ILogger<FindByNormalizedNameController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService,
            AppSettings appSettings,
            AuthorizationServiceDbContext dbContext
        ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        {
        }

        /// <summary>
        /// FindByNormalizedName Post Method
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

                ApplicationRole role = _dbContext.Roles
                    .Include("RoleClaims")
                    .Where(x => x.NormalizedName.Trim().ToUpper() == input.Trim().ToUpper())
                    .FirstOrDefault();

                jsonString = JsonConvert.SerializeObject(role, new JsonSerializerSettings()
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
