using System;
using System.ComponentModel.DataAnnotations;

namespace LibMan.Entities.Rental;

public class BookRental
{
    
    public int Id { get; set; }

    //Which book is rented
    
    public Book Book { get; set; }
    
    //Who rented the book
    public Member Member { get; set; }

    //When the book was rented
    public DateTimeOffset RentalDate { get; set; }

    //When the book is due to be returned
    //7 days from the rental date
    public DateTimeOffset ReturnDate { get; set; }

    //When the book was actually returned
    public DateTimeOffset? ActualReturnDate { get; set; }
}
