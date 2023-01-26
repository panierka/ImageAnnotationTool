using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public interface IAnnotationServiceProvider
    {
        public Task CreateAnnotationClass(string className, int projectId);

        public Task<List<AnnotationClass>> GetAnnotationClasses(int projectId);

        public Task SetAnnotations(int imageId, ICollection<Annotation> annotations);

        public Task<List<Annotation>> GetAnnotations(int imageId);
    }
}
