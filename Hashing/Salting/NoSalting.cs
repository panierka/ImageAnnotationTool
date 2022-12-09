using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Salting
{
	public class NoSalting : ISaltProvider
	{
		public string GetSalt(int _)
		{
			return string.Empty;
		}
	}
}
