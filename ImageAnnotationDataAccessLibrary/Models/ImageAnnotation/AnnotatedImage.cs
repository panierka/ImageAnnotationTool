using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class AnnotatedImage
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public virtual ImageData ImageData { get; set; }

        public virtual Job Job { get; set; }

        // adnotacje
    }
}
