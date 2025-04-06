using libMan.Services.Registration;
using LibMan.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebApplication1.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }


        [HttpPost]

        public IActionResult Post([FromBody]Member member)
        {
            try{
                _registrationService.Register(member);
                return Ok(member);
            }
            catch(DublicateEmailException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
