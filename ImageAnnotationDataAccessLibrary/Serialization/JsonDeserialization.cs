using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ImageAnnotationToolDataAccessLibrary.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace ImageAnnotationToolDataAccessLibrary.JsonFiles
{
    public class JsonDeserialization<T> : IDeserialization<T> where T : class
    {
        public T? Deserialize(string fileContent)
        {
            DefaultContractResolver contractResolver = new()
			{
                NamingStrategy = new SnakeCaseToPascalCaseNamingStrategy()
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
			};

            T? obj = JsonConvert.DeserializeObject<T>(fileContent, settings);

            return obj;
        }
    }
}
