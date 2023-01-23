using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class AnnotationClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Annotation> AnnotationsWithClass { get; set; }

        public ICollection<DescriptorBlueprint> DescriptorBlueprints { get; set; }

        public Project ParentProject { get; set; }
    }
}
