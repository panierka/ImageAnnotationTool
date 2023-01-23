using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class DescriptorBlueprint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DataType Type { get; set; }

        public AnnotationClass ParentClass { get; set; }

        public ICollection<Descriptor> CreatedDescriptors { get; set; }

        public enum DataType
        {
            Integer,
            Double,
            Boolean,
            String,
            Choice
        }
    }
}
