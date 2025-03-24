using System.ComponentModel.DataAnnotations;

namespace LibMan.Entities;

public class Book
{
    public int Id {get; set;}

    [Required]
    [MaxLength(50)]
    public string? Title {get; set;}

    [Required]
    [MaxLength(20)]
    public string? ISBN {get; set;}

    public Author? Author {get; set;}
    
    [Required]
    public Category Category {get; set;}

    public bool IsAvailable {get; set;}

    public string? CoverImageUrl {get; set;}

}
