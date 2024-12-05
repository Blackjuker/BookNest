using System.ComponentModel.DataAnnotations;

namespace BookNest.API.Models.Domain
{
    public class Author
    {
        [Key]
        public Guid AuthorId { get; set; }
        public required string Name { get; set; }
        public required ICollection<Book> Books { get; set; }
    }
}
