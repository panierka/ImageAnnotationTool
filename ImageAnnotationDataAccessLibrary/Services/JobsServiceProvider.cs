﻿using ImageAnnotationToolDataAccessLibrary.DataAccess;
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
    public class JobsServiceProvider : IJobsServiceProvider
    {
        private readonly IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;

        public JobsServiceProvider(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task CreateJob(Job job)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            await dbContext.Jobs.AddAsync(job);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteJob(int jobId)
        {
            var job = new Job
            {
                Id = jobId,
            };

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            dbContext.Jobs.Attach(job);
            dbContext.Jobs.Remove(job);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateJob(int jobId, Job job)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var updatedJob = dbContext.Jobs.Where(t => t.Id == jobId).FirstOrDefault();
            if (updatedJob == null)
            {
                throw new JobDoesNotExistException(jobId);
            }

            updatedJob.Project = job.Project;
            updatedJob.ProjectId = job.ProjectId;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Job>> GetAllJobs()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext
                .Jobs
                .Include(t => t.Project)
                .ToListAsync();
        }

        public async Task<List<Job>> GetJobsOfProjectMemeber(int projectMemberId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext.Jobs.Where(t => t.AssignedProjectMember.Id == projectMemberId).ToListAsync();
        }

        public async Task<List<Job>> GetJobsOfProject(int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext
                .Jobs
                .Where(t => t.Project.Id == projectId)
                .Include(t => t.Project)
                .ToListAsync();
        }
    }
}