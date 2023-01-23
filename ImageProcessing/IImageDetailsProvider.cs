using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public interface IImageDetailsProvider
    {
        public Task<ImageDetails> GetImageDetails(IBrowserFile file);
    }
}
