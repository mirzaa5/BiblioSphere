namespace LibMan.Data;
using LibMan.Entities;
using Microsoft.Extensions.Logging;

public class AdminRepositary : IAdminRepositary
{
    LibDbContext _libDbContext;
    ILogger<AdminRepositary> _logger;

    //constructor that takes Dbcontext as parameter for Admin Repositary
    public AdminRepositary(LibDbContext context,
                           ILogger<AdminRepositary> logger)
    {
        _logger = logger;
        _libDbContext = context;
    }

    //Add
    public Admin Add(Admin entity)
    {
        if(_libDbContext.Admins.Any(d => d.Email.ToLower() == entity.Email.ToLower()))
        {
            throw new DublicateEmailException("Email already present"); 
        }
        _libDbContext.Admins.Add(entity);
        _libDbContext.SaveChanges();
        return entity;
    }

    

    //Update
    public Admin Update(Admin entity)
    {
        if(_libDbContext.Admins.Any(d => d.Email == entity.Email && entity.Id != d.Id ))
        {
            throw new Exception("The Admin with this email aready exists");
        }

        _libDbContext.Update(entity);
        _libDbContext.SaveChanges();
        return entity;

        //If statment to throw exception or to add entity?
    }

    //Delete
    public Admin Delete(Admin entity)
    {
        // Using Admins.Find is more suitable here !!
        var admin = _libDbContext.Admins.FirstOrDefault(a => a.Email == entity.Email);
        if(admin != null)
        {
            _libDbContext.Remove(entity);
            _libDbContext.SaveChanges();
            return entity;
        }
        throw new Exception("Admin you are trying to delete was not found !");
    }

    //Get By Id

    public Admin GetById(int Id)
    {
        var admin = _libDbContext.Admins.Find(Id);
        if( admin == null)
        {
            throw new Exception("Admin was not found !");
        }
        return admin;
    }

    //Get All entites
    public List<Admin> GetAll()
    {
        return _libDbContext.Admins.ToList();
    }

    //Get By Email

    public Admin? GetByEmail(string email)
    {
        var admin = _libDbContext.Admins.FirstOrDefault(a => a.Email == email);
        /* if(admin == null)
         {
             throw new EmailNotFoundException("Admin was not Found!"); //Custome Exception "EmailNotFoundException"
         }
         */
        return admin;
    }
}

//NoteL We are not going to throw exception if admin is not found, the login controller -->DefauultAuthService
// would look for member if the email  dosent mathc that of an admin!



/*
Use Case: Use FirstOrDefault when you need to query by a non-primary key or when you want to apply additional filtering conditions.
Use Case: Use Find when you are querying by the primary key and want to take advantage of caching.

✅ Any() is a LINQ method used to check if at least one element in a collection meets a condition.
✅ It returns a boolean (true or false).
✅ It is more efficient than .Count() > 0 because it stops as soon as it finds a match.
✅ It is commonly used in databases (EF Core) and collections to check for existence.


🔹 Final Takeaways
Need to check existence? ✅ Use Any().
Need to retrieve an entity? ✅ Use FirstOrDefault().
Fetching by primary key? ✅ Use Find().


*/