using ImageAnnotationToolDataAccessLibrary.Services;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            var mockDbFactory = new Mock<IDbContextFactory<ImageAnnotationToolContext>>();

            var options = new DbContextOptionsBuilder<ImageAnnotationToolContext>()
                        .UseInMemoryDatabase("InMemoryTest")
                        .Options;
            mockDbFactory
                .Setup(f => f.CreateDbContextAsync(new CancellationToken()))
                .ReturnsAsync(() => new ImageAnnotationToolContext(options));

            var jobsServiceProvider = new JobsServiceProvider(mockDbFactory.Object);
            var projectsServiceProvider = new ProjectServiceProvider(mockDbFactory.Object);

            //test CreateJob(Job job), GetAllJobs();

            await jobsServiceProvider.CreateJob(new() { Id = 1});
            await jobsServiceProvider.CreateJob(new() { Id = 2});
            await jobsServiceProvider.CreateJob(new() { Id = 3});
            await jobsServiceProvider.CreateJob(new() { Id = 4});

            const string predicted1 = "1;2;3;4";
            var jobs1 = await jobsServiceProvider.GetAllJobs();

            var actual1 = string.Join(';', jobs1.Select(x => x.Id));
            Assert.AreEqual(predicted1, actual1);

            //test UpdateJob(int jobId, Job job)

            await projectsServiceProvider.CreateProject(new() { Id = 1, Name = "Project1" });

            var project1 = await projectsServiceProvider.GetProject("Project1");

            await jobsServiceProvider.UpdateJob(1, new() { Project = project1 });
            await jobsServiceProvider.UpdateJob(2, new() { Project = project1 });
            await jobsServiceProvider.UpdateJob(3, new() { Project = project1 });
            await jobsServiceProvider.UpdateJob(4, new() { Project = project1 });

            const string predicted2 = "Project1;Project1;Project1;Project1";

            var jobs2 = await jobsServiceProvider.GetAllJobs();
            //var actual2 = string.Join(';', jobs2.Select(x => x.Project.Name));
            //Assert.AreEqual(predicted2, actual2);

            //test DeleteJob(int jobId)

            await jobsServiceProvider.DeleteJob(4);
            
            const string predicted3 = "1;2;3";

            var jobs3 = await jobsServiceProvider.GetAllJobs();
            var actual3 = string.Join(';', jobs3.Select(x => x.Id));

            Assert.AreEqual(predicted3, actual3);

            //test GetJobsOfProjectMemeber(int projectMemberId)



            //test GetJobsOfProject(int projectId)

            const string predicted5 = "1;2;3";

            var jobs5 = await jobsServiceProvider.GetJobsOfProject(1);
            var actual5 = string.Join(';', jobs5.Select(x => x.Id));

            //Assert.AreEqual(predicted5, actual5);
        }
    }
}