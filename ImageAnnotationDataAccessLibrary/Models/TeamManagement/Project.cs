﻿using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Models.TeamManagement
{
    public class Project
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public string Name { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<ProjectMemberSeat> Members { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public ICollection<AnnotationClass> DefinedAnnotationClasses { get; set; }
        
        public Project() 
        {
            Members = new List<ProjectMemberSeat>();
            Jobs = new List<Job>();
            DefinedAnnotationClasses = new List<AnnotationClass>();
            Name = string.Empty;
        }
    }
}
