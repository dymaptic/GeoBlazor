namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(TimeExtentConverter))]
public partial class TimeExtent: MapComponent
{

}

internal class TimeExtentConverter: JsonConverter<TimeExtent>
{
    public override TimeExtent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        DateTime start = DateTime.MinValue;
        DateTime end = DateTime.MinValue;
        while (reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string? propertyName = reader.GetString();
                reader.Read();
                if (reader.TokenType == JsonTokenType.String)
                {
                    switch (propertyName)
                    {
                        case "start":
                            start = DateTime.Parse(reader.GetString()!);
                            break;
                        case "end":
                            end = DateTime.Parse(reader.GetString()!);
                            break;
                    }
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    switch (propertyName)
                    {
                        case "start":
                            start = DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime;
                            break;
                        case "end":
                            end = DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime;
                            break;
                    }
                }
            }
            reader.Read();
        }
        return new TimeExtent(start, end);
    }

    public override void Write(Utf8JsonWriter writer, TimeExtent value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(new
        {
            start = value.Start,
            end = value.End
        }));
    }
}