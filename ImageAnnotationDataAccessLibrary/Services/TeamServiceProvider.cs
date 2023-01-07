using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Exceptions;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
    public class TeamServiceProvider : ITeamServiceProvider
    {
        private readonly IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;

        public void CreateTeam(Team team)
        {
            //var teamName = team.TeamName;
            //if (GetTeam(teamName) is { })
            //{
            //    throw new TeamNameIsAlreadyTakenException(teamName);
            //}

            using var dbContext = dbContextFactory.CreateDbContext();
            dbContext.Teams.AddAsync(team);
            dbContext.SaveChanges();
        }


        public void DeleteTeam(int teamID) 
        {
            var team = new Team
            {
                Id = teamID,
            };

            using var dbContext = dbContextFactory.CreateDbContext();
            dbContext.Teams.Remove(team);
            dbContext.SaveChanges();
        }

        public void UpdateTeam(int teamId, Team team)
        {
            var TeamName = team.TeamName;
            //if (GetTeam(TeamName) is { })
            //{
            //    throw new TeamNameIsAlreadyTakenException(TeamName);
            //}

            using var dbContext = dbContextFactory.CreateDbContext();
            var updatedTeam = dbContext.Teams.Where(t => t.Id == teamId).FirstOrDefault();
            if (updatedTeam == null)
            {
                throw new TeamDoesNotExistException(teamId);
            }

            updatedTeam.TeamName = TeamName;
            dbContext.SaveChanges();
        }

        private Team? GetTeam(string teamName)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            var team = dbContext.Teams.FirstOrDefault(x => x.TeamName == teamName);
            return team;
        }
    }
}
