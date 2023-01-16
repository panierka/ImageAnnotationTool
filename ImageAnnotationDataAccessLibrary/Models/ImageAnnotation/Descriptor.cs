using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class Descriptor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Value { get; set; }

        public Annotation Annotation { get; set; }

        public DescriptorBlueprint Blueprint { get; set; }
    }
}
