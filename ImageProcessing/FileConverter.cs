using Microsoft.AspNetCore.Components.Forms;
using System.Text;


namespace ImageProcessing
{
    public static class FileConverter
    {
        public static async Task<string> BrowserFileToBase64Async(IBrowserFile file)
        {
            byte[] buffer = new byte[file.Size];
            using (var stream = file.OpenReadStream())
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