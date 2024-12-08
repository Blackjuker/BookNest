using BookNest.API.Data;
using BookNest.API.Mapper;
using BookNest.API.Models.Domain;
using BookNest.API.Models.DTO;
using BookNest.API.Models.Responses;
using BookNest.API.Service;
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
        private readonly IFileUpload _fileUpload;
        public BooksController(ApplicationDbContext context, BookMapper bookMapper, IFileUpload fileUpload) 
        {
            _context = context;
            _bookMapper = bookMapper;
            _fileUpload = fileUpload;
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
                ModelState.AddModelError("Message", "Ce livre existe déjà");
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

            
            return Ok(response);
        }

        [HttpPost("upload/{bookId}")]
        public async Task<IActionResult> UploadFile([FromRoute] Guid bookId, /*[FromForm]*/ IFormFile file)
        {
            if (file == null)
            {
                ModelState.AddModelError("Message", "Fichier non reçu");
                return BadRequest(ModelState);
            }

            try
            {
                var fileName = await _fileUpload.SaveFileAsync(file, bookId);

                return Ok( new ResponseBook
                {
                    Message = "Livre uploader avec success"
                });
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Message", "Fichier non reçu : "+ex.ToString());
                return BadRequest(ModelState);
            }
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
