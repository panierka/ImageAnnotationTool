using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class Project
    {
        public int Id { get; set; }

        public List<ProjectMemberSeat> Members { get; set; }
    }
}
