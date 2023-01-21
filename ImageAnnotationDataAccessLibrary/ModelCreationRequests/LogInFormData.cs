using System.ComponentModel.DataAnnotations;

namespace ImageAnnotationToolDataAccessLibrary.ModelCreationRequests
{
	public class LogInFormData
	{
		[Required(ErrorMessage = "Login - Pole wymagane")]

		public string Username { get; set; }

		[Required(ErrorMessage = "Hasło - Pole wymagane")]

		public string Password { get; set; }

		public string ErrorMessage { get; set; }


	}
}
