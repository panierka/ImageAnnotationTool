﻿using ImageAnnotationToolDataAccessLibrary.DataAccess;
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

        public async Task CreateProject(Project project, Team team)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var retrievedTeam = await dbContext.Teams.FirstAsync(t => t.Id == team.Id);
            retrievedTeam.Projects.Add(project);
            //await dbContext.Projects.AddAsync(project);
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

            var project = dbContext.Projects.AsNoTracking().FirstOrDefault(x => x.Name == projectName);
            return project;
        }
        public async Task<Project?> GetProjectById(int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var project = dbContext.Projects.Include(t => t.Team).AsNoTracking().FirstOrDefault(x => x.Id == projectId);
            return project;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext.Projects.AsNoTracking().ToListAsync();
        }

        public async Task AddProjectMember(int teamMemberSeatId, int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var newProjectMember = dbContext.TeamMemberSeats.Where(t => t.Id == teamMemberSeatId).FirstOrDefault();
            var project = dbContext.Projects.AsNoTracking().Where(t => t.Id == projectId).FirstOrDefault();

            var projectMemberSeat = new ProjectMemberSeat
            {
                Project = project
            };

            newProjectMember.ProjectMemberSeats.Add(projectMemberSeat);
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
				.AsNoTracking()
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
				.AsNoTracking()
				.ToListAsync();
        }

        public async Task<int> GetProjectMemberSeatId(int teamMemberSeatId, int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var projectMemeberSeat = dbContext.ProjectMemberSeats.AsNoTracking().FirstOrDefault(t => t.AssignedTeamMember.Id == teamMemberSeatId & t.Project.Id == projectId);
            var projectMemberSeatId = projectMemeberSeat.Id;
            return projectMemberSeatId;
        }

        public async Task<ProjectMemberSeat?> GetProjectMember(int teamMemberSeatId, int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext
                .ProjectMemberSeats
                .Where(t => t.Project.Id == projectId && t.AssignedTeamMember.Id == teamMemberSeatId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task SetProjectMembersRole(int teamMemberId, int projectId, ProjectMemberSeat.ProjectRole role)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var projectseat = await dbContext
                .ProjectMemberSeats
                .Include(t => t.AssignedTeamMember)
                .Include(t => t.Project)
                .FirstOrDefaultAsync(
                    tms => tms.Project.Id == projectId
                    && tms.AssignedTeamMember.Id == teamMemberId
                );

            if (projectseat is { })
            {
                projectseat.Role = role;
            }

            await dbContext.SaveChangesAsync();
        }

		public async Task<ProjectMemberSeat?> GetProjectMemberLoaded(int teamMemberSeatId, int projectId)
		{
			using var dbContext = await dbContextFactory.CreateDbContextAsync();
			return await dbContext
				.ProjectMemberSeats
				.Where(t => t.Project.Id == projectId && t.AssignedTeamMember.Id == teamMemberSeatId)
				.Include(s => s.Project)
				.AsNoTracking()
				.FirstOrDefaultAsync();
		}

        public async Task<List<AnnotatedImage>> GetAllAnnotatedImagesFromProject(int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var project = await dbContext
                .Projects
                .Include(x => x.Jobs)
                    .ThenInclude(x => x.AnnotatedImages)
                    .ThenInclude(x => x.ImageData)
                    .ThenInclude(x => x.Exif)
                .Include(x => x.Jobs)
				    .ThenInclude(x => x.AnnotatedImages)
					.ThenInclude(x => x.Annotations)
                    .ThenInclude(x => x.Class)
				.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == projectId);

            var annotatedImages = project?
                .Jobs
                .SelectMany(x => x.AnnotatedImages)
                .ToList();
            
            return annotatedImages ?? new();
        }
    }
}