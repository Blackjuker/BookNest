using System.ComponentModel.DataAnnotations;

namespace BookNest.API.Models.Domain
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public Genre Genres { get; set; }
        public int PublicationYear { get; set; }
        public string? ISBN { get; set; }
        public required string CoverImage { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsVisible { get; set; }
        public required Author Author { get; set; }
    }
}
