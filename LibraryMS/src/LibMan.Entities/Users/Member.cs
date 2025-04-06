
using System.ComponentModel.DataAnnotations;    
namespace LibMan.Entities;

public class Member : User
{
    [Required]
    public string? GovtId {get; set;}
    public string? PhoneNumber {get; set;}
    public Membership? MemberShip{get; set;}

}
