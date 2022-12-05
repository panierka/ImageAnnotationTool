using Microsoft.AspNetCore.Components.Forms;

namespace ImageProcessing
{
    public static class BrowserFileImageScaler
    {
        public static async Task<IBrowserFile> ScaleAsync(IBrowserFile file, int maxWidth, int maxHeight)
        {
            return await file.RequestImageFileAsync(file.ContentType, maxWidth, maxHeight);
        }
    }
}