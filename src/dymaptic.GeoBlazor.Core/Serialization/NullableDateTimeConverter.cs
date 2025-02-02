namespace dymaptic.GeoBlazor.Core.Serialization;

internal class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            long timestamp = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            if (DateTime.TryParse(reader.GetString(), out DateTime dateTime))
            {
                return dateTime;
            }
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteNumberValue(((DateTimeOffset)value.Value).ToUnixTimeSeconds());
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}