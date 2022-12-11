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

        public void AddAnnotatedImages(IEnumerable<AnnotatedImage> images)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            images
                .ToList()
                .ForEach(x => dbContext.AnnotatedImages.Add(x));
            dbContext.SaveChanges();
        }

        public IEnumerable<AnnotatedImage> GetAllAnnotatedImagesFromProject(Project project)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            return dbContext.AnnotatedImages.Where(x => x.Project.Id == project.Id);
        }
    }
}
