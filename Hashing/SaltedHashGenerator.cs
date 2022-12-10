using Security.Hashing;
using Security.Salting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
	public class SaltedHashGenerator : IHashGenerator
	{
		private readonly IHashingFunctionProvider hashingFunctionProvider;

		public SaltedHashGenerator(IHashingFunctionProvider hashingFunctionProvider, ISaltProvider saltProvider)
		{
			this.hashingFunctionProvider = hashingFunctionProvider;
		}

		public string CreateHash(string plainText, string salt)
		{
			var saltedText = string.Format("{0}{1}", plainText, salt);
			var hash = hashingFunctionProvider.Hash(saltedText);

			return hash;
		}
	}
}
