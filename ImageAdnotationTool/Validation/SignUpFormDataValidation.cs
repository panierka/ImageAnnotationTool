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
				.MustAsync(BeUnique)
				.WithMessage("Ten login jest już używany");
		}

		private async Task<bool> BeUnique(string login, CancellationToken _)
		{
			return !(await userAccountsServiceProvider.UserWithLoginExists(login));
		}
	}
}
