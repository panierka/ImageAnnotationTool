using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Serialization
{
    public interface IDeserialization<T> where T : class
    {
        public T? Deserialize(string fileContent);
    }
}
