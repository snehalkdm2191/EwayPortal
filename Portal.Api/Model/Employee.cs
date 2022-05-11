using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Portal.Api.Model
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeContents = new HashSet<EmployeeContent>();
        }

        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string Gender { get; set; }
        
        public string Education { get; set; }
        
        [Required]
        public Guid? EmployeeGroupId { get; set; }

        [JsonIgnore]
        public virtual EmployeeGroup EmployeeGroup { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeContent> EmployeeContents { get; set; }
    }
}
