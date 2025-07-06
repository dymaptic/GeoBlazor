namespace dymaptic.GeoBlazor.Core.Serialization;

internal class StringConverter: JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return reader.GetString();
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                return reader.GetInt64().ToString();
            case JsonTokenType.True:
                return "true";
            case JsonTokenType.False:
                return "false";
            case JsonTokenType.StartArray:
            {
                string[]? values = JsonSerializer.Deserialize<string[]>(ref reader, options);
                return values is { } ? string.Join(",", values) : null;
            }
            case JsonTokenType.StartObject:
            {
                JsonDocument doc = JsonDocument.ParseValue(ref reader);

                return doc.RootElement.ToString();
            }
            default:
                throw new JsonException();
        }
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}