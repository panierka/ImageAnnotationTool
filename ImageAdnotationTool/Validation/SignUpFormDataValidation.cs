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

			RuleFor(x => x.Login)
				.NotEmpty()
				.Must(BeUnique)
				.WithMessage("Ten login jest już używany");
		}

		private bool BeUnique(string login)
		{
			return !userAccountsServiceProvider.UserWithLoginExists(login);
		}
	}
}
