using System.ComponentModel.DataAnnotations;

namespace ImageAnnotationToolDataAccessLibrary.ModelCreationRequests
{
	public class SignUpFormData
	{
		[Required(ErrorMessage = "Pole wymagane")]

		public string Login { get; set; }

		[Required(ErrorMessage = "Pole wymagane")]
		[EmailAddress(ErrorMessage = "Błędny adres email")]

		public string Email { get; set; }

		private const int MINIMUM_PASSWORD_LENGTH = 8;

		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(
			int.MaxValue,
			MinimumLength = MINIMUM_PASSWORD_LENGTH,
			ErrorMessage = "Hasło musi składać się z conajmniej 8 znaków")]

		public string Password
		{
			get => password;
			set
			{
				password = value;
				ConfirmPassword = string.Empty;
			}
		}

		[Required(ErrorMessage = "Pole wymagane")]
		[Compare(nameof(Password), ErrorMessage = "Hasła muszą być jednakowe")]

		public string ConfirmPassword { get; set; }

		private string password;
	}
}
