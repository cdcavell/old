﻿using System.Collections.Generic;

namespace dis5_cdcavell.Models.Consent
{
    /// <summary>
    /// Consent View Model
    /// &lt;br /&gt;&lt;br /&gt;
    /// Copyright (c) Duende Software. All rights reserved.
    /// See https://duendesoftware.com/license/identityserver.pdf for license information. 
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |~ 
    /// </revision>
    public class ConsentViewModel : ConsentInputModel
    {
        /// <value>string</value>
        public string ClientName { get; set; }
        /// <value>string</value>
        public string ClientUrl { get; set; }
        /// <value>string</value>
        public string ClientLogoUrl { get; set; }
        /// <value>bool</value>
        public bool AllowRememberConsent { get; set; }

        /// <value>IEnumerable&lt;ScopeViewModel&gt;</value>
        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; }
        /// <value>IEnumerable&lt;ScopeViewModel&gt;</value>
        public IEnumerable<ScopeViewModel> ApiScopes { get; set; }
    }
}
