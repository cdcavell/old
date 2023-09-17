using rtc_cdcavell.Filters;
using rtc_cdcavell.Models.AppSettings;
using CDCavell.ClassLibrary.Web.Identity.Services;
using CDCavell.ClassLibrary.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace rtc_cdcavell.Controllers
{
    /// <class>ApplicationBaseController</class>
    /// <summary>
    /// Base controller class for application
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |~ 
    /// </revision>
    [ServiceFilter(typeof(SecurityHeadersAttribute))]
    public abstract partial class ApplicationBaseController<T> : WebBaseController<ApplicationBaseController<T>> where T : ApplicationBaseController<T>
    {
        /// <value>CustomUserManager</value>
        protected readonly CustomUserManager _userManager;
        /// <value>CustomRoleManager</value>
        protected readonly CustomRoleManager _roleManager;
        /// <value>AppSettings</value>
        protected readonly AppSettings _appSettings;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// ApplicationBaseController(
        ///     ILogger&lt;T&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings
        /// ) : base(logger, webHostEnvironment, httpContextAccessor)
        /// </method>
        protected ApplicationBaseController(
            ILogger<T> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings
        ) : base(logger, webHostEnvironment, httpContextAccessor)
        {
            _appSettings = appSettings;
        }
    }
}
