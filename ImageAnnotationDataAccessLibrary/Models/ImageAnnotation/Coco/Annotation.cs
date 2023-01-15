using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public class Annotation
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public int CategoryId { get; set; }

        public int IsCrowd { get; set; }

        public ICollection<double> Segmentation { get; set; }

        public double area { get; set; }

        public ICollection<double> BoundryBox { get; set; }
    }
}
