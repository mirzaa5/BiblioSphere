namespace LibMan.Data;
using LibMan.Entities;

public interface IAdminRepositary : IRepositary<Admin>
{
    Admin? GetByEmail(string email);
}
