using FluentValidation;
using ImageAnnotationToolDataAccessLibrary.ModelCreationRequests;
using ImageAnnotationToolDataAccessLibrary.Services;

namespace ImageAnnotationTool.Validation
{
	internal class SignUpFormDataValidation : AbstractValidator<SignUpFormData>
	{
		private readonly IUserAccountsServiceProvider userAccountsServiceProvider;

		public SignUpFormDataValidation(IUserAccountsServiceProvider userAccountsServiceProvider)
		{
			this.userAccountsServiceProvider = userAccountsServiceProvider;
		}
	}
}
