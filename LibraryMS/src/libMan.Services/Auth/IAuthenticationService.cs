using libMan.Services.Auth;

namespace libMan.Services;

public interface IAuthenticationService
{

    //Login Functionality
    //Login to The System
    // <parameter name = "email"> The email of user
    // <paramteter name = "password"> The Password of User
    // <returns> True if Login Successful, false otherwise <returns>
    JwtToken Login(string email, string password);
}
