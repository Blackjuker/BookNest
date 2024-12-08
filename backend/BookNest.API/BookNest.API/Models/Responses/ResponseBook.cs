using BookNest.API.Models.DTO;

namespace BookNest.API.Models.Responses
{
    public class ResponseBook
    {
        public required string Message { get; set; }
        public BookDto? BookDTO { get; set; }
    }
}
