using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class ProjectMemberSeat
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public TeamMemberSeat AssignedTeamMember { get; set; }

        public ICollection<Job> Jobs { get; set; }

        // rola
    }
}
