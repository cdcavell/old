using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace CDCavell.ClassLibrary.Web.Identity.Models
{
    /// <summary>
    /// Instance of Microsoft IdentityUser Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class ApplicationUser : IdentityUser<string> 
    {
        /// <value>string</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }
        /// <value>string</value>
        [AllowNull]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <value>string</value>
        [AllowNull]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <value>DateTime?</value>
        [AllowNull]
        [DataType(DataType.DateTime)]
        [Display(Name = "Request Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? RequestDate { get; set; } = DateTime.MinValue;

        /// <value>DateTime?</value>
        [AllowNull]
        [DataType(DataType.DateTime)]
        [Display(Name = "Approved Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ApprovedDate { get; set; } = DateTime.MinValue;

        /// <value>string</value>
        [AllowNull]
        public string ApprovedById { get; set; }
        /// <value>ApplicationUser</value>
        [AllowNull]
        [ForeignKey("ApprovedById")]
        public ApplicationUser ApprovedBy { get; set; }

        /// <value>DateTime?</value>
        [AllowNull]
        [DataType(DataType.DateTime)]
        [Display(Name = "Revoked Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? RevokedDate { get; set; } = DateTime.MinValue;

        /// <value>string</value>
        [AllowNull]
        public string RevokedById { get; set; }
        /// <value>ApplicationUser</value>
        [AllowNull]
        [ForeignKey("RevokedById")]
        public ApplicationUser RevokedBy { get; set; }


        /// <value>ICollection&lt;IdentityUserClaim&lt;string&gt;&gt;</value>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();
        /// <value>ICollection&lt;IdentityUserLogin&lt;string&gt;&gt;</value>
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new List<IdentityUserLogin<string>>();
        /// <value>ICollection&lt;IdentityUserToken&lt;string&gt;&gt;</value>
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; } = new List<IdentityUserToken<string>>();
        /// <value>ICollection&lt;IdentityUserRole&lt;string&gt;&gt;</value>
        public virtual ICollection<AspNetUserRoleClaim> RoleClaims { get; set; } = new List<AspNetUserRoleClaim>();


        /// <value>string</value>
        [NotMapped]
        public string FullName
        {
            get
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                return textInfo.ToTitleCase(((FirstName ?? string.Empty).Trim() + " " + (LastName ?? string.Empty).Trim()).Trim());
            }
        }

        /// <value>bool</value>
        [NotMapped]
        public bool IsSysAdmin
        {
            get
            {
                return HasRoleClaim("SysAdmin:SysAdmin");
            }
        }

        /// <value>bool</value>
        [NotMapped]
        public bool IsActive
        {
            get
            {
                if (RequestDate > (DateTime?)DateTime.MinValue)
                    if (EmailConfirmed)
                        if (ApprovedDate > (DateTime?)DateTime.MinValue)
                            if (RevokedDate == (DateTime?)DateTime.MinValue)
                                if ((DateTime.Now > (LockoutEnd ?? (DateTime?)DateTime.MinValue)))
                                    return true;

                return false;
            }
        }

        /// <value>bool</value>
        [NotMapped]
        public bool IsPending
        {
            get
            {
                if (RequestDate > (DateTime?)DateTime.MinValue)
                    if (EmailConfirmed)
                        if (ApprovedDate == (DateTime?)DateTime.MinValue)
                            if (RevokedDate == (DateTime?)DateTime.MinValue)
                                return true;

                return false;
            }
        }

        /// <value>bool</value>
        [NotMapped]
        public bool IsRevoked
        {
            get
            {
                if (RevokedDate > (DateTime?)DateTime.MinValue)
                    return true;

                return false;
            }
        }

        /// <value>string</value>
        [NotMapped]
        public string Status
        {
            get
            {
                if (IsActive)
                    return "Account Active";

                if (IsRevoked)
                    return "Account Revoked";

                if (LockoutEnabled)
                    return "Account Lockedout";

                if (IsPending)
                    return "Pending Approval";

                if (!EmailConfirmed)
                    return "Pending Validation";

                return "Not Registered";
            }
        }

        /// <summary>
        /// Validate if user has RoleClaim
        /// </summary>
        /// <param name="roleClaims">string</param>
        /// <returns>bool</returns>
        public bool HasRoleClaim(string roleClaims)
        {
            if (string.IsNullOrEmpty(roleClaims))
                return false;

            var checkRoleClaims = roleClaims.Split(',');
            foreach (string item in checkRoleClaims)
            {
                var checkRoleClaim = item.Split(':');
                if (checkRoleClaim.Count() == 2)
                {
                    List<string> checkRoles = new List<string>();
                    checkRoles.Add("SYSADMIN");
                    checkRoles.Add(checkRoleClaim[0].Trim().ToUpper());

                    List<string> checkClaims = new List<string>();
                    checkClaims.Add("SYSADMIN");
                    checkClaims.Add(checkRoleClaim[1].Trim().ToUpper());

                    var userRoleClaim = this.RoleClaims
                        .Where(x => checkRoles.Contains(x.Role?.NormalizedName ?? string.Empty))
                        .Where(x => checkClaims.Contains(x.RoleClaim?.NormalizedClaimType ?? string.Empty))
                        .Where(x => x.RoleClaim.NormalizedClaimValue == "ACTIVE")
                        .Where(x => x.Status == AspNetUserRoleClaim.RoleClaimStatus.Approved)
                        .FirstOrDefault();

                    if (userRoleClaim != null)
                        return true;
                }
            }

            return false;
        }

    }
}
