using BookNest.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BookNest.API.Models.DTO
{
    public class UserBookProgressDto
    {
        [Key]
        public Guid ProgressId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int CurrentPage { get; set; }

        public DateTime LastUpdate { get; set; }

        public string? ReadingStatus { get; set; }
        public required Book Book { get; set; }


    }
}
