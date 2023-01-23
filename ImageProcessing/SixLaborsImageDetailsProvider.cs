using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class SixLaborsImageDetailsProvider : IImageDetailsProvider
    {
        public async Task<ImageDetails> GetImageDetails(IBrowserFile file)
        {
            var byteArray = await FileConverter.BrowserFileToByteArrayAsync(file);
            using var image = SixLabors.ImageSharp.Image.Load(byteArray);
            return new(image.Width, image.Height);
        }
    }
}
