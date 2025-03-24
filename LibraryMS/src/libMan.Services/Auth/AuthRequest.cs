using System.ComponentModel.DataAnnotations;

public class AuthRequest
{
    [EmailAddress]
    [Required]
    public string Email {get; set;}
    [Required]
    public string Password {get;set;}

}