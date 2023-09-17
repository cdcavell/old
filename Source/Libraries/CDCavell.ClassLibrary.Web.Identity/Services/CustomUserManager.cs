using CDCavell.ClassLibrary.Commons.Logging;
using CDCavell.ClassLibrary.Web.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CDCavell.ClassLibrary.Web.Identity.Services
{
    /// <summary>
    /// Custom UserManager Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 03/30/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class CustomUserManager : UserManager<ApplicationUser>, IDisposable 
    {
        private CustomUserStore _customUserStore;
        private Logger _logger;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="store">IUserStore&lt;ApplicationUser&gt;</param>
        /// <param name="optionsAccessor">IOptions&lt;ApplicationUser&gt;</param>
        /// <param name="passwordHasher">IPasswordHasher&lt;ApplicationUser&gt;</param>
        /// <param name="userValidators">IEnumerable&lt;IUserValidator&lt;ApplicationUser&gt;&gt;</param>
        /// <param name="passwordValidators">IEnumerable&lt;IPasswordValidator&lt;ApplicationUser&gt;&gt;</param>
        /// <param name="keyNormalizer">ILookupNormalizer</param>
        /// <param name="errors">IdentityErrorDescriber</param>
        /// <param name="services">IServiceProvider</param>
        /// <param name="logger">ILogger&lt;CustomUserManager&gt;</param>
        /// <method>
        /// CustomUserManager(
        ///     IUserStore&lt;ApplicationUser&gt; store,
        ///     IOptions&lt;IdentityOptions&gt; optionsAccessor,
        ///     IPasswordHasher&lt;ApplicationUser&gt; passwordHasher,
        ///     IEnumerable&lt;IUserValidator&lt;ApplicationUser&gt;&gt; userValidators,
        ///     IEnumerable&lt;IPasswordValidator&lt;ApplicationUser&gt;&gt; passwordValidators,
        ///     ILookupNormalizer keyNormalizer,
        ///     IdentityErrorDescriber errors,
        ///     IServiceProvider services,
        ///     ILogger&lt;CustomUserManager&gt; logger
        ///) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        /// </method>
        public CustomUserManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher, 
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, 
            IServiceProvider services,
            ILogger<CustomUserManager> logger
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _customUserStore = (CustomUserStore)store;
            _logger = new Logger(logger);
        }

        /// <summary>
        /// CustomUserStore GetPendingRegistrations Method
        /// </summary>
        /// <returns>Task&lt;List&lt;ApplicationUser&gt;&gt;</returns>
        /// <method>GetPendingRegistrations())</method>
        public async Task<List<ApplicationUser>> GetPendingRegistrations()
        {
            return await _customUserStore.GetPendingRegistrations(default(CancellationToken));
        }

        /// <summary>
        /// CustomUserStore GetRoleClaimHistory Method
        /// </summary>
        /// <returns>Task&lt;List&lt;AspNetUserRoleClaimHistory&gt;&gt;</returns>
        /// <method>GetRoleClaimHistory(string userRoleClaimId))</method>
        public async Task<List<AspNetUserRoleClaimHistory>> GetRoleClaimHistory(string userRoleClaimId)
        {
            return await _customUserStore.GetRoleClaimHistory(userRoleClaimId, default(CancellationToken));
        }
    }
}
