using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ImageAnnotationToolDataAccessLibrary.Serialization;
using Newtonsoft.Json.Serialization;
using System.Runtime.Intrinsics.X86;

namespace ImageAnnotationToolDataAccessLibrary.JsonFiles
{
    public class JsonSerialization<T> : ISerialization<T> where T : class
    {
        public string Serialize(T item)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                Converters = new[] { new DoubleJsonConverter() }
            };

            string jsonString = JsonConvert.SerializeObject(item, settings);

            return jsonString;
        }
    }
}
