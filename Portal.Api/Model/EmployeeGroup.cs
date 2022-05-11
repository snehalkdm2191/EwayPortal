using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Portal.Api.Model
{
    public partial class EmployeeGroup
    {
        public EmployeeGroup()
        {
            ContentGroups = new HashSet<ContentGroup>();
            Employees = new HashSet<Employee>();
        }

        public Guid EmployeeGroupId { get; set; }

        public string EmployeeGroupName { get; set; }

        [JsonIgnore]
        public virtual ICollection<ContentGroup> ContentGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
