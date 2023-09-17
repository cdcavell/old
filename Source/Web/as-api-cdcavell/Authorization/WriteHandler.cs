using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace as_api_cdcavell.Authorization
{
    /// <summary>
    /// Write Handler
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.3.0 | 01/31/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class WriteHandler : AuthorizationHandler<WriteRequirement>
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <method>WriteHandler()</method>
        public WriteHandler()
        {
        }

        /// <summary>
        /// Handle Requirement method
        /// </summary>
        /// <param name="context">AuthorizationHandlerContext</param>
        /// <param name="requirement">AuthenticatedRequirement</param>
        /// <method>HandleRequirementAsync(AuthorizationHandlerContext context, WriteRequirement requirement)</method>
        /// <returns>Task</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WriteRequirement requirement)
        {
            var user = context.User;
            Claim writeClaim = user.Claims.Where(x => x.Type == "scope")
                .Where(x => x.Value == "Authorization.Service.API.Write")
                .FirstOrDefault();

            if (writeClaim != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
