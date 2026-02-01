namespace dymaptic.GeoBlazor.Core.Serialization;

internal class VisualVariableConverter : JsonConverter<VisualVariable>
{
    public override VisualVariable? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader,
                GeoBlazorSerialization.JsonSerializerOptions) is not IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out var typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "size":
                    return JsonSerializer.Deserialize<SizeVariable>(ref cloneReader,
                        GeoBlazorSerialization.JsonSerializerOptions);
                case "color":
                    return JsonSerializer.Deserialize<ColorVariable>(ref cloneReader,
                        GeoBlazorSerialization.JsonSerializerOptions);
                case "opacity":
                    return JsonSerializer.Deserialize<OpacityVariable>(ref cloneReader,
                        GeoBlazorSerialization.JsonSerializerOptions);
                case null:
                    return null;
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, VisualVariable value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), GeoBlazorSerialization.JsonSerializerOptions);
    }
}