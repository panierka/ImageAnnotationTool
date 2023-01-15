using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco
{
    public class Category
    {
        public  string SuperCategory { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
