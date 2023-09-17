using System;
using System.Collections.Generic;

namespace rtc_cdcavell.Models.Account
{
    /// <summary>
    /// Captcha response model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |~ 
    /// </revision>
    public class CaptchaResponse
    {
        /// <value>bool</value>
        public bool success { get; set; }
        /// <value>DateTime</value>
        public DateTime challenge_ts { get; set; }
        /// <value>string</value>
        public string hostname { get; set; }
        /// <value>double</value>
        public double score { get; set; }
        /// <value>string</value>
        public string action { get; set; }
        /// <value>object[]</value>
        public object[] ErrorCodes { get; set; }
    }
}
