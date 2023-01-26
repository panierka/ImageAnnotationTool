using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public record AnnotationCoco
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int Iscrowd { get; set; }

        public List<List<double>> Segmentation { get; set; }

        public int ImageId { get; set; }

        public double Area { get; set; }

        public List<double> Bbox { get; set; }
    }
}
