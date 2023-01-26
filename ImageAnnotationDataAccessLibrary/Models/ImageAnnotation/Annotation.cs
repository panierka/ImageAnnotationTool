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
    public class Annotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public AnnotationClass Class { get; set; }

        public ICollection<Descriptor> Descriptors { get; set; }

        public AnnotatedImage Image { get; set; }

        public List<double> PointsX { get; set; }

        public List<double> PointsY { get; set; }

        public bool IsClosed { get; set; }

        public int ShapeType { get; set; }

        public Annotation()
        {
            PointsX = new();
            PointsY = new();
        }
    }
}
