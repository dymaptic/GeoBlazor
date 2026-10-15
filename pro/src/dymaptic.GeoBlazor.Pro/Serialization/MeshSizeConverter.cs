namespace dymaptic.GeoBlazor.Pro.Serialization;

internal class MeshSizeConverter: JsonConverter<MeshSize>
{
    public override MeshSize? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                return new MeshSize(reader.GetDouble());
            case JsonTokenType.StartObject:
                double? width = null;
                double? height = null;
                double? depth = null;
    
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        break;
            
                    if (reader.TokenType != JsonTokenType.PropertyName)
                        continue;
            
                    string? propertyName = reader.GetString()?.ToLower();
                    reader.Read();
        
                    switch (propertyName)
                    {
                        case "width":
                            if (reader.TryGetDouble(out double widthVal))
                            {
                                width = widthVal;
                            }
                            break;
                        case "height":
                            if (reader.TryGetDouble(out double heightVal))
                            {
                                height = heightVal;
                            }
                            break;
                        case "depth":
                            if (reader.TryGetDouble(out double depthVal))
                            {
                                depth = depthVal;
                            }
                            break;
                    }
                }
                return new MeshSize(width, height, depth);
            default:
                return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, MeshSize value, JsonSerializerOptions options)
    {
        if (value.Value is not null)
        {
            writer.WriteNumberValue(value.Value.Value);
        }
        else
        {
            writer.WriteStartObject();
            if (value.Width is not null)
            {
                writer.WriteNumber("width", value.Width.Value);
            }
            if (value.Height is not null)
            {
                writer.WriteNumber("height", value.Height.Value);
            }
            if (value.Depth is not null)
            {
                writer.WriteNumber("depth", value.Depth.Value);
            }
            writer.WriteEndObject();
        }
    }
}