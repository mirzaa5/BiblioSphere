

using System.Security.Claims;
using libMan.Services.Auth;
using LibMan.Data;
using LibMan.Entities;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
namespace libMan.Services;

public class DefaultAuthService : IAuthenticationService
{
    IAdminRepositary _adminRepositary;
    IMemberRepository _memberRepository;

    ILogger<DefaultAuthService> _logger;

    public DefaultAuthService(IAdminRepositary adminRepositary, 
                              IMemberRepository memberRepository,
                              ILogger<DefaultAuthService> logger)
    {
        _logger = logger;
        _adminRepositary = adminRepositary;
        _memberRepository = memberRepository;
    }

    public JwtToken Login(string email, string password)
    {
        User? user = _adminRepositary.GetByEmail(email);
        bool isAdmin = user != null;
        _logger.LogInformation($"Is user admin? {isAdmin}");
        if(user == null)
        {
;
            user = _memberRepository.GetByEmail(email);

            _logger.LogInformation($"Checking user: {user.Name} {user.Email}");
        }
        if(user == null || user.Password != password)
        {
    
            throw new AuthenticationException();
        }

        var jwtToken = GenerateJwtToken(user);
        jwtToken.isAdmin = isAdmin;
        return jwtToken;
        
    }
        private JwtToken GenerateJwtToken(User user)
    {
        //List of claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Email == "hadi55@gmail.com" ? "Admin" : "User"),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
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
