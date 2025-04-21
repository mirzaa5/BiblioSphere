using LibMan.Data;
using LibMan.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class MemberRepository : IMemberRepository
{
    LibDbContext _context;
    ILogger<MemberRepository> _logger;
    IAdminRepositary _adminRepository;

    public MemberRepository(LibDbContext context, ILogger<MemberRepository> logger, IAdminRepositary adminRepositary)
    {
        _context = context;
        _logger = logger;
        _adminRepository = adminRepositary;
    }
    public Member Add(Member entity)
    {
        if(_context.Members.Any(m => m.Email.ToLower() == entity.Email.ToLower()))
        {
            throw new DublicateEmailException("Member already exits");
        }
        _context.Members.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Member Delete(Member entity)
    {
        throw new NotImplementedException();
    }

    public List<Member> GetAll()
    {
        throw new NotImplementedException();
    }

    public Member GetByEmail(string email)
    {
        var member = _context.Members.FirstOrDefault(b => b.Email == email);
        if(member == null)
        {
            throw new EmailNotFoundException("User with this email was not found!");
        }
        return member;
    }

    public Member GetById(int id)
    {
        var member = _context.Members.Find(id);

        if (member == null) //Check if user is admin
        {
            var admin = _adminRepository.GetById(id);
            if (admin != null)
            {
                throw new Exception($"Member {admin.Name} with Id {id} is an Admin, Admins can not rent Books!");
            }

            throw new Exception($"Member with Id {id} not found");
        }
        return member;
    }

    public Member Update(Member entity)
    {
        throw new NotImplementedException();
    }
}