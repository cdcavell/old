using CDCavell.ClassLibrary.Web.Identity.Models;
using System.Collections.Generic;

namespace as_ui_cdcavell.Models.Registration
{
    /// <summary>
    /// Administration Model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.1 | 06/07/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class AdministrationModel
    {
        /// <value>string</value>
        public string Action { get; set; } = string.Empty;
        /// <value>string</value>
        public string Id { get; set; }
        /// <value>List&lt;ApplicationUser&gt;</value>
        public List<ApplicationUser> PendingRegistrations { get; set; }
        /// <value>SearchModel</value>
        public SearchModel SearchModel { get; set; } = new SearchModel();
        /// <value>List&lt;ApplicationRole&gt;</value>
        public List<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();
        /// <value>string</value>
        public string RoleId { get; set; }
        /// <value>int</value>
        public int ClaimId { get; set; }
    }
}
