using Microsoft.AspNetCore.Components.Forms;
using System.Drawing;
using System.IO;
using System.Text;


namespace ImageProcessing
{
    public static class FileConverter
    {
        public static async Task<string> BrowserFileToBase64Async(IBrowserFile file)
        {
            var buffer = await BrowserFileToByteArrayAsync(file);

            var base64BufferString = Convert.ToBase64String(buffer);
            var format = file.ContentType;
            var base64Builder = new StringBuilder($"data:{format};base64,")
                .Append(base64BufferString);

            return base64Builder.ToString();
        }

        public static async Task<byte[]> BrowserFileToByteArrayAsync(IBrowserFile file)
        {
            byte[] buffer = new byte[file.Size];

            var guid = Guid.NewGuid().ToString();
            var path = Path.Combine(Path.GetTempPath(), guid);

            await using var fs = new FileStream(path, FileMode.Create);
            await file.OpenReadStream(file.Size).CopyToAsync(fs);

            fs.Position = 0;
            await fs.ReadAsync(buffer);

            fs.Close();
            File.Delete(path);

            return buffer;
        }

        public static async Task<Image> BrowserFileToImageAsync(IBrowserFile file)
        {
            var buffer = await BrowserFileToByteArrayAsync(file);
            MemoryStream ms = new MemoryStream(buffer);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Stream ByteArrayToStream(byte[] byteArray)
        {
            Stream returnStream = new MemoryStream(byteArray);
            return returnStream;
        }

    }
}