using Microsoft.AspNetCore.Components.Forms;
using System.IO;
using System.Text;


namespace ImageProcessing
{
    public static class FileConverter
    {
        public static async Task<string> BrowserFileToBase64Async(IBrowserFile file)
        {
            byte[] buffer = new byte[file.Size];

            var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            await using var fs = new FileStream(path, FileMode.Create);
            await file.OpenReadStream(file.Size).CopyToAsync(fs);

            fs.Position = 0;
            await fs.ReadAsync(buffer);
            fs.Close();
            File.Delete(path);

            var base64BufferString = Convert.ToBase64String(buffer);
            var format = file.ContentType;
            var base64Builder = new StringBuilder($"data:{format};base64,")
                .Append(base64BufferString);

            return base64Builder.ToString();
        }
    }
}