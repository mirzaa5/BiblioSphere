using System;
using LibMan.Entities;
using LibMan.Data;
using Microsoft.AspNetCore.Http;

namespace libMan.Services.BookService;

public class BookService : IBookService
{
    IBookRepositary _bookRepositary;

    public BookService(IBookRepositary bookRepositary)
    {
        _bookRepositary = bookRepositary;
    }
    
    public List<Book> GetAvailableBooksForRental()
    {
        return _bookRepositary.GetAll()
                                .Where( b => b.IsAvailable == true)
                                .ToList();
                        
    }

    public Book Save(Book book, IFormFile? CoverImage)
    {
        if(book.Id == 0)
        {
            return _bookRepositary.Add(book);
        }

        else{
           return _bookRepositary.Update(book);
        }
    }

    public List<Book> GetAllBooks()
    {
       return  _bookRepositary.GetAll().ToList();
    }

}
