using BookNest.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookNest.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UserBookProgress> UserBookProgresses { get; set; }
    }
}
