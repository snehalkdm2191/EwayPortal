using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YellowPage.Api.Models;

public class Contact
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    [JsonIgnore]
    [ForeignKey("EmployeId")]
    public virtual int EmployeId { get; set; }
    
}
