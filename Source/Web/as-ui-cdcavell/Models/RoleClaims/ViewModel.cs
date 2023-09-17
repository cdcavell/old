using CDCavell.ClassLibrary.Web.Identity.Models;
using System.Collections.Generic;

namespace as_ui_cdcavell.Models.RoleClaims
{
    /// <summary>
    /// View Model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.3 | 06/30/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class ViewModel
    {
        /// <value>List&lt;ApplicationRole&gt;</value>
        public List<ApplicationRole> Roles { get; set; }
        /// <value>List&lt;ApplicationUser&gt;</value>
        public List<ApplicationUser> Users { get; set; }
        /// <value>string</value>
        public string RoleDescription { get; set; }
        /// <value>string</value>
        public string RoleId { get; set; }
        /// <value>string</value>
        public string ClaimDescription { get; set; }
        /// <value>string</value>
        public int ClaimId { get; set; }
        /// <value>string</value>
        public string RevokeId { get; set; }
    }
}
