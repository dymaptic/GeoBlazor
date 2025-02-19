namespace dymaptic.GeoBlazor.Core.Serialization;

internal class LayerViewConverter : JsonConverter<LayerView>
{
    public override LayerView? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                case "feature":
                    return JsonSerializer.Deserialize<FeatureLayerView>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.{typeValue.ToString()!.KebabToPascalCase()}LayerView";
                    Type? type = Type.GetType(typeName, false, true);
                    if (type is not null)
                    {
                        return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as LayerView;
                    }

                    return new LayerView();
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, LayerView value, JsonSerializerOptions options)
    { 
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), GeoBlazorSerialization.JsonSerializerOptions));
    }
}