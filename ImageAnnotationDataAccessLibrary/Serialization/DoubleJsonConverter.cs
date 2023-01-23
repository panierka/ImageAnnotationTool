using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Serialization
{
    public class DoubleJsonConverter : JsonConverter<double>
    {
        public override double ReadJson(JsonReader reader, Type objectType,
            double existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer,
            double value, JsonSerializer serializer)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            writer.WriteRawValue(value.ToString(nfi));
        }
    }
}
