namespace BookNest.API.Models.Domain
{
    public class UserBook
    {
        public User UserId { get; set; }
        public Book BookId { get; set; }
        public DateTime AccessGrantedAt { get; set; }
    }
}
