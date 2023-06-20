using CorporateQnA.Services.File;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/file")]
    public class FileController : BaseController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            this._fileService = fileService;
        }

        [HttpPost]
        public Task<string> Upload(IFormFile file)
        {
            return this._fileService.UploadProfilePicture(file);
        }

        [HttpPut]
        public Task<string> Update(IFormFile file)
        {
            return this._fileService.UpdateProfilePicture(file);
        }

        [HttpDelete]
        public void Delete()
        {
            this._fileService.DeleteProfilePicture();
        }
    }
}
