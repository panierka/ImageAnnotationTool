using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
	public interface IHashProvider
	{
		public string CreateHash(string plainText);
	}
}
