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

        public IQueryable<AnnotatedImage> GetAllAnnotatedImagesFromProject(Project project)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            return dbContext.AnnotatedImages
                .AsQueryable()
                .Where(x => x.Project.Id == project.Id);
        }
    }
}
