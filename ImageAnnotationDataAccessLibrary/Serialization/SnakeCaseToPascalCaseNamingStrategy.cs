using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Serialization
{
	internal class SnakeCaseToPascalCaseNamingStrategy : NamingStrategy
	{
		protected override string ResolvePropertyName(string name)
		{
			var segments = FromSnakeCase(name);
			var pascal = ToPascalCase(segments);

			return pascal;
		}

		private static IEnumerable<string> FromSnakeCase(string name)
		{
			return name.Split('_');
		}

		private static string ToPascalCase(IEnumerable<string> components)
		{
			return string.Join("", components.Select(Capitalize));
		}

		private static string Capitalize(string word)
		{
			return $"{word[0].ToString().ToUpper()}{word[1..]}";
		}
	}
}
