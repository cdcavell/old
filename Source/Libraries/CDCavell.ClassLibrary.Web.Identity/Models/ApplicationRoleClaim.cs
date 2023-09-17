using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDCavell.ClassLibrary.Web.Identity.Models
{
    /// <summary>
    /// Instance of Microsoft IdentityRoleClaim Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/05/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        /// <value>Role</value>
        [ForeignKey("RoleId")]
        public ApplicationRole Role { get; set; }
        /// <value>string</value>
        [NotMapped]
        public string NormalizedClaimType { get { return ClaimType.Trim().ToUpper(); } }
        /// <value>string</value>
        [NotMapped]
        public string NormalizedClaimValue { get { return ClaimValue.Trim().ToUpper(); } }
    }
}
