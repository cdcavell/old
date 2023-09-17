using CDCavell.ClassLibrary.Web.Identity.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rtc_cdcavell.Models.AppSettings;

namespace rtc_cdcavell.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.2.0 | 07/06/2021 | SignalR streaming |~ 
    /// </revision>
    public class ChatController : ApplicationBaseController<ChatController>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;ChatController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// ChatController(
        ///     ILogger&lt;ChatController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor,
        ///     AppSettings appSettings
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        /// </method>
        public ChatController(
            ILogger<ChatController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AppSettings appSettings
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        {
        }

        /// <summary>
        /// Index HttpGet method
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Index()</method>
        [HttpGet]
        [CustomAuthorize("User:View, User:Edit")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
