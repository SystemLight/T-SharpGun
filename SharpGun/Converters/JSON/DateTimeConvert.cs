using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SharpGun.Converters.JSON
{
    public class DateTimeConvert : JsonConverter<DateTime?>
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            return string.IsNullOrEmpty(reader.GetString()) ? default(DateTime?) : DateTime.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options) {
            writer.WriteStringValue(value?.ToString(DateTimeFormat));
        }
    }
}
