using System.ComponentModel.DataAnnotations;
//This library provides attributes that can be applied to model properties to enforce validation rules and define metadata.
namespace LibMan.Entities;

public class User
{
    public int Id {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public string Email {get; set;}
    [Required]
    public string Password {get; set;}

}
