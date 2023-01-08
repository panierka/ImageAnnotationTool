using ImageAnnotationToolDataAccessLibrary.Services;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TeamServiceTest
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

            var teamsServiceProvider = new TeamServiceProvider(mockDbFactory.Object);

            await teamsServiceProvider.CreateTeam(new() { Id = 1, Name = "Student1" });
            await teamsServiceProvider.CreateTeam(new() { Id = 2, Name = "Student2" });
            await teamsServiceProvider.CreateTeam(new() { Id = 3, Name = "Student3" });
            await teamsServiceProvider.CreateTeam(new() { Id = 4, Name = "Student4" });

            const string predicted1 = "Student1;Student2;Student3;Student4";
            var teams1 = await teamsServiceProvider.GetAllTeams();

            var actual1 = string.Join(';', teams1.Select(x => x.Name));
            Assert.AreEqual(predicted1, actual1);

            await teamsServiceProvider.UpdateTeam(3, new() { Name = "StudentX" });

            const string predicted2 = "Student1;Student2;StudentX;Student4";

            var teams2 = await teamsServiceProvider.GetAllTeams();
            var actual2 = string.Join(';', teams2.Select(x => x.Name));
            Assert.AreEqual(predicted2, actual2);
        }
    }
}