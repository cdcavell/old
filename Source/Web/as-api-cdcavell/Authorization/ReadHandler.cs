using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace as_api_cdcavell.Authorization
{
    /// <summary>
    /// Read Handler
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.3.0 | 01/31/2020 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class ReadHandler : AuthorizationHandler<ReadRequirement>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <method>ReadHandler()</method>
        public ReadHandler()
        {
        }

        /// <summary>
        /// Handle Requirement method
        /// </summary>
        /// <param name="context">AuthorizationHandlerContext</param>
        /// <param name="requirement">AuthenticatedRequirement</param>
        /// <method>HandleRequirementAsync(AuthorizationHandlerContext context, ReadRequirement requirement)</method>
        /// <returns>Task</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadRequirement requirement)
        {
            var user = context.User;
            Claim readClaim = user.Claims.Where(x => x.Type == "scope")
                .Where(x => x.Value == "Authorization.Service.API.Read")
                .FirstOrDefault();

            if (readClaim != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
