using BookNest.API.Data;
using BookNest.API.Mapper;
using BookNest.API.Models.Domain;
using BookNest.API.Models.DTO;
using BookNest.API.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly BookMapper _bookMapper;
        public BooksController(ApplicationDbContext context, BookMapper bookMapper) 
        {
            _context = context;
            _bookMapper = bookMapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBook),200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateBook(BookDto bookDto)
        {
            var bookCount = _context.Books.Count(b => b.Title == bookDto.Title || b.ISBN == bookDto.ISBN);
            if (bookCount > 0)
            {
                ModelState.AddModelError("message", "Ce livre existe déjà");
                return BadRequest(ModelState);
            }


            // create book

            Book book = _bookMapper.BookDtoToBook(bookDto);

            _context.Add(book);
            _context.SaveChanges();

            var response = new ResponseBook
            {
                Message = "Livre ajouté ave success",
                BookDTO = bookDto
            };

            
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook()
        {
            return Ok();
        }

    }
}
