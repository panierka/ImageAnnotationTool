﻿using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
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
        public Task<Project?> GetProject(string projectName);
        public Task<List<Project>> GetAllProjects();

        public Task AddProjectMember(int projectMemberId, int projectId);

        public Task RemoveProjectMember(int projectMemberSeatId);

        public Task<List<ProjectMemberSeat>> GetProjectMembers(int projectId);

        public Task<List<ProjectMemberSeat>> GetProjectsOfTeamMember(int teamMemberId);
    }
}