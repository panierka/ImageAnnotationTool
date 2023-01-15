using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public class Info
    {
        public string Description { get; set; }

        public string Url { get; set; }

        public string Version { get; set; }

        public int Year { get; set; }

        public string Contributor { get; set; }

        public string DateCreated { get; set; }
    }
}
