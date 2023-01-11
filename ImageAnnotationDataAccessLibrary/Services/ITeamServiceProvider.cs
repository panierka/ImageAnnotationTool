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

        public Task<List<Team>> GetAllTeams();

        public Task AddTeamMember(int accountId, int teamId);

        public Task RemoveTeamMember(int teamMemberSeatId);

        public Task<List<TeamMemberSeat>> GetAllTeamMembers(int teamId);

        //public Task<List<Team>> GetAllTeamsOfUserAccount(int accountId);
    }
}
