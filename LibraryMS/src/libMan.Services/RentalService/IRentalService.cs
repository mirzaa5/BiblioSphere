using System;
using LibMan.Entities;
using LibMan.Entities.Rental;

namespace libMan.Services.RentalService;

public interface IRentalService
{
    BookRental RentBook (int bookId);
    BookRental ReturnBook(int rentalId);
    List<BookRental> GetRentalHistoryByBook(int bookId);
    List<BookRental> GetRentalHistoryByMember();
    List<BookRental> GetAllRentals();


}
