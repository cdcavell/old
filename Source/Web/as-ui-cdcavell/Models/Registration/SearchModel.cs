using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace as_ui_cdcavell.Models.Registration
{
    /// <summary>
    /// Administration Model
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class SearchModel
    {
        private string _searchRequest;
        /// <value>string</value>
        public string SearchRequest
        {
            get => _searchRequest;
            set { _searchRequest = HttpUtility.UrlEncode((value ?? string.Empty).Trim().Clean()); }

        }
        /// <value>SearchResultModel</value>
        public SearchResultModel SearchResult { get; set; } = new SearchResultModel();
    }
}
