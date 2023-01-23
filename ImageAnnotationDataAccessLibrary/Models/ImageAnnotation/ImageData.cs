using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class ImageData
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public string Name { get; set; }
        
        public string Extension { get; set; }

        public string SourceBase64 { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        // exif (nullable)
    }
}
