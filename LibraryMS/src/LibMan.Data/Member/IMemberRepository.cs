
using LibMan.Data;
using LibMan.Entities;

public interface IMemberRepository : IRepositary<Member>
{
    Member GetByEmail(string email);
}