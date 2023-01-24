using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public class AnnotatedImagesProjectDatabaseServiceProvider : IAnnotatedImagesProjectDatabaseServiceProvider
    {
        private readonly IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;

        public AnnotatedImagesProjectDatabaseServiceProvider(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task AddAnnotatedImagesAsync(IEnumerable<AnnotatedImage> images)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            foreach(var image in images)
            {
                await dbContext.AnnotatedImages.AddAsync(image);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<AnnotatedImage>> GetAnnotatedImagesFromProject(int projectId, int startIndex, int amount)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            return await dbContext.AnnotatedImages
                .Where(x => x.Project.Id == projectId)
                .AsNoTracking()
                .Skip(startIndex)
                .Take(amount)
                .ToListAsync();
        }

        public async Task<int> GetAnnotatedImagesInProjectCount(int projectId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            return await dbContext
                .AnnotatedImages
                .Where(x => x.Project.Id == projectId)
                .AsNoTracking()
                .CountAsync();
        }
    }
}
