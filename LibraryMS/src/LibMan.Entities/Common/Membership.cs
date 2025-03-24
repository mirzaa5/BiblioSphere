namespace LibMan.Entities;

public class Membership
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int MaxBooksPerMonth {get; set;}
    public float PricePerYear {get; set;}
    public int MaxActiveRentals {get; set;} = 1;
}
