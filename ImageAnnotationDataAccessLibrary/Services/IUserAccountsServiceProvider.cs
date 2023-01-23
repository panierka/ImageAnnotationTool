using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Services
{
	public interface IUserAccountsServiceProvider
	{
		public Task RegisterAccount(SignUpFormData signUpFormData);

		public Task DeleteAccount(int accountId);

		public Task UpdateAccount(int accountId, SignUpFormData signUpFormData);

		public Task<bool> UserWithLoginExists(string login);

		public Task<bool> UserWithLoginAndPasswordExists(string loginToCheck, string passwordToCheck);
	}
}
