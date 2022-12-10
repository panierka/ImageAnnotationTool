using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Salting
{
	public interface ISaltProvider
	{
		public string GetSalt(int maxLength);
	}
}
