using System.ComponentModel.DataAnnotations;

namespace LibMan.Entities;

public class Author
{
    public int Id {get; set;}
    [Required]
    [RegularExpression("^[a-zA-Z0-9 ]+$")]
    public string? Name {get; set;}   
}
