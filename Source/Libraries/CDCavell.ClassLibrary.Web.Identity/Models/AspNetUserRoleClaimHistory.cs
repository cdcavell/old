using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CDCavell.ClassLibrary.Web.Identity.Models.AspNetUserRoleClaim;

namespace CDCavell.ClassLibrary.Web.Identity.Models
{
    /// <summary>
    /// Custom UserRoleClaimHistory Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [Table("AspNetUserRoleClaimHistories")]
    public class AspNetUserRoleClaimHistory
    {
        /// <value>string</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        /// <value>string</value>
        [Required]
        public string UserRoleClaimId { get; set; }
        /// <value>UserRoleClaim</value>
        [ForeignKey("UserRoleClaimId")]
        public AspNetUserRoleClaim UserRoleClaim { get; set; }
        /// <value>DateTime</value>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ActionOn { get; set; }

        /// <value>string</value>
        [Required]
        public string ActionById { get; set; }
        /// <value>ApplicationUser</value>
        [ForeignKey("ActionById")]
        public ApplicationUser ActionBy { get; set; }
        /// <value>RoleClaimStatus</value>
        [Required]
        public RoleClaimStatus Status { get; set; }
    }
}
