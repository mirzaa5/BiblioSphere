using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibMan.Data;
using LibMan.Entities;
using libMan.Services;
using libMan.Services.BookService;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication1.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, 
                                IWebHostEnvironment webHostEnvironment, 
                                ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _webHostEnviroment = webHostEnvironment;
            _logger = logger;

        }


        [HttpPost]
        // [Authorize(Roles ="Admin")]
        public  IActionResult Save([FromForm] Book book, [FromForm] IFormFile? coverImage)
        {

            //if coverImage is present
            if( coverImage != null)
            {
                _logger.LogInformation("Uploading Cover Image");
                
                //Step 1: Create wwwrootpat
                var wwwRootPath = _webHostEnviroment.WebRootPath;

                //Step 2 : create upload path
                var uploadPath = Path.Combine(wwwRootPath, "images/", coverImage.FileName);

                //Step 3 : create a stream, through using statement to store file
                //using statement disposes off stream/ open files once the saving is done

                using(  var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    coverImage.CopyTo(stream);
                }

                //Step 4 :  update the file coverImageUrl in book/ creates a realtive path
                // wwwroot/images/fileName, wwroot is figured out by _webHostEnviroment service to provide excat path

                book.CoverImageUrl = "images/" + coverImage.FileName;
            }

           var savedBook = _bookService.Save(book, coverImage);
           return Ok(savedBook);
           

        }

        
        [HttpGet("available")]
        public  IActionResult GetAvailableBooksForRental()
        {
            List<Book> BooksForRental = _bookService.GetAvailableBooksForRental().ToList();
            // return Ok(_bookService.GetAvailableBooksForRental().ToList());
            return Ok(BooksForRental);
        }

        [HttpGet("all")]
        public IActionResult GetAllBooks()
        {
         List<Book> AllBooks = _bookService.GetAllBooks().ToList();
         return Ok(AllBooks);
        }
    }
}
