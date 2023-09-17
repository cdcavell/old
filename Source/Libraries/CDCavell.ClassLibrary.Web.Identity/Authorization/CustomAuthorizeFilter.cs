using CDCavell.ClassLibrary.Commons.Logging;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Services.AppSettings;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CDCavell.ClassLibrary.Web.Identity.Authorization
{
    /// <summary>
    /// CustomAuthorizeFilter Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        private readonly Logger _logger;
        private readonly IAppSettingsService _appSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly List<string> _permissions;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;CustomAuthorizeFilter&gt;</param>
        /// <param name="appSettings">IAppSettingsService</param>
        /// <param name="userManager">UserManager&lt;ApplicationUser&gt;</param>
        /// <param name="permissions">List&lt;string&gt;</param>
        /// <method>
        /// CustomAuthorizeFilter(
        ///     ILogger&lt;CustomAuthorizeFilter&gt; logger,
        ///     IAppSettingsService appSettings,
        ///     UserManager&lt;ApplicationUser&gt; userManager,
        ///     List&lt;string&gt; permissions
        /// ) 
        /// </method>
        public CustomAuthorizeFilter(
            ILogger<CustomAuthorizeFilter> logger,
            IAppSettingsService appSettings,
            UserManager<ApplicationUser> userManager,
            List<string> permissions
        )
        {
            _logger = new Logger(logger);
            _appSettings = appSettings;
            _userManager = userManager;
            _permissions = permissions;
        }

        /// <summary>
        /// OnAuthorization method
        /// </summary>
        /// <param name="context">AuthorizationFilterContext</param>
        /// <method>OnAuthorization(AuthorizationFilterContext context)</method>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_permissions.Count > 0)
            {
                var subject = context.HttpContext.User.Claims
                    .Where(x => x.Type == JwtClaimTypes.Subject)
                    .Select(x => x.Value)
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(subject))
                {
                    ApplicationUser user = _userManager.FindByIdAsync(subject.Clean()).Result;
                    if (user != null)
                    {
                        foreach (string item in _permissions)
                        {
                            if (user.HasRoleClaim(item))
                                return;
                        }
                    }
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
