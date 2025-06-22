using System;
using LibMan.Entities;
using LibMan.Data;

public interface IBookRepositary : IRepositary<Book>
{
    Task<List<Book>> GetAllAsync();

    

}
