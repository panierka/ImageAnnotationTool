using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation
{
    public class Job
    {
        public int Id { get; set; }

        public List<AnnotatedImage> AnnotatedImages { get; set; }

        public ProjectMemberSeat AssignedProjectMember { get; set; }
    }
}
