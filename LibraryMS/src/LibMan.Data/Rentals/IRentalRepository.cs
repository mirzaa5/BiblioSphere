using System;
using LibMan.Entities.Rental;

namespace LibMan.Data.Rentals;

public interface IRentalRepository : IRepositary<BookRental>
{

    List<BookRental> GetRentalHistoryByBook(int bookId);
    List<BookRental> GetRentalHistoryByMember(int memberId);

}
