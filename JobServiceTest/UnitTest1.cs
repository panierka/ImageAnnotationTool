using ImageAnnotationToolDataAccessLibrary.Services;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockDbFactory = new Mock<IDbContextFactory<ImageAnnotationToolContext>>();

            var options = new DbContextOptionsBuilder<ImageAnnotationToolContext>()
                        .UseInMemoryDatabase("InMemoryTest")
                        .Options;
            mockDbFactory
                .Setup(f => f.CreateDbContextAsync(new CancellationToken()))
                .ReturnsAsync(() => new ImageAnnotationToolContext(options));

            var jobsServiceProvider = new JobsServiceProvider(mockDbFactory.Object);

            //await jobsServiceProvider.CreateJob(new() { Id = 1});
            //await jobsServiceProvider.CreateJob(new() { Id = 2});
            //await jobsServiceProvider.CreateJob(new() { Id = 3});
            //await jobsServiceProvider.CreateJob(new() { Id = 4});

        }
    }
}