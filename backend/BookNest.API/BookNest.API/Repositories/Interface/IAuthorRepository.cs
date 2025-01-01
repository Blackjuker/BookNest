using BookNest.API.Models.Domain;

namespace BookNest.API.Repositories.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAsync(Author author);
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetAuthorById(Guid id);

        Task<Author?> UpdateAsync(Author author);

        Task<Author?> DeleteAsync(Guid id);
    }
}
