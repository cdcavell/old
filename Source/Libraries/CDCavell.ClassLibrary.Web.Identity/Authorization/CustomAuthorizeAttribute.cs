using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CDCavell.ClassLibrary.Web.Identity.Authorization
{
    /// <summary>
    /// CustomAuthorizeAttribute Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/02/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// CustomAuthorizeAttribute method
        /// </summary>
        /// <param name="Permissions">string</param>
        /// <method>CustomAuthorizeAttribute(string Permissions) : base(typeof(CustomAuthorizeFilter))</method>
        public CustomAuthorizeAttribute(string Permissions) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = new object[] { Permissions.Split(',').ToList() };
        }
    }
}
