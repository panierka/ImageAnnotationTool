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
		public void RegisterAccount(SignUpFormData signUpFormData);

		public bool UserWithLoginExists(string login);

		public bool UserWithLoginAndPasswordExists(string loginToCheck, string passwordToCheck);
	}
}
