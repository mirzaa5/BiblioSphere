using libMan.Services.RentalService;
using LibMan.Entities.Rental;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/rental")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalController (IRentalService rentalService)
        {
            _rentalService = rentalService;

        }


        [HttpPost()]

        public IActionResult RentBook([FromBody] RentalRequest request)
        {
            try
            {
                var rental = _rentalService.RentBook(request.BookId);
                return Ok(rental);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("history")]

        public IActionResult GetRentalHistoryByMember()
        {
            var history = _rentalService.GetRentalHistoryByMember();
            return Ok(history);
        }


        [HttpPut("{rentalId}/return")]
        public IActionResult ReturnBook(int rentalId)
        {
            try
            {
                
            var rental =_rentalService.ReturnBook(rentalId);
            return Ok(rental);
            }   

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public IActionResult ReturnAllRentals()
        {
            try{
                
            var rentals = _rentalService.GetAllRentals();
            return Ok(rentals);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

public class RentalRequest
{
    public int BookId {get; set;}
}