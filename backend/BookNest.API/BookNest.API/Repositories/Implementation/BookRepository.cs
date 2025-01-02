using BookNest.API.Data;
using BookNest.API.Models.Domain;
using BookNest.API.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookNest.API.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BookRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Book?> CreateBook(Book book)
        {
            if (book != null)
            {
                _dbContext.Books.Add(book);
                await _dbContext.SaveChangesAsync();
                return book;
            }
            return null;
        }

        public async Task<Book?> DeleteBook(Guid id)
        {
            var existingBook =await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (existingBook is null)
            {
                return null;
            }

            _dbContext.Books.Remove(existingBook);
            await _dbContext.SaveChangesAsync();

            return existingBook;
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b =>b.BookId == id);
        }

        public async Task<Book?> UpdateBook(Book book)
        {
            var existingBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == book.BookId);
            if (existingBook is null)
            {
                return null;
            }

            _dbContext.Entry(existingBook).CurrentValues.SetValues(book);
            await _dbContext.SaveChangesAsync();

            return existingBook;
        }
    }
}
