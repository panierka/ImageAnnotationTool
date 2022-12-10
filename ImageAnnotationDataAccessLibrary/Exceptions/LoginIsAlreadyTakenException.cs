using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Exceptions
{
	public class LoginIsAlreadyTakenException : Exception
	{
		public LoginIsAlreadyTakenException(string login)
			: base($"User with given login '{login}' already exists") { }
	}
}
