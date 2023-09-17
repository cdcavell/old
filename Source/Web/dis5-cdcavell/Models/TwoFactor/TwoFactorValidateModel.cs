using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace dis5_cdcavell.Models.TwoFactor
{
    /// <summary>
    /// Two-Factor Validate model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>    
    public class TwoFactorValidateModel
    {
        /// <value>string</value>>
        public string Email { get; set; }
        /// <value>string</value>>
        public string Provider { get; set; }
        /// <value>string</value>>
        public string ProviderUserId { get; set; }
        /// <value>string</value>>
        public string SessionId { get; set; }
        /// <value>string</value>>
        public string AuthenticationToken { get; set; }
        /// <value>string</value>>
        public string ReturnUrl { get; set; }
        ///// <value>string</value>
        public string TotpCode { get; set; }
    }
}
