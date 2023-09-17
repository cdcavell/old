using CDCavell.ClassLibrary.Web.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace as_ui_cdcavell.Models.Registration
{
    /// <summary>
    /// Search Result Model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class SearchResultModel
    {
        /// <value>string</value>
        public string UserId { get; set; }
        /// <value>string</value>
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        /// <value>string</value>
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        /// <value>string</value>
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        /// <value>DateTime?</value>
        [DataType(DataType.DateTime)]
        [Display(Name = "Request Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? RequestDate { get; set; } = DateTime.MinValue;

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

        /// <value>string</value>
        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        /// <value>bool</value>
        public bool IsSelf { get; set; }
        /// <value>bool</value>
        public bool IsSysAdmin { get; set; }
        /// <value>bool</value>
        public bool IsActive { get; set; }

        /// <value>bool</value>
        public bool IsPending { get; set; }

        /// <value>bool</value>
        public bool IsRevoked { get; set; }

        /// <value>bool</value>
        public bool TwoFactorEnabled { get; set; }

        /// <value>List&lt;AspNetUserRoleClaim&gt;</value>
        public List<AspNetUserRoleClaim> RoleClaims { get; set; }
    }
}
