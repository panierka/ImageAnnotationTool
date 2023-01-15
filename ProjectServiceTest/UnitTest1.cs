using ImageAnnotationToolDataAccessLibrary.Services;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ImageAnnotationToolDataAccessLibrary.Migrations;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using Security.Hashing;
using Security.Salting;
using Security;

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
            var teamsServiceProvider = new TeamServiceProvider(mockDbFactory.Object);
            var saltProvider = new RngSalting();
            var hashingfunctionProvider = new SHA256Hashing();
            var hashGenerator = new SaltedHashGenerator(hashingfunctionProvider, saltProvider);
            var userAccountServiceProvider = new UserAccountsServiceProvider(mockDbFactory.Object, saltProvider, hashGenerator);

            //test CreateProject(Project project), GetAllProjectMembers(int projectId)

            await projectsServiceProvider.CreateProject(new() { Id = 1, Name = "Project1"});
            await projectsServiceProvider.CreateProject(new() { Id = 2, Name = "Project2"});
            await projectsServiceProvider.CreateProject(new() { Id = 3, Name = "Project3"});
            await projectsServiceProvider.CreateProject(new() { Id = 4, Name = "Project4"});

            const string predicted1 = "Project1;Project2;Project3;Project4";
            var projects1 = await projectsServiceProvider.GetAllProjects();

            var actual1 = string.Join(';', projects1.Select(x => x.Name));
            Assert.AreEqual(predicted1, actual1);

            //test UpdateProject(int projectId, Project project)

            await projectsServiceProvider.UpdateProject(3, new() { Name = "ProjectX" });

            const string predicted2 = "Project1;Project2;ProjectX;Project4" ;

            var projects2 = await projectsServiceProvider.GetAllProjects();
            var actual2 = string.Join(';', projects2.Select(x => x.Name));
            Assert.AreEqual(predicted2, actual2);

            //test DeleteProject(int projectId)

            await projectsServiceProvider.DeleteProject(4);

            const string predicted3 = "Project1;Project2;ProjectX";

            var projects3 = await projectsServiceProvider.GetAllProjects();
            var actual3 = string.Join(';', projects3.Select(x => x.Name));

            Assert.AreEqual(predicted3, actual3);

            //test AddProjectMember(int projectMemberId), GetAllProjectMembers(int projectId)

            await teamsServiceProvider.CreateTeam(new() { Id = 1, Name = "Student1" });

            var signupformdata1 = new SignUpFormData
            {
                Login = "student1",
                Email = "student1@gmail.com",
                Password = "password",
                ConfirmPassword = "password",
            };

            var signupformdata2 = new SignUpFormData
            {
                Login = "student2",
                Email = "student2@gmail.com",
                Password = "password",
                ConfirmPassword = "password"
            };

            await userAccountServiceProvider.RegisterAccount(signupformdata1);
            await userAccountServiceProvider.RegisterAccount(signupformdata2);

            await teamsServiceProvider.AddTeamMember(1, 1);
            await teamsServiceProvider.AddTeamMember(2, 1);

            const string predicted4 = "student1;student2";

            await projectsServiceProvider.AddProjectMember(1, 1);
            await projectsServiceProvider.AddProjectMember(2, 1);
            var projectMembers1 = await projectsServiceProvider.GetProjectMembers(1);
            var actual4 = string.Join(';', projectMembers1.Select(x => x.AssignedTeamMember.AssignedUser.Login));

            Assert.AreEqual(predicted4, actual4);

            //test RemoveProjectMember(int projectMemberSeatId)

            const string predicted5 = "student1";

            await projectsServiceProvider.RemoveProjectMember(2);
            var projectMembers2 = await projectsServiceProvider.GetProjectMembers(1);
            var actual5 = string.Join(';', projectMembers2.Select(x => x.AssignedTeamMember.AssignedUser.Login));

            Assert.AreEqual(predicted5, actual5);

            //test GetAllProjectsOfTeamMember(int teamMemberId)

            await projectsServiceProvider.AddProjectMember(1, 2);
            await projectsServiceProvider.AddProjectMember(1, 3);

            const string predicted6 = "Project1;Project2;ProjectX";

            var projects6 = await projectsServiceProvider.GetProjectsOfTeamMember(1);
            var actual6 = string.Join(';', projects6.Select(x => x.Project.Name));

            Assert.AreEqual(predicted6, actual6);
        }
    }
}