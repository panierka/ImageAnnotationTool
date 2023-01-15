using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public class Coco
    {
        public Info Info { get; set; }

        public ICollection<License> Licenses { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Annotation> Annotations { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
