using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class TeamMemberSeat
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public virtual UserAccount AssignedUser { get; set; }

		public virtual Team Team { get; set; }

		public virtual ICollection<ProjectMemberSeat> ProjectMemberSeats { get; set; }

		public TeamRole Role { get; set; }

		public enum TeamRole
		{
			User,
			Admin
		}
	}
}
