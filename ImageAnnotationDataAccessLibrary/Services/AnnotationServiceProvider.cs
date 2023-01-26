using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public class AnnotationServiceProvider : IAnnotationServiceProvider
    {
        private readonly IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;

        public AnnotationServiceProvider(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task CreateAnnotationClass(string className, int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var project = await dbContext.Projects.FirstAsync(p => p.Id == projectId);
            var newClass = new AnnotationClass
            {
                Name = className,
            };

            project.DefinedAnnotationClasses.Add(newClass);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<AnnotationClass>> GetAnnotationClasses(int projectId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            
            return await dbContext
                .AnnotationClasses
                .Where(x => x.ParentProject.Id == projectId)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<List<Annotation>> GetAnnotations(int imageId)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var annotatedImage = await dbContext
                .AnnotatedImages
                .Include(x => x.Annotations)
                .ThenInclude(x => x.Class)
                .AsNoTrackingWithIdentityResolution()
                .FirstAsync(x => x.Id == imageId);

            return annotatedImage
                .Annotations
                .ToList();
        }

        public async Task SetAnnotations(int imageId, ICollection<Annotation> annotations)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var image = await dbContext
                .AnnotatedImages
                .AsNoTrackingWithIdentityResolution()
                .FirstAsync(i => i.Id == imageId);
            
            image.Annotations = annotations;
            dbContext.Update(image);
            await dbContext.SaveChangesAsync();
        }
    }
}
