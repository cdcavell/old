namespace dis5_cdcavell.Models.AppSettings
{
    /// <summary>
    /// Site Administrator model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class EmailService
    {
        /// <value>string</value>
        public string Host { get; set; }
        /// <value>int</value>
        public int Port { get; set; }
        /// <value>bool</value>
        public bool EnableSsl { get; set; }
        /// <value>string</value>
        public string UserId { get; set; }
        /// <value>string</value>
        public string Password { get; set; }
        /// <value>string</value>
        public string Email { get; set; }
    }
}
