using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public record License
    {
        public string? Url { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
