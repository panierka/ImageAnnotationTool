﻿using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public interface IProjectServiceProvier
    {
        public Task CreateProject(Project project);

        public Task DeleteProject(int projectId);

        public Task UpdateProject(int projectId, Project project);

        public Task AddProjectMember(int teamMemberId);

        public Task RemoveProjectMember(int teamMemberId);
    }
}