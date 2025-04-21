using libMan.Services;
using LibMan.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/login")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private IAuthenticationService _authService;

        private ILogger<LoginController> _logger;

        public LoginController( IAuthenticationService authService,
                                ILogger<LoginController> logger)
        {
            _authService = authService;
            _logger = logger;
        }


        [HttpPost]
        
        public IActionResult Login([FromBody] AuthRequest request)
        {
            try{
                    _logger.LogInformation("try Block Login Controller requesting jwt");
                    var jwtToken = _authService.Login(request.Email, request.Password);
                    if(jwtToken !=  null)
                    {
                        return Ok(jwtToken);
                    }
                    else
                    {
                        return Unauthorized( new {message= "Wrong Login credentials"});
                    }

                }

            catch(EmailNotFoundException)
            
                {
                    
                    return NotFound("The Email address you entered was not found!");
                }      

            catch(Exception ex)
            {
                return Unauthorized(ex.ToString());
            }      
        }
    }
}
