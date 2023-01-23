using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public interface ITeamServiceProvider
    {
        public Task CreateTeam(Team team);

        public Task DeleteTeam(int teamId);

        public Task UpdateTeam(int teamId, Team team);
        public Task<Team?> GetTeam(string teamName);
        public Task<Team?> GetTeamById(int teamID);
        public Task<List<Team>> GetAllTeams();

        public Task AddTeamMember(int accountId, int teamId);

        public Task RemoveTeamMember(int teamMemberSeatId);

        public Task<List<TeamMemberSeat>> GetTeamMembers(int teamId);

        public Task<List<TeamMemberSeat>> GetTeamsOfUserAccount(int accountId);

        public Task<TeamMemberSeat?> GetTeamMember(int accountId, int teamId);

        public Task SetTeamMembersRole(int accountId, int teamId, TeamMemberSeat.TeamRole role);
    }
}
