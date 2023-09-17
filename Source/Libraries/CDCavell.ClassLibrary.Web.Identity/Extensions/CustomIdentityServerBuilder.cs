using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CDCavell.ClassLibrary.Web.Identity.Extensions
{
    /// <summary>
    /// CustomIdentityServerBuilder Options Extension
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public static class CustomIdentityServerBuilder
    {
        /// <summary>
        /// Add CustomUserStore Options Extention
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection</param>
        /// <param name="options">Action&lt;CustomUserStoreOptions&gt;</param>
        /// <method>AddCustomUserStore(this IServiceCollection serviceCollection, Action&lt;CustomUserStoreOptions&gt; options)</method>
        public static IServiceCollection AddCustomUserStore(this IServiceCollection serviceCollection, Action<CustomUserStoreOptions> options)
        {
            serviceCollection.AddScoped<IUserStore<ApplicationUser>, CustomUserStore>();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), @"Missing required options for CustomUserStore.");
            }
            serviceCollection.Configure(options);
            return serviceCollection;
        }

        /// <summary>
        /// Add CustomRoleStore Options Extention
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection</param>
        /// <param name="options">Action&lt;CustomRoleStoreOptions&gt;</param>
        /// <method>AddCustomRoleStore(this IServiceCollection serviceCollection, Action&lt;CustomRoleStoreOptions&gt; options)</method>
        public static IServiceCollection AddCustomRoleStore(this IServiceCollection serviceCollection, Action<CustomRoleStoreOptions> options)
        {
            serviceCollection.AddScoped<IRoleStore<ApplicationRole>, CustomRoleStore>();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), @"Missing required options for CustomRoleStore.");
            }
            serviceCollection.Configure(options);
            return serviceCollection;
        }
    }
}
