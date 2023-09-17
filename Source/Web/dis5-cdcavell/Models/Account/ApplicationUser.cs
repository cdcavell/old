using CDCavell.ClassLibrary.Web.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace dis5_cdcavell.Models.Account
{
    /// <summary>
    /// Duende IdentityServer5 Application User
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.5.0 | 01/16/2021 | Initial build |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class OldApplicationUser : IdentityUser
    {
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
        [ForeignKey("ApprovedById")]
        public virtual ApplicationUser ApprovedBy { get; set; }

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
        [ForeignKey("RevokedById")]
        public virtual ApplicationUser RevokedBy { get; set; }


        [NotMapped]
        public string FullName 
        {
            get 
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                return textInfo.ToTitleCase((FirstName.Trim() + " " + LastName.Trim()).Trim());
            }
        }

        [NotMapped]
        public bool IsActive
        {
            get
            {
                if (RequestDate > (DateTime?)DateTime.MinValue)
                    if (EmailConfirmed)
                        if (ApprovedDate > (DateTime?)DateTime.MinValue)
                            if (RevokedDate == (DateTime?)DateTime.MinValue)
                                if (!LockoutEnabled || (DateTime.Now > (LockoutEnd ?? (DateTime?)DateTime.MinValue)))
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
    }
}
