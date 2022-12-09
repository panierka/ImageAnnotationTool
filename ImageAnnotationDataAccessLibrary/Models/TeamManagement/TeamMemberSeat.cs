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

		public UserAccount AssignedUser { get; set; }

		public Team Team { get; set; }

		public ICollection<ProjectMemberSeat> ProjectMemberSeats { get; set; }
	}
}
