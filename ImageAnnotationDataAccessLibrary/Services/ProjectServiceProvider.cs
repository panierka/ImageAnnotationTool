using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Exceptions;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public class ProjectServiceProvider : IProjectServiceProvier
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
            var ProjectName = project.Name;

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var updatedProject = dbContext.Projects.Where(t => t.Id == projectId).FirstOrDefault();
            if (updatedProject == null)
            {
                throw new TeamDoesNotExistException(projectId);
            }

            updatedProject.Name = ProjectName;
            await dbContext.SaveChangesAsync();
        }

        public async Task AddProjectMember(int teamMemberId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveProjectMember(int teamMemberId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            await dbContext.SaveChangesAsync();
        }
    }
}