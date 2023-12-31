﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace as_api_cdcavell.Data
{
    /// <summary>
    /// CDCavell AuditEntry record
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.3.0 | 01/18/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/05/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class AuditEntry
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="entry">EntityEntry</param>
        /// <method>AuditEntry(EntityEntry entry)</method>
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        /// <value>EntityEntry</value>
        public EntityEntry Entry { get; }
        /// <value>string</value>
        [DataType(DataType.Text)]
        public string TableName { get; set; }
        /// <value>string</value>
        [DataType(DataType.Text)]
        public string State { get; set; }
        /// <value>string</value>
        [DataType(DataType.Text)]
        public string Application { get; set; }
        /// <value>string</value>
        [DataType(DataType.Text)]
        public string ModifiedBy { get; set; }
        /// <value>DateTime</value>
        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }
        /// <value>Dictionary&lt;string, object&gt;</value>
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        /// <value>Dictionary&lt;string, object&gt;</value>
        public Dictionary<string, object> OriginalValues { get; } = new Dictionary<string, object>();
        /// <value>Dictionary&lt;string, object&gt;</value>
        public Dictionary<string, object> CurrentValues { get; } = new Dictionary<string, object>();
        /// <value>List&lt;PropertyEntry&gt;</value>
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        /// <value>bool</value>
        public bool HasTemporaryProperties => TemporaryProperties.Any();

        /// <summary>
        /// Audit History record to write
        /// </summary>
        /// <method>ToAuditHistory()</method>
        public AuditHistory ToAuditHistory()
        {
            string file = this.GetType().Assembly.Location;
            string app = System.IO.Path.GetFileNameWithoutExtension(file);

            var auditHistory = new AuditHistory();
            auditHistory.Entity = TableName;
            auditHistory.State = State;
            auditHistory.Application = string.IsNullOrEmpty(Application) ? app : Application;
            auditHistory.ModifiedBy = ModifiedBy;
            auditHistory.ModifiedOn = ModifiedOn;
            auditHistory.KeyValues = JsonConvert.SerializeObject(KeyValues);
            auditHistory.OriginalValues = OriginalValues.Count == 0 ? null : JsonConvert.SerializeObject(OriginalValues);
            auditHistory.CurrentValues = CurrentValues.Count == 0 ? null : JsonConvert.SerializeObject(CurrentValues);
            return auditHistory;
        }
    }
}
