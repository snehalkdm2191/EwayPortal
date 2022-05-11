using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Portal.Api.Model
{
    public partial class ContentGroup
    {
        public ContentGroup()
        {
            EmployeeContents = new HashSet<EmployeeContent>();
        }

        public Guid ContentGroupId { get; set; }
        public Guid? ContentId { get; set; }
        public Guid? EmployeeGroupId { get; set; }

        [JsonIgnore]
        public virtual ContentMaster Content { get; set; }
        [JsonIgnore]
        public virtual EmployeeGroup EmployeeGroup { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeContent> EmployeeContents { get; set; }

    }
}
