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
        public Task CreateProject(Project project, Team team);

        public Task DeleteProject(int projectId);

        public Task UpdateProject(int projectId, Project project);
        public Task<Project?> GetProject(string projectName);

        public Task<Project?> GetProjectById(int projectId);
        public Task<List<Project>> GetAllProjects();

        public Task AddProjectMember(int teamMemberSeatId, int projectId);

        public Task RemoveProjectMember(int projectMemberSeatId);

        public Task<List<ProjectMemberSeat>> GetProjectMembers(int projectId);

        public Task<List<ProjectMemberSeat>> GetProjectsOfTeamMember(int teamMemberId);

        public Task<int> GetProjectMemberSeatId(int teamMemberSeatId, int projectId);

        public Task<ProjectMemberSeat?> GetProjectMember(int teamMemberSeatId, int projectId);

        public Task SetProjectMembersRole(int teamMemberId, int projectId, ProjectMemberSeat.ProjectRole role);

	}
}