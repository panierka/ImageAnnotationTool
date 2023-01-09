using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class Project
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public string Name { get; set; }

        public Team Team { get; set; }

        public ICollection<ProjectMemberSeat> Members { get; set; }

        public ICollection<Job>? Jobs { get; set; }

        public ICollection<AnnotatedImage> AnnotatedImages { get; set; }
    }
}
