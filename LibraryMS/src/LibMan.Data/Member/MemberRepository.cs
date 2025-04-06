using LibMan.Data;
using LibMan.Entities;
using Microsoft.EntityFrameworkCore;

public class MemberRepository : IMemberRepository
{
    LibDbContext _context;

    public MemberRepository(LibDbContext context)
    {
        _context = context;
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
        if(member == null)
        {
            throw new Exception("Member with this ID not found");
        }
        return member;
    }

    public Member Update(Member entity)
    {
        throw new NotImplementedException();
    }
}