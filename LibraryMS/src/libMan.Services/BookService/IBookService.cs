using System;
using LibMan.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Abstractions;

namespace libMan.Services.BookService;

public interface IBookService
{
     Book Save(Book book, IFormFile? CoverImage);
     List<Book> GetAvailableBooksForRental();

     List<Book> GetAllBooks();
}
