using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Portal.Api.Model
{
    public partial class EmployeeContent
    {
        public Guid EmployeeContentId { get; set; }
        public Guid? Employeeid { get; set; }
        public Guid? ContentGroupId { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public virtual ContentGroup ContentGroup { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
    }
}
