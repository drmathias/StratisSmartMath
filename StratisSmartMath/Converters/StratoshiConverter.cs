using Newtonsoft.Json;
using System;

namespace StratisSmartMath.Converters
{
    public class StratoshiConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Stratoshi);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return (Stratoshi)reader.Value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((ulong)value);
        }
    }
}
