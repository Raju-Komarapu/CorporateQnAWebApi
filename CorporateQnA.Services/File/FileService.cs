using Azure.Storage.Blobs;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.RequestContext;
using Microsoft.AspNetCore.Http;

namespace CorporateQnA.Services.File
{
    public class FileService : IFileService
    {
        private readonly IRequestContext _requestContext;

        private readonly BlobContainerClient _blobContainerClient;

        private readonly ApplicationDbContext _db;

        public FileService(IRequestContext requestContext, BlobServiceClient blobServiceClient, ApplicationDbContext db)
        {
            this._requestContext = requestContext;
            this._blobContainerClient = blobServiceClient.GetBlobContainerClient("profilepics");
            this._db = db;
        }

        public async Task<string> UploadProfilePicture(IFormFile file)
        {
            var fileName = $"ProfilePicture_{this._requestContext.Id}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.{file.FileName.Split('.').Last()}";
            var blobInstance = this._blobContainerClient.GetBlobClient(fileName);
            await blobInstance.UploadAsync(file.OpenReadStream());
            string blobUrl = blobInstance.Uri.ToString();
            this._db.Execute("UPDATE Employee SET ProfilePictureUrl = @profilePictureUrl WHERE Id = @id", new { profilePictureUrl = blobUrl, id = this._requestContext.Id });
            return blobUrl;
        }

        public async void DeleteProfilePicture()
        {
            var blobNames = this._blobContainerClient.GetBlobs().Select(blob => blob.Name);
            var blobToDelete = blobNames.SingleOrDefault(blobName => blobName.StartsWith($"ProfilePicture_{this._requestContext.Id}"));
            var blobClient = this._blobContainerClient.GetBlobClient(blobToDelete);
            await blobClient.DeleteIfExistsAsync();
            this._db.Execute("UPDATE Employee SET ProfilePictureUrl = NULL WHERE Id = @employeeId", new { employeeId = this._requestContext.Id });
        }

        public async Task<string> UpdateProfilePicture(IFormFile file)
        {
            var blobNames = this._blobContainerClient.GetBlobs().Select(blob => blob.Name);
            var blobToDelete = blobNames.SingleOrDefault(blobName => blobName.StartsWith($"ProfilePicture_{this._requestContext.Id}"));
            var blobClient = this._blobContainerClient.GetBlobClient(blobToDelete);
            await blobClient.DeleteIfExistsAsync();
            return await this.UploadProfilePicture(file);
        }
    }
}
