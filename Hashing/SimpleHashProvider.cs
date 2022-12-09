using Security.Hashing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
	public class SimpleHashProvider : IHashProvider
	{
		private IHashingFunctionProvider hashingFunctionProvider;

		public SimpleHashProvider(IHashingFunctionProvider hashingFunctionProvider)
		{
			this.hashingFunctionProvider = hashingFunctionProvider;
		}

		public string CreateHash(string plainText)
		{
			var hash = hashingFunctionProvider.Hash(plainText);
			return hash;
		}
	}
}
