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

namespace ImageAnnotationToolDataAccessLibrary.Services
{
	public class UserAccountsService
	{
		private IDbContextFactory<ImageAnnotationToolContext> dbContextFactory;
		private IHashProvider? hashProvider;

		public UserAccountsService(IDbContextFactory<ImageAnnotationToolContext> dbContextFactory, IHashProvider hashProvider)
		{
			this.dbContextFactory = dbContextFactory;
			this.hashProvider = hashProvider;
		}

		public async void RegisterAccount(SignUpFormData signUpFormData)
		{
			var dbContextTask = dbContextFactory.CreateDbContextAsync();
			var salt = string.Empty;
			var hashedPassword = hashProvider?.CreateHash(signUpFormData.Password, out salt)
				?? signUpFormData.Password;
			
			var account = new UserAccount
			{
				Email = signUpFormData.Email,
				Login = signUpFormData.Login,
				Password = hashedPassword,
				Salt = salt
			};
		}
	}
}
