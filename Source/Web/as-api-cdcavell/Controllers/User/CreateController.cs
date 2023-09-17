using as_api_cdcavell.Data;
using as_api_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace as_api_cdcavell.Controllers.User
{
    /// <class>CreateController</class>
    /// <summary>
    /// Identity User CreateAsync Controller Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [Route("User/[controller]")]
    public class CreateController : ApplicationBaseController<CreateController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;CreateController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="authorizationService">IAuthorizationService</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="dbContext">AuthorizationServiceDbContext</param>
        /// <method>
        /// public CreateController(
        ///     ILogger&lt;CreateController&gt; logger,
        ///     IWebHostEnvironment webHostEnvironment,
        ///     IHttpContextAccessor httpContextAccessor,
        ///     IAuthorizationService authorizationService,
        ///     AppSettings appSettings,
        ///     AuthorizationServiceDbContext dbContext
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        /// </method>
        public CreateController(
            ILogger<CreateController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService,
            AppSettings appSettings,
            AuthorizationServiceDbContext dbContext
        ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)
        {
        }

        /// <summary>
        /// Create Post Method
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

                    _dbContext.Users.Add(input);
                    _dbContext.SaveChanges();
                    dbContextTransaction.Commit();

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
