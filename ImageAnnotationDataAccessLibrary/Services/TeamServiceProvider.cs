﻿using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Exceptions;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation;
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

        public TeamServiceProvider(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task CreateTeam(Team team)
        {
            //var teamName = team.TeamName;
            //if (GetTeam(teamName) is { })
            //{
            //    throw new TeamNameIsAlreadyTakenException(teamName);
            //}

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            await dbContext.Teams.AddAsync(team);
            await dbContext.SaveChangesAsync();
        }


        public async Task DeleteTeam(int teamID) 
        {
            var team = new Team
            {
                Id = teamID,
            };

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            dbContext.Teams.Remove(team);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeam(int teamId, Team team)
        {
            var TeamName = team.Name;
            //if (GetTeam(TeamName) is { })
            //{
            //    throw new TeamNameIsAlreadyTakenException(TeamName);
            //}

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var updatedTeam = dbContext.Teams.Where(t => t.Id == teamId).FirstOrDefault();
            if (updatedTeam == null)
            {
                throw new TeamDoesNotExistException(teamId);
            }

            updatedTeam.Name = TeamName;
            await dbContext.SaveChangesAsync();
        }

        private async Task<Team?> GetTeam(string teamName)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var team = dbContext.Teams.FirstOrDefault(x => x.Name == teamName);
            return team;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            return await dbContext.Teams.ToListAsync();
        }
    }
}