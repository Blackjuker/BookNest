namespace BookNest.API.Models.DTO
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }
        public required string Name { get; set; }
    }
}
