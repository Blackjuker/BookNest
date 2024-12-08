using BookNest.API.Mapper;

namespace BookNest.API.Service
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IFormFile file, Guid bookId);
    }
}
