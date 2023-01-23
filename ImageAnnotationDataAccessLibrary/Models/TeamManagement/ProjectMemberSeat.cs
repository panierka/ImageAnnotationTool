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

        public virtual TeamMemberSeat AssignedTeamMember { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public ProjectRole Role { get; set; }

        public enum ProjectRole
        {
            User,
            Admin
        }
    }
}
