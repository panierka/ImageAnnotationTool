using ImageAnnotationToolDataAccessLibrary.Models.ImageAnnotation.Coco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ImageAnnotationToolDataAccessLibrary.Serialization;

namespace ImageAnnotationToolDataAccessLibrary.JsonFiles
{
    public class JsonDeserialization<T> : IDeserialization<T> where T : class
    {
        public T? Deserialize(string fileContent)
        {
            T? obj = JsonConvert.DeserializeObject<T>(fileContent);

            return obj;
        }
    }
}
