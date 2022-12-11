using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public interface IAnnotatedImagesProjectDatabaseServiceProvider
    {
        public void AddAnnotatedImages(IEnumerable<AnnotatedImage> images);

        public IEnumerable<AnnotatedImage> GetAllAnnotatedImagesFromProject(Project project);
    }
}
