﻿using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public interface IJobsServiceProvider
    {
        public Task CreateJob(Job job, int projectId);

        public Task DeleteJob(int jobId);

        public Task UpdateJob(int jobId, Job job);

        public Task<List<Job>> GetAllJobs();

        public Task<List<Job>> GetJobsOfProjectMemeber(int projectMemberId);

        public Task<List<Job>> GetJobsOfProject(int projectId);
    }
}