using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDCavell.ClassLibrary.Web.Identity.Models
{
    /// <summary>
    /// Instance of Microsoft IdentityUserRole Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        /// <value>ApplicationRole</value>
        [ForeignKey("RoleId")]
        public virtual ApplicationRole Role { get; set; }
    }
}
