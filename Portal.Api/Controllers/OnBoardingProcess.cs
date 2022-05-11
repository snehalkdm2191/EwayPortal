using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YellowPage.Api.Models;

public class OnBoardingProcess
{
    [Key]
    public int Id { get; set; }
    
    public string RoleName { get; set; }

    public string ProcessName { get; set; }
    
    public bool IsComplete { get; set; }
    
    [JsonIgnore]
    [ForeignKey("EmployeId")]
    public virtual int EmployeId { get; set; }

}