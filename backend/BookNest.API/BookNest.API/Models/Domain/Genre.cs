using System.ComponentModel.DataAnnotations;

namespace BookNest.API.Models.Domain
{
    public class Genre
    {
        [Key]
        public Guid GenreId {  get; set; }
        public string? Name { get; set; }
    }
}
