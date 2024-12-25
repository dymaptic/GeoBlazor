namespace dymaptic.GeoBlazor.Core.Serialization;

internal class VisualVariableConverter : JsonConverter<VisualVariable>
{
    public override VisualVariable? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                case "size":
                    return JsonSerializer.Deserialize<SizeVariable>(ref cloneReader, newOptions);
                case "color":
                    return JsonSerializer.Deserialize<ColorVariable>(ref cloneReader, newOptions);
                case "opacity":
                    return JsonSerializer.Deserialize<OpacityVariable>(ref cloneReader, newOptions);
                case null:
                    return null;
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, VisualVariable value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}