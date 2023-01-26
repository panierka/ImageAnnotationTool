using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public interface IAnnotatedImagesServiceProvider
    {
        public Task AddAnnotatedImagesAsync(IEnumerable<AnnotatedImage> images, int jobId);
        
        public Task<List<AnnotatedImage>> GetAnnotatedImagesFromProject(int jobId, int startIndex, int amount);
        
        public Task<int> GetAnnotatedImagesInProjectCount(int jobId);

        public Task<ImageData> GetImageData(int annotatedImageId);
    }
}
