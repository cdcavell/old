using as_ui_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Identity.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace as_ui_cdcavell.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class HomeController : ApplicationBaseController<HomeController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;HomeController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="userManager">CustomUserManager</param>
        /// <param name="appSettings">AppSettings</param>
        /// <param name="roleManager">CustomRoleManager</param>
        /// <method>
        /// HomeController(
        ///     ILogger&lt;HomeController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings,
        ///     CustomUserManager userManager,
        ///     CustomRoleManager roleManager
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        /// </method>
        public HomeController(
            ILogger<HomeController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings,
            CustomUserManager userManager,
            CustomRoleManager roleManager
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)
        {
        }
    }
}
