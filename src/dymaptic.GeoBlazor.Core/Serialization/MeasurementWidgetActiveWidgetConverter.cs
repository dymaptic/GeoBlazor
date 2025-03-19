namespace dymaptic.GeoBlazor.Core.Serialization;

internal class MeasurementWidgetActiveWidgetConverter : JsonConverter<IMeasurementWidgetActiveWidget>
{
    public override IMeasurementWidgetActiveWidget? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                case "area-measurement-2d":
                    return JsonSerializer.Deserialize<AreaMeasurement2DWidget>(ref cloneReader, newOptions);
                case "distance-measurement-2d":
                    return JsonSerializer.Deserialize<DistanceMeasurement2DWidget>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.Widgets.{typeValue.ToString()!.KebabToPascalCase()}Widget";
                    Type? type = Assembly.Load("dymaptic.GeoBlazor.Pro").GetType(typeName, false, true);
                    if (type is not null)
                    {
                        return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as IMeasurementWidgetActiveWidget;
                    }

                    break;
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, IMeasurementWidgetActiveWidget value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), options));
    }
}