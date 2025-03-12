namespace ecommerceAPP.Interfaces
{
    public interface IFileUploadService
    {
        string UploadFile(IFormFile file, string folderPath);
    }
}
