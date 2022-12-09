using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class Job
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public ICollection<AnnotatedImage> AnnotatedImages { get; set; }

        public ProjectMemberSeat AssignedProjectMember { get; set; }

        [ForeignKey(nameof(ProjectId))]
		public Project? Project { get; set; }

        public int? ProjectId { get; set; }
    }
}
