﻿namespace as_ui_cdcavell.Models.AppSettings
{
    /// <summary>
    /// AppSettings model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.3.0 | 01/30/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |~ 
    /// </revision>
    public class AppSettings : CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.AppSettings
    {
        /// <value>Application</value>
        public object Application { get; internal set; }
    }
}