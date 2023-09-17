using CDCavell.ClassLibrary.Commons.Logging;
using CDCavell.ClassLibrary.Web.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class CustomRoleManager : RoleManager<ApplicationRole>, IDisposable 
    {
        private CustomRoleStore _customRoleStore;
        private Logger _logger;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="store">IRoleStore&lt;ApplicationRole&gt;</param>
        /// <param name="roleValidators">IEnumerable&lt;IRoleValidator&lt;ApplicationRole&gt;&gt;</param>
        /// <param name="keyNormalizer">ILookupNormalizer</param>
        /// <param name="errors">IdentityErrorDescriber</param>
        /// <param name="logger">ILogger&lt;CustomRoleManager&gt;</param>
        /// <method>
        /// CustomUserManager(
        ///     IRoleStore&lt;ApplicationRole&gt; store,
        ///     IEnumerable&lt;IRoleValidator&lt;ApplicationRole&gt;&gt; roleValidators,
        ///     ILookupNormalizer keyNormalizer,
        ///     IdentityErrorDescriber errors,
        ///     ILogger&lt;CustomRoleManager&gt; logger
        ///) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        /// </method>
        public CustomRoleManager(
            IRoleStore<ApplicationRole> store,
            IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, 
            ILogger<CustomRoleManager> logger
        ) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
            _customRoleStore = (CustomRoleStore)store;
            _logger = new Logger(logger);
        }

        /// <summary>
        /// Custom GetUsersAsync Method
        /// </summary>
        /// <param name="roleId">string</param>
        /// <param name="roleClaimId">int</param>
        /// <returns>Task&lt;List&lt;ApplicationUser&gt;&gt;</returns>
        /// <method>GetUsersAsync(string roleId, int roleClaimId)</method>
        public async Task<List<ApplicationUser>> GetUsersAsync(string roleId, int roleClaimId)
        {
            return await _customRoleStore.GetUsersAsync(roleId.Clean(), roleClaimId);
        }

        /// <summary>
        /// Custom GetApprovedUsersAsync Method
        /// </summary>
        /// <param name="roleId">string</param>
        /// <param name="roleClaimId">int</param>
        /// <returns>Task&lt;List&lt;ApplicationUser&gt;&gt;</returns>
        /// <method>GetApprovedUsersAsync(string roleId, int roleClaimId)</method>
        public async Task<List<ApplicationUser>> GetApprovedUsersAsync(string roleId, int roleClaimId)
        {
            return await _customRoleStore.GetApprovedUsersAsync(roleId.Clean(), roleClaimId);
        }
    }
}
