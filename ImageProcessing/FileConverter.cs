using Microsoft.AspNetCore.Components.Forms;
using System.Text;

namespace ImageProcessing
{
    public static class FileConverter
    {
        public static async Task<string> BrowserFileToBase64Async(IBrowserFile file)
        {
            var resizedFile = await file.RequestImageFileAsync(
                file.ContentType,
                640,
                500);
            byte[] buffer = new byte[resizedFile.Size];
            using (var stream = resizedFile.OpenReadStream())
            {
                await stream.ReadAsync(buffer);
            }
            var base64BufferString = Convert.ToBase64String(buffer);
            var base64Builder = new StringBuilder("data:image/png;base64,")
                .Append(base64BufferString);

            return base64Builder.ToString();
        }
    }
}