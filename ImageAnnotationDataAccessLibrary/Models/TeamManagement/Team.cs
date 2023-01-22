using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class Team
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public string Name { get; set; }

		public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<TeamMemberSeat> Members { get; set; }
    }
}
