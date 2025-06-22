using System;
using System.Text;
using LibMan.Entities.Rental;
using Microsoft.EntityFrameworkCore;

namespace LibMan.Data.Rentals;

public class RentalRepository : IRentalRepository
{
    readonly LibDbContext _context;

    public RentalRepository(LibDbContext context)
    {
        _context = context;

    }
    public BookRental Add(BookRental entity)
    {
        if(_context.BookRentals.Any(r => r.Book.Id == entity.Book.Id  && r.ReturnDate == null))
        {
            throw new Exception("Book i already rented by another user");
        }
        _context.BookRentals.Add(entity);
        _context.SaveChanges();
        
        return entity;
    }

    public BookRental Delete(BookRental entity)
    {
        throw new NotImplementedException();
    }

    public List<BookRental> GetAll()
    {
        return _context.BookRentals.Include(r => r.Book)
                                    .Include(r => r.Member).ToList();
    }

    public BookRental GetById(int id)
    {
        var bookRental = _context.BookRentals?.Include(r =>  r.Book)
                                              .Include(r =>r.Member)
                                              .FirstOrDefault(r => r.Id == id);
        if(bookRental == null)
        {
            throw new Exception($"Book Rental with Id {id} was not Found!");
        }
        return bookRental;
    }

    public List<BookRental> GetRentalHistoryByBook(int bookId)
    {
        var history = _context.BookRentals.Include(d => d.Book)
                                          .Include(d => d.Member)
                                          .Where(r => r.Book.Id == bookId).ToList();
        return history;
    }

    public List<BookRental> GetRentalHistoryByMember(int memberId)
    {
        var history = _context.BookRentals.Include(d => d.Book)
                                          .Include(d => d.Member)
                                          .Where(r => r.Member.Id == memberId).ToList();
        return history;
    }

    public BookRental Update(BookRental entity)
    {
        if(entity.ActualReturnDate != null)
        {
            throw new Exception("The book is already returned!");
        }
        entity.ActualReturnDate = DateTime.UtcNow;
        _context.SaveChanges();
        return entity;
    }
}
