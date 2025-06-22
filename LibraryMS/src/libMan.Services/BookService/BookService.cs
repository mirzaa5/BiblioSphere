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

    public async Task<List<Book>> GetAllBooksAsync()
    {
         return await _bookRepositary.GetAllAsync();  // No need to convert it into the list, repositary is already returning it as list

    }

    public Book GetBookById(int id)
    {
        return _bookRepositary.GetById(id);
    }

    public Book Delete(int id)
    {
        var book = _bookRepositary.GetById(id);
        try{
            return _bookRepositary.Delete(book);
        }
        
        catch(Exception)
        {
            throw new Exception("Book with this Id was not found!");
        }  

    }  
}
