using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
	public interface IHashGenerator
	{
		public string CreateHash(string plainText, string salt);
	}
}
