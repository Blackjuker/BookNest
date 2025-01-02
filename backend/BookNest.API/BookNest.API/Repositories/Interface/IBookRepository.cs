using BookNest.API.Models.Domain;

namespace BookNest.API.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?>  CreateBook(Book book);
        Task<Book?> UpdateBook(Book book);
        Task<Book?> DeleteBook(Guid id);
        Task<Book?> GetBookById(Guid id);
    }
}
