using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class ProjectMemberSeat
    {
        public int Id { get; set; }

        public UserAccount Account { get; set; }

        public List<Job> Jobs { get; set; }

        // rola
    }
}
