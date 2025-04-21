using Microsoft.EntityFrameworkCore;
using LibMan.Entities;
using LibMan.Entities.Rental;
namespace LibMan.Data;

public class LibDbContext : DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<Admin> Admins {get; set;}
    public DbSet<Member> Members {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<Book> Books {get; set;}
    public DbSet<Membership> Membership {get; set;}

    public DbSet<BookRental> BookRentals {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=libmandb;User Id=postgres;Password=hadi");
    }

}
