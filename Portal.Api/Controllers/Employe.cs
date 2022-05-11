using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YellowPage.Api.Models;

public class Employe
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string RoleName { get; set; }

    public virtual List<Contact> Contacts {get; set;}
    
    public virtual List<OnBoardingProcess> Process {get; set;}

}
