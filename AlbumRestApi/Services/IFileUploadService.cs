namespace AlbumRestApi.Services
{
    public interface IFileUploadService
    {
        public Task<string> UploadFile(IFormFile file, string fileName);
    }
}
