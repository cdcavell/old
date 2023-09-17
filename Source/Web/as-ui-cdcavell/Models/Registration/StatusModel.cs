using CDCavell.ClassLibrary.Web.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace as_ui_cdcavell.Models.Registration
{
    /// <summary>
    /// Status Model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.1 | 06/05/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class StatusModel
    {
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
        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        /// <value>bool</value>
        public bool TwoFactorEnabled { get; set; }

        /// <value>List&lt;AspNetUserRoleClaim&gt;</value>
        public List<AspNetUserRoleClaim> RoleClaims { get; set; }
    }
}
