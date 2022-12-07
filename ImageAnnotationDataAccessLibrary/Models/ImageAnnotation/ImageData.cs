namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class ImageData
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Extension { get; set; }

        public string SourceBase64 { get; set; }

        // exif (nullable)
    }
}
