using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Serialization
{
    public interface ISerialization<T> where T : class
    {
        public string Serialize (T obj);
    }
}
