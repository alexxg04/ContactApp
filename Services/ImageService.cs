using ContactApp.Services.Interfaces;
using System.Buffers.Text;

namespace ContactApp.Services
{
    public class ImageService : IImageService
    {
       private readonly string[] suffixes = { "Bytes", "KB", "GB", "TB", "PB" };
        private readonly string defaultImage = "img/DefaultContactImage.png";


        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null) return defaultImage;
            try
            {
                string imageBase64Data = Convert.ToBase64String(fileData);
                return string.Format($"data:{extension}, Base64,{imageBase64Data}");
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            try
            {
                using MemoryStream memoryStream = new();
                await file.CopyToAsync(memoryStream);
                byte[] byteFile = memoryStream.ToArray();
                return byteFile;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
