
namespace ContactApp.Services.Interfaces
{
    public interface IImageService
    
    {
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string ConvertByteArrayToFile(byte[] fileDate, string extension);
    }
}
