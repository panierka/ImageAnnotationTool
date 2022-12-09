using Security.Hashing;
using Security.Salting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
	public class SaltedHashProvider : IHashProvider
	{
		private IHashingFunctionProvider hashingFunctionProvider;
		private ISaltProvider saltProvider;

		private int SALT_SIZE = 16;

		public SaltedHashProvider(IHashingFunctionProvider hashingFunctionProvider, ISaltProvider saltProvider)
		{
			this.hashingFunctionProvider = hashingFunctionProvider;
			this.saltProvider = saltProvider;
		}

		public string CreateHash(string plainText)
		{
			var salt = saltProvider.GetSalt(length: SALT_SIZE);
			var saltedText = string.Format("{0}{1}", plainText, salt);
			var hash = hashingFunctionProvider.Hash(saltedText);

			return hash;
		}
	}
}
