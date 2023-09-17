namespace dis5_cdcavell.Models.AppSettings
{
    /// <summary>
    /// reCAPTCHA Authentication model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class reCAPTCHA
    {
        /// <value>string</value>
        public string SiteKey { get; set; }
        /// <value>string</value>
        public string SecretKey { get; set; }
    }
}
