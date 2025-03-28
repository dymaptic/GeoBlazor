namespace dymaptic.GeoBlazor.Core.Serialization;

internal class ImageryRendererConverter : JsonConverter<IImageryRenderer>
{
    public override IImageryRenderer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "raster-stretch":
                    return JsonSerializer.Deserialize<RasterStretchRenderer>(ref cloneReader, newOptions);
                case "unique-value":
                    return JsonSerializer.Deserialize<UniqueValueRenderer>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.Renderers.{typeValue.ToString()!.KebabToPascalCase()}Renderer";

                    try
                    {
                        Type? type = Assembly.Load("dymaptic.GeoBlazor.Pro").GetType(typeName, false, true);

                        if (type is not null)
                        {
                            return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as IImageryRenderer;
                        }
                    }
                    catch
                    {
                        // ignore, this means we're in GeoBlazor Core
                    }

                    break;
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, IImageryRenderer value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}