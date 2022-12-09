using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Security.Hashing.Algorithms
{
	public class SHA256Hashing : IHashingFunctionProvider
	{
		public string Hash(string text)
		{
			var sha256 = SHA256.Create();
			var textAsByteArray = Encoding.Default.GetBytes(text);
			var hashedByteArray = sha256.ComputeHash(textAsByteArray);
			var hashedText = Convert.ToBase64String(hashedByteArray);

			return hashedText;
		}
	}
}
