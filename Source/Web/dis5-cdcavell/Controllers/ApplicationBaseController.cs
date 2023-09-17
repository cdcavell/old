using CDCavell.ClassLibrary.Web.Mvc.Controllers;
using dis5_cdcavell.Filters;
using dis5_cdcavell.Models.AppSettings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dis5_cdcavell.Controllers
{
    /// <class>ApplicationBaseController</class>
    /// <summary>
    /// Base controller class for application
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.2.0 | 01/16/2020 | Initial build |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    [ServiceFilter(typeof(SecurityHeadersAttribute))]
    public abstract partial class ApplicationBaseController<T> : WebBaseController<ApplicationBaseController<T>> where T : ApplicationBaseController<T>
    {
        protected readonly AppSettings _appSettings;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>ApplicationBaseController(
        /// ILogger&lt;T&gt; logger, 
        /// IWebHostEnvironment webHostEnvironment, 
        /// IHttpContextAccessor httpContextAccessor, 
        /// AppSettings appSettings
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
