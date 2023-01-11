﻿﻿using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public interface IProjectServiceProvider
    {
        public Task CreateProject(Project project);

        public Task DeleteProject(int projectId);

        public Task UpdateProject(int projectId, Project project);

        public Task<List<Project>> GetAllProjects();

        public Task AddProjectMember(int projectMemberId);

        public Task RemoveProjectMember(int projectMemberSeatId);

        //public Task<List<ProjectMemberSeat>> GetAllProjectMembers(int projectId);

        //public Task<List<Project>> GetAllProjectsOfTeamMember(int accountId);
    }
}