namespace CDCavell.ClassLibrary.Web.Identity.Services
{
    /// <summary>
    /// CustomUserStore Service Options
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class CustomUserStoreOptions
    {
        /// <value>string</value>
        public string ISDBaseUrl { get; set; }
        /// <value>string</value>
        public string ApiBaseUrl { get; set; }
        /// <value>string</value>
        public string ApiAccessToken { get; set; }
    }
}
