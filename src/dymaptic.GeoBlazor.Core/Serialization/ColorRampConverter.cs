namespace dymaptic.GeoBlazor.Core.Serialization;

internal class ColorRampConverter : JsonConverter<ColorRamp>
{
    public override ColorRamp? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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

        if (temp.TryGetValue("colorRampType", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "algorithmic":
                    return JsonSerializer.Deserialize<AlgorithmicColorRamp>(ref cloneReader, newOptions);
                case "multipart":
                    return JsonSerializer.Deserialize<MultipartColorRamp>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, ColorRamp value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}