using System.ComponentModel.DataAnnotations;

namespace BookNest.API.Models.Domain
{
    public class Logs
    {
        [Key]
        public Guid LogId {  get; set; }
        public User UserId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
