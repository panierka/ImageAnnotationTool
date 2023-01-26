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
    public class AnnotatedImagesServiceProvider : IAnnotatedImagesServiceProvider
    {
        private readonly IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;

        public AnnotatedImagesServiceProvider(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task AddAnnotatedImagesAsync(IEnumerable<AnnotatedImage> images, int jobId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            var job = await dbContext.Jobs
                .Include(x => x.AnnotatedImages)
                .FirstOrDefaultAsync(x => x.Id == jobId);

            foreach(var image in images)
            {
                job?.AnnotatedImages.Add(image);
            }
            
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<AnnotatedImage>> GetAnnotatedImagesFromProject(int jobId, int startIndex, int amount)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            return await dbContext.AnnotatedImages
                .Where(x => x.Job.Id == jobId)
                .AsNoTrackingWithIdentityResolution()
                .Skip(startIndex)
                .Take(amount)
                .ToListAsync();
        }

        public async Task<int> GetAnnotatedImagesInProjectCount(int jobId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            return await dbContext
                .AnnotatedImages
                .Where(x => x.Job.Id == jobId)
                .AsNoTrackingWithIdentityResolution()
                .CountAsync();
        }

        public async Task<ImageData> GetImageData(int annotatedImageId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            var annotatedImage = await dbContext
                .AnnotatedImages
                .Where(x => x.Id == annotatedImageId)
                .Include(x => x.ImageData)
                .AsNoTrackingWithIdentityResolution()
                .FirstAsync();

            return annotatedImage.ImageData;
        }
    }
}
