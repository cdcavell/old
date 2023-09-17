using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDCavell.ClassLibrary.Web.Identity.Models
{
    /// <summary>
    /// Instance of Microsoft IdentityUserRoleClaim Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [Table("AspNetUserRoleClaims")]
    public class AspNetUserRoleClaim
    {
        /// <value>enum</value>
        public enum RoleClaimStatus
        {
            /// <value>0</value>
            Requested,
            /// <value>1</value>
            Approved,
            /// <value>2</value>
            Retired,
            /// <value>3</value>
            Rejected
        }

        /// <value>string</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        /// <value>string</value>
        public string UserId { get; set; }
        /// <value>ApplicationUser</value>
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        /// <value>string</value>
        public string RoleId { get; set; }
        /// <value>ApplicationRole</value>
        [ForeignKey("RoleId")]
        public ApplicationRole Role { get; set; }
        /// <value>int</value>
        public int RoleClaimId { get; set; }
        /// <value>ApplicationRoleClaim</value>
        [ForeignKey("RoleClaimId")]
        public ApplicationRoleClaim RoleClaim { get; set; }

        /// <value>RoleClaimStatus</value>
        public RoleClaimStatus Status { get; set; }
        /// <value>AspNetUserRoleClaimHistory</value>
        public virtual ICollection<AspNetUserRoleClaimHistory> History { get; set; } = new List<AspNetUserRoleClaimHistory>();
    }
}
