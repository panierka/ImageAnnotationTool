using Microsoft.AspNetCore.Components.Forms;

namespace ImageProcessing
{
    public static class BrowserFileImageScaler
    {
        public static ValueTask<IBrowserFile> GetScaleTask(IBrowserFile file, int maxWidth, int maxHeight)
        {
            var task = file.RequestImageFileAsync(file.ContentType, maxWidth, maxHeight);
            return task;
        }
    }
}