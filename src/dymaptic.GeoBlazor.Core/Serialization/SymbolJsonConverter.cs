namespace dymaptic.GeoBlazor.Core.Serialization;

internal class SymbolJsonConverter : JsonConverter<Symbol>
{
    public override Symbol? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // deserialize based on the subclass type
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
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
                case "simple-marker":
                    return JsonSerializer.Deserialize<SimpleMarkerSymbol>(ref cloneReader, newOptions);
                case "simple-line":
                    return JsonSerializer.Deserialize<SimpleLineSymbol>(ref cloneReader, newOptions);
                case "simple-fill":
                    return JsonSerializer.Deserialize<SimpleFillSymbol>(ref cloneReader, newOptions);
                case "picture-fill":
                    return JsonSerializer.Deserialize<PictureFillSymbol>(ref cloneReader, newOptions);
                case "picture-marker":
                    return JsonSerializer.Deserialize<PictureMarkerSymbol>(ref cloneReader, newOptions);
                case "text":
                    return JsonSerializer.Deserialize<TextSymbol>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.Symbols.{typeValue.ToString()!.KebabToPascalCase()}Symbol";

                    try
                    {
                        Type? type = Assembly.Load("dymaptic.GeoBlazor.Pro").GetType(typeName, false, true);

                        if (type is not null)
                        {
                            return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as Symbol;
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

    public override void Write(Utf8JsonWriter writer, Symbol value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}