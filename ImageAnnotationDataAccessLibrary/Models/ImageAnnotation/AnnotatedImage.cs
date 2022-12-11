using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class AnnotatedImage
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public ImageData ImageData { get; set; }

        public Job? Job { get; set; }

        public Project Project { get; set; }

        // adnotacje
    }
}
