using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    [Route("api/Greet")]
    [ApiController]
    public class GreetController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World Its SNowing Outside!!! 🏂🏿⛄";
        }
    }
}
