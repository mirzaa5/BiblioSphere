using System.Security.Claims;
using libMan.Services.Auth;
using LibMan.Data;
using LibMan.Entities;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Authentication;
namespace libMan.Services;

public class DefaultAuthService : IAuthenticationService
{
    IAdminRepositary _adminRepositary;

    public DefaultAuthService(IAdminRepositary adminRepositary)
    {
        _adminRepositary = adminRepositary;
    }

        public JwtToken Login(string email, string password)
    {
        var admin = _adminRepositary.GetByEmail(email);

        if(admin.Password != password)
        {
             throw new AuthenticationException();
        };

        
                var token  = GenerateJwtToken(admin);
                 return token;

    }


    private JwtToken GenerateJwtToken(Admin admin)
    {
        //List of claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, admin.Name),
            new Claim(ClaimTypes.Email, admin.Email),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString())
        };

        // sginingKey
        var secretKey = "SOme random key keyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
        var Signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        //Signing Credentials
        var credentials = new SigningCredentials(Signingkey, SecurityAlgorithms.HmacSha256);

        //token
        var expiration = DateTime.UtcNow.AddDays(1);

        var token = new JwtSecurityToken( claims: claims, expires: expiration, signingCredentials:credentials);

        //Return Jwt string inside object
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);

        return new JwtToken{
            Token = tokenString,
            Expiration = expiration
        };

        
    }
    
}
