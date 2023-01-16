using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Exceptions;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public class ProjectServiceProvider : IProjectServiceProvider
    {
        private readonly IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;

        public ProjectServiceProvider(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task CreateProject(Project project)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int projectId)
        {
            var project = new Project
            {
                Id = projectId,
            };

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            dbContext.Projects.Attach(project);
            dbContext.Projects.Remove(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateProject(int projectId, Project project)
        {
            var projectName = project.Name;

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var updatedProject = dbContext.Projects.Where(t => t.Id == projectId).FirstOrDefault();
            if (updatedProject == null)
            {
                throw new TeamDoesNotExistException(projectId);
            }

            updatedProject.Name = projectName;
            //updatedProject = project;
            await dbContext.SaveChangesAsync();
        }

        public async Task<Project?> GetProject(string projectName)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var project = dbContext.Projects.FirstOrDefault(x => x.Name == projectName);
            return project;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext.Projects.ToListAsync();
        }

        public async Task AddProjectMember(int teamMemberSeatId, int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var newProjectMember = dbContext.TeamMemberSeats.Where(t => t.Id == teamMemberSeatId).FirstOrDefault();
            var project = dbContext.Projects.Where(t => t.Id == projectId).FirstOrDefault();

            var projectMemberSeat = new ProjectMemberSeat
            {
                AssignedTeamMember = newProjectMember,
                Project = project
            };

            await dbContext.ProjectMemberSeats.AddAsync(projectMemberSeat);

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveProjectMember(int projectMemberSeatId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var projectMember = dbContext.ProjectMemberSeats.Where(t => t.Id == projectMemberSeatId).FirstOrDefault();

            dbContext.ProjectMemberSeats.Attach(projectMember);
            dbContext.ProjectMemberSeats.Remove(projectMember);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectMemberSeat>> GetProjectMembers(int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext
                .ProjectMemberSeats
                .Where(t => t.Project.Id == projectId)
                .Include(t => t.AssignedTeamMember.AssignedUser)
                .Include(t => t.Project)
                .ToListAsync();
        }

        public async Task<List<ProjectMemberSeat>> GetProjectsOfTeamMember(int teamMemberId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext
                .ProjectMemberSeats
                .Where(t => t.AssignedTeamMember.Id == teamMemberId)
                .Include(t => t.AssignedTeamMember)
                .Include(t => t.Project)
                .ToListAsync();
        }
    }
}