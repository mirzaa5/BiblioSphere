using System;
using System.Security.Claims;
using LibMan.Data.Rentals;
using LibMan.Entities;
using LibMan.Entities.Rental;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace libMan.Services.RentalService;

public class RentalService : IRentalService
{
     //HttpContextAccessor will contains the user details
    //IS the user is logged in or not
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRentalRepository  _rentalRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IBookRepositary _bookRepository;
    private readonly ILogger<RentalService> _logger;
    public RentalService(IHttpContextAccessor httpContextAccessor,
                         ILogger<RentalService> logger,
                         IRentalRepository rentalRepository,
                         IMemberRepository memberRepository,
                         IBookRepositary bookRepositary)
    {
        _httpContextAccessor = httpContextAccessor;
        _rentalRepository = rentalRepository;
        _logger = logger;
        _memberRepository = memberRepository;
        _bookRepository = bookRepositary;
    }
    public BookRental RentBook(int bookId)
    {
        //check who wants to rent a book

        var memberId = _httpContextAccessor
                       .HttpContext
                       .User
                       .FindFirst(ClaimTypes.NameIdentifier)?
                       .Value;

        //if the user is not logged in throw an exception
        if(memberId == null)
        {
            throw new Exception("User is not logged in");
        }

        //fetching member details
        var member = _memberRepository.GetById(int.Parse(memberId));

        //fetching book details
        var book = _bookRepository.GetById(bookId);

        //if book is not available throw in exception
        if(!book.IsAvailable)
        {
            throw new Exception("Book is not avaible for rental at this time");
        }

        //creating a new rental class
        var rental = new BookRental
        {
            Book = book,
            Member = member,
            RentalDate = DateTimeOffset.UtcNow,
            ReturnDate = DateTimeOffset.UtcNow.AddDays(14)

        };

        //Rent the book by adding to rental respository
        _rentalRepository.Add(rental);

        //make the book unavaiblable
        book.IsAvailable = false;
        _bookRepository.Update(book);

        return rental;
    }
    public List<BookRental> GetRentalHistoryByBook(int bookId)
    {
        throw new NotImplementedException();
    }

    public BookRental ReturnBook(int rentalId)
    {
        var rental = _rentalRepository.GetById(rentalId);
        if(rental == null)
        {
            _logger.LogError("Rental not found for Id: ", rentalId);
            throw new Exception("Rental is not found");
        }
        
        _rentalRepository.Update(rental);
        
        //Update books availibility
        if(rental.Book == null)
        {
            _logger.LogError("Book not found for Renntal Id", rentalId);
            throw new Exception("Book is not associated with rental");
        }
        rental.Book.IsAvailable = true;
        _bookRepository.Update(rental.Book);

        return rental;


    }

    public List<BookRental> GetRentalHistoryByMember()
    {
        //accessing member thorugh httpcontextaccessor to find who wnat to rent the book
        var memberId = _httpContextAccessor
                     .HttpContext
                     .User
                     .FindFirst(ClaimTypes.NameIdentifier)?
                     .Value;
        
        return _rentalRepository.GetRentalHistoryByMember(int.Parse(memberId));
        
        
    }
}
