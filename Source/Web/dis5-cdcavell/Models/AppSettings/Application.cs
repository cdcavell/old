namespace dis5_cdcavell.Models.AppSettings
{
    /// <summary>
    /// Application model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |~ 
    /// | Christopher D. Cavell | 1.0.3.0 | 02/02/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.0.4.3 | 03/21/2021 | 2FA using TOTP |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class Application
    {
        /// <value>string</value>
        public string MainSiteUrl { get; set; }

        /// <value>string</value>
        public string MainSiteUrlTrim
        {
            get { return this.MainSiteUrl.TrimEnd('/').TrimEnd('\\'); }
        }

        /// <value>string</value>
        public string ApiUrl { get; set; }

        /// <value>string</value>
        public string ApiUrlTrim
        {
            get { return this.ApiUrl.TrimEnd('/').TrimEnd('\\'); }
        }

        /// <value>string</value>
        public string UiUrl { get; set; }

        /// <value>string</value>
        public string UiUrlTrim
        {
            get { return this.UiUrl.TrimEnd('/').TrimEnd('\\'); }
        }

        /// <value>string</value>
        public string ISDUrl { get; set; }

        /// <value>string</value>
        public string ISDUrlTrim
        {
            get { return this.ISDUrl.TrimEnd('/').TrimEnd('\\'); }
        }

        /// <value>string</value>
        public string RTCUrl { get; set; }

        /// <value>string</value>
        public string RTCUrlTrim
        {
            get { return this.RTCUrl.TrimEnd('/').TrimEnd('\\'); }
        }
    }
}
