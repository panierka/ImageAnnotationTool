using ImageAnnotationToolDataAccessLibrary.DataAccess;
using ImageAnnotationToolDataAccessLibrary.Models.TeamManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using Security;
using Security.Salting;
using System.Data.Common;
using ImageAnnotationToolDataAccessLibrary.Exceptions;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
	public class UserAccountsServiceProvider : IUserAccountsServiceProvider
	{
		private readonly IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;
		private readonly ISaltProvider saltProvider;
		private readonly IHashGenerator? hashProvider;

		private const int SALT_SIZE = 16;

		public UserAccountsServiceProvider(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory, ISaltProvider saltProvider, IHashGenerator hashProvider)
		{
			this.dbContextFactory = dbContextFactory;
			this.saltProvider = saltProvider;
			this.hashProvider = hashProvider;
		}

		public async Task RegisterAccount(SignUpFormData signUpFormData)
		{
			var login = signUpFormData.Login;
			if (await GetUserAccount(login) is { })
			{
				throw new LoginIsAlreadyTakenException(login);
			}

			var salt = saltProvider.GetSalt(maxLength: SALT_SIZE);
			var hashedPassword = HashPassword(signUpFormData.Password, salt);
			
			var account = new UserAccount
			{
				Email = signUpFormData.Email,
				Login = login,
				Password = hashedPassword,
				Salt = salt,
			};

			using var dbContext = await dbContextFactory.CreateDbContextAsync();
			await dbContext.UserAccounts.AddAsync(account);
			await dbContext.SaveChangesAsync();
		}

        public async Task DeleteAccount(int accountId)
		{
            var account = new UserAccount
            {
                Id = accountId,
            };

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            dbContext.UserAccounts.Attach(account);
            dbContext.UserAccounts.Remove(account);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAccount(int accountId, SignUpFormData signUpFormData)
		{
            var login = signUpFormData.Login;
            if (await GetUserAccount(login) is { })
            {
                throw new LoginIsAlreadyTakenException(login);
            }

            var salt = saltProvider.GetSalt(maxLength: SALT_SIZE);
            var hashedPassword = HashPassword(signUpFormData.Password, salt);

            var account = new UserAccount
            {
                Email = signUpFormData.Email,
                Login = login,
                Password = hashedPassword,
                Salt = salt,
            };

            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var updatedTeam = dbContext.UserAccounts.Where(t => t.Id == accountId).FirstOrDefault();
			updatedTeam = account;
            await dbContext.SaveChangesAsync();
        }

        private async Task<UserAccount?> GetUserAccount(string login)
		{
			using var dbContext = await dbContextFactory.CreateDbContextAsync();

			var user = dbContext.UserAccounts.FirstOrDefault(x => x.Login == login);
			return user;
		}
		public async Task<int?> GetUserAccountId(string login)
        {
			using var dbContext = await dbContextFactory.CreateDbContextAsync();
			var userId = GetUserAccount(login).Id;
			return userId;
		}


		public async Task<bool> UserWithLoginExists(string login)
		{
			return await GetUserAccount(login) is { };
		}

        public async Task<bool> UserWithLoginAndPasswordExists(string loginToCheck, string passwordToCheck)
		{
			var userAccount = await GetUserAccount(loginToCheck);

			if (userAccount is not { })
			{
				return false;
			}

			var salt = userAccount.Salt;
			var hashedPassword = hashProvider?.CreateHash(passwordToCheck, salt);
			return hashedPassword == userAccount.Password;
		}

		private string HashPassword(string password, string salt)
		{
			return hashProvider?.CreateHash(password, salt) ?? password;
		}
	}
}
