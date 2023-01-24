using ImageAnnotationToolDataAccessLibrary.Models.ExifExtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public record Coco
    {
        public Info Info { get; set; }

        //public List<License> Licenses { get; set; }

        public List<Image> Images { get; set; }

        public List<Annotation> Annotations { get; set; }

        public List<Category> Categories { get; set; }

        public List<Exif> Exifs { get; set; }
    }
}
