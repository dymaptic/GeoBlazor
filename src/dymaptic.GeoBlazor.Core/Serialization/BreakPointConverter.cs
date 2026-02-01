namespace dymaptic.GeoBlazor.Core.Serialization;

internal class BreakPointConverter : JsonConverter<BreakPoint>
{
    public override BreakPoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.True:
                return new BreakPoint(true);
            case JsonTokenType.False:
                return new BreakPoint(false);
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.StartObject:
                double? width = null;
                double? height = null;

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        string? propertyName = reader.GetString();
                        reader.Read();

                        switch (propertyName)
                        {
                            case nameof(BreakPoint.Width):
                                width = reader.GetDouble();

                                break;
                            case nameof(BreakPoint.Height):
                                height = reader.GetDouble();

                                break;
                        }
                    }
                    else if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        break;
                    }
                    else
                    {
                        reader.Skip();
                    }
                }

                return new BreakPoint(width, height);
            default:
                throw new InvalidOperationException("Unexpected token type for BreakPoint conversion.");
        }
    }

    public override void Write(Utf8JsonWriter writer, BreakPoint value, JsonSerializerOptions options)
    {
        if (value.BoolValue.HasValue)
        {
            JsonSerializer.Serialize(writer, value.BoolValue.Value, options);
        }
        else
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}