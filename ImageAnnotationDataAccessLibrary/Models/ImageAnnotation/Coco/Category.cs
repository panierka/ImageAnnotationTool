using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public record Category
    {
        public  string Supercategory { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
