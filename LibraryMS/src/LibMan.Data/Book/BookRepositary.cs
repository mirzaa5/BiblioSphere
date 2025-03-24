using System;
using LibMan.Entities;
using LibMan.Data;
using Microsoft.EntityFrameworkCore;

public class BookRepositary : IBookRepositary
{

    LibDbContext _dbContext;

    public BookRepositary(LibDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    

    public Book Add(Book entity)
    {
        if( _dbContext.Books.Any(b => b.Title == entity.Title && b.ISBN == entity.ISBN))
        {
            throw new Exception ("Book with a Similar Title or ISBN Already Exists");
        }
        _dbContext.Books.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public Book Delete(Book entity)
    {
        var book = _dbContext.Books.FirstOrDefault(b => b.Title == entity.Title);
        if(book == null)
        {
            throw new Exception("This Book Was not found !");
        }
        _dbContext.Books.Remove(entity);
        _dbContext.SaveChanges();
        return entity;

    }

    public List<Book> GetAll()
    {
        return _dbContext.Books.Include(b => b.Author).ToList();
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
