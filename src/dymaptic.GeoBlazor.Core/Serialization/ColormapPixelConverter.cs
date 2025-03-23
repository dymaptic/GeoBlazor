namespace dymaptic.GeoBlazor.Core.Serialization;

public class ColormapPixelConverter: JsonConverter<ColormapPixel>
{
    public override ColormapPixel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            double[]? values = JsonSerializer.Deserialize<double[]>(ref reader, options);

            switch (values?.Length)
            {
                case 1:
                    return new ColormapPixel(values[0], 0, 0, 0);
                case 2:
                    return new ColormapPixel(values[0], values[1], 0, 0);
                case 3:
                    return new ColormapPixel(values[0], values[1], values[2], 0);
                case 4:
                    return new ColormapPixel(values[0], values[1], values[2], values[3]);
            }
        }
        
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            double value = 0;
            double red = 0;
            double green = 0;
            double blue = 0;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        string? propertyName = reader.GetString();
                        reader.Read();
                        switch (propertyName)
                        {
                            case "value":
                                value = reader.GetDouble();
                                break;
                            case "red":
                                red = reader.GetDouble();
                                break;
                            case "green":
                                green = reader.GetDouble();
                                break;
                            case "blue":
                                blue = reader.GetDouble();
                                break;
                        }

                        break;
                    case JsonTokenType.EndObject:
                        return new ColormapPixel(value, red, green, blue);
                }
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, ColormapPixel value, JsonSerializerOptions options)
    {
        writer.WriteRawValue($"[{value.Value},{value.Red},{value.Green},{value.Blue}]");
    }
}