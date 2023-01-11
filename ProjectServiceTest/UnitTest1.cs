using ImageAnnotationToolDataAccessLibrary.Services;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var mockDbFactory = new Mock<IDbContextFactory<ImageAnnotationToolContext>>();

            var options = new DbContextOptionsBuilder<ImageAnnotationToolContext>()
                        .UseInMemoryDatabase("InMemoryTest")
                        .Options;
            mockDbFactory
                .Setup(f => f.CreateDbContextAsync(new CancellationToken()))
                .ReturnsAsync(() => new ImageAnnotationToolContext(options));

            var projectsServiceProvider = new ProjectServiceProvider(mockDbFactory.Object);
            //var teamsServiceProvider = new TeamServiceProvider(mockDbFactory.Object);

            //await teamsServiceProvider.CreateTeam(new() { Id = 1, Name = "Student1" });

            await projectsServiceProvider.CreateProject(new() { Id = 1, Name = "Project1"});
            await projectsServiceProvider.CreateProject(new() { Id = 2, Name = "Project2"});
            await projectsServiceProvider.CreateProject(new() { Id = 3, Name = "Project3"});
            await projectsServiceProvider.CreateProject(new() { Id = 4, Name = "Project4"});

            const string predicted1 = "Project1;Project2;Project3;Project4";
            var projects1 = await projectsServiceProvider.GetAllProjects();

            var actual1 = string.Join(';', projects1.Select(x => x.Name));
            Assert.AreEqual(predicted1, actual1);

            await projectsServiceProvider.UpdateProject(3, new() { Name = "ProjectX" });

            const string predicted2 = "Project1;Project2;ProjectX;Project4" ;

            var projects2 = await projectsServiceProvider.GetAllProjects();
            var actual2 = string.Join(';', projects2.Select(x => x.Name));
            Assert.AreEqual(predicted2, actual2);

            await projectsServiceProvider.DeleteProject(4);

            const string predicted3 = "Project1;Project2;ProjectX";

            var projects3 = await projectsServiceProvider.GetAllProjects();
            var actual3 = string.Join(';', projects3.Select(x => x.Name));

            Assert.AreEqual(predicted3, actual3);

        }
    }
}