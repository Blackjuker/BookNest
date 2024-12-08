using BookNest.API.Mapper;

namespace BookNest.API.Service
{
    public interface IFileUpload
    {
        Task<string> SaveFileAsync(IFormFile file, Guid bookId);
    }
}
