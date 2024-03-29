﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class AnnotatedImage
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public virtual ImageData ImageData { get; set; }

        public int ImageDataForeignKey { get; set; }

        public virtual Job? Job { get; set; }

        public ICollection<Annotation> Annotations { get; set; }

        public void SetAnnotations(params Annotation[] annotations)
        {
            Annotations.Clear();

            foreach (var a in annotations)
            {
                Annotations.Add(a);
            }
        }

        public AnnotatedImage()
        {
            Annotations = new List<Annotation>();
        }
    }
}
