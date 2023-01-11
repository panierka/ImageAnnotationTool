using ImageAnnotationToolDataAccessLibrary.Services;
using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Security.Salting;
using Security;
using Security.Hashing;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;

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
            var saltProvider = new RngSalting();
            var hashingfunctionProvider = new SHA256Hashing();
            var hashGenerator = new SaltedHashGenerator(hashingfunctionProvider, saltProvider);
            var userAccountServiceProvider = new UserAccountsServiceProvider(mockDbFactory.Object, saltProvider, hashGenerator);

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


            await teamsServiceProvider.DeleteTeam(4);

            const string predicted3 = "Student1;Student2;StudentX";

            var teams3 = await teamsServiceProvider.GetAllTeams();
            var actual3 = string.Join(';', teams3.Select(x => x.Name));

            Assert.AreEqual(predicted3, actual3);


            //test AddTeamMember(int accountId, int teamId)
            //test RemoveTeamMember(int teamMemberSeatId)
            //test GetAllTeamMembers(int teamId)


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

            var userAccount1 = new UserAccount
            {
                Id = 1,
                Login = "student1",
                Email = "student1@gmail.com",
                Password = "password"
            };

            var userAccount2 = new UserAccount
            {
                Id = 2,
                Login = "student2",
                Email = "student2@gmail.com",
                Password = "password"
            };

            var team1 = new Team
            {
                Id = 1,
                Name = "Student1"
            };

            await teamsServiceProvider.AddTeamMember(1, 1);
            await teamsServiceProvider.AddTeamMember(2, 1);

            var teamMemberSeat1 = new TeamMemberSeat
            {
                Id = 1,
                AssignedUser = userAccount1,
                Team = team1
            };

            var teamMemberSeat2 = new TeamMemberSeat
            {
                Id = 2,
                AssignedUser = userAccount2,
                Team = team1
            };

            string predicted4 = "student1;student2";
            var teamMembers1 = await teamsServiceProvider.GetAllTeamMembers(1);
            var actual4 = string.Join(';', teamMembers1.Select(x => x.AssignedUser.Login));

            Assert.AreEqual(predicted4, actual4);
        }
    }
}