using Microsoft.AspNetCore.Http;

namespace CorporateQnA.Services.File
{
    public interface IFileService
    {
        Task<string> UploadProfilePicture(IFormFile file);

        Task<string> UpdateProfilePicture(IFormFile file);

        void DeleteProfilePicture();
    }
}
