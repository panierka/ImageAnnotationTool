using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class Team
    {
        public ICollection<TeamMemberSeat> Members { get; set; }
    }
}
