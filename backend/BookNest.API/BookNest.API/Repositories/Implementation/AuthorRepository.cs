using BookNest.API.Data;
using BookNest.API.Models.Domain;
using BookNest.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookNest.API.Repositories.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Author> CreateAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public async Task<Author?> DeleteAsync(Guid id)
        {
           var existingCategory = await _dbContext.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);

           if(existingCategory is null)
            {
                return null;
            }

           _dbContext.Authors.Remove(existingCategory);
           await _dbContext.SaveChangesAsync();

            return existingCategory;
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Author?> GetAuthorById(Guid id)
        {
           return await  _dbContext.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);
        }

        public async Task<Author?> UpdateAsync(Author author)
        {
            var existingAuthor = await _dbContext.Authors.FirstOrDefaultAsync( a => a.AuthorId == author.AuthorId );
            if (existingAuthor != null)
            {
                _dbContext.Entry(existingAuthor).CurrentValues.SetValues(author);
                await _dbContext.SaveChangesAsync();
                return existingAuthor;
            }

            return null;
        }
    }
}
