using System;
using LibMan.Entities;
using LibMan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.Extensions.Logging;

public class BookRepositary : IBookRepositary
{

    LibDbContext _dbContext;
    IDistributedCache _cache; // Adding redis chaching service

    ILogger<BookRepositary> _logger;

    public BookRepositary(LibDbContext dbContext, IDistributedCache cache, ILogger<BookRepositary>  logger)
    {
        _dbContext = dbContext;
        _cache = cache; 
        _logger = logger;
    }
    
//Clearing cache when add update or delete book repositary
    public Book Add(Book entity)
    {
        _logger.LogInformation(entity.IsAvailable.ToString());
        // if( _dbContext.Books.Any(b => b.Title == entity.Title || b.ISBN == entity.ISBN))
        // {
        //     throw new Exception ("Book with a Similar Title or ISBN Already Exists");
        // }
        entity.IsAvailable = true; // by default, when a book is added, it is available for rental
        _dbContext.Books.Add(entity);

        _dbContext.SaveChanges();
        return entity;
    }

    public Book Delete(Book entity)
    {
        _logger.LogInformation("Deleting Book from Database");
        var book = _dbContext.Books.Find(entity.Id);
    
    
        if(book == null)
        {
            throw new Exception("This Book Was not found !");
        }
        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
        return book;

    
    }


    public async Task<List<Book>> GetAllAsync()
    {
        _logger.LogInformation("Attempting to retrive books from cache");
        //create name key for cache, check if cache is stored with this name in Redis
        var cacheKey = "BookCache";
        var cachedBooks = await _cache.GetStringAsync(cacheKey);

        //if the cachedBooks is not Null
        if (!string.IsNullOrEmpty(cachedBooks))
        {
            _logger.LogInformation("Sucessfully retrived cached Books data!");
            //Deserialize the cached JSON data back to List of Books and return
            return JsonSerializer.Deserialize<List<Book>>(cachedBooks);
        }

        _logger.LogInformation("Data not found in cache");
        _logger.LogInformation("Fetching Data from Database");

        //if there is no cache,  then fetch books asyncronously from Db
        List<Book> books = await _dbContext.Books.Include(b => b.Author).ToListAsync();

        // Serailize the data to JSOn and Store in cache
        string SerializedBooks = JsonSerializer.Serialize(books);
        await _cache.SetStringAsync(cacheKey, SerializedBooks, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) // keeping cache for 30 Minutes
        });

        

        return books;
    }

    public List<Book> GetAll()
    {

        return _dbContext.Books.Include(b => b.Author).ToList(); //its also loading Auhtor data

        // _dbContext.Book.ToList(); //just to get books
    }



    public Book GetById(int id)
    {
        var book = _dbContext.Books.Find(id);
        if(book == null)
        {
            throw new Exception("Book was not Found!");
        }
        return book;
    }

    public Book Update(Book entity)
    {
        if(_dbContext.Books.Any(b => b.Title == entity.Title && b.Id != entity.Id))
        {
            throw new Exception("Book with a Similar Title already Exists!");
        }
        _dbContext.Books.Update(entity);
        _dbContext.SaveChanges();
        return entity;;
    }

    
}
