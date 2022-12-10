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

		public void RegisterAccount(SignUpFormData signUpFormData)
		{
			var login = signUpFormData.Login;
			if (GetUserAccount(login) is { })
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

			using var dbContext = dbContextFactory.CreateDbContext();
			dbContext.UserAccounts.Add(account);
			dbContext.SaveChanges();
		}

		private UserAccount? GetUserAccount(string login)
		{
			using var dbContext = dbContextFactory.CreateDbContext();

			var user = dbContext.UserAccounts.FirstOrDefault(x => x.Login == login);
			return user;
		} 

		public bool UserWithLoginExists(string login)
		{
			return GetUserAccount(login) is { };
		}

		public bool UserWithLoginAndPasswordExists(string loginToCheck, string passwordToCheck)
		{
			var userAccount = GetUserAccount(loginToCheck);

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
