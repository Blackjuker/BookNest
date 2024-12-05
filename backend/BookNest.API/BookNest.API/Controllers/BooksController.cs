using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBook()
        {
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
