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
                case "csv":
                    return JsonSerializer.Deserialize<CSVLayerView>(ref cloneReader, newOptions);
                case "geojson":
                    return JsonSerializer.Deserialize<GeoJSONLayerView>(ref cloneReader, newOptions);
                case "geo-rss":
                    return JsonSerializer.Deserialize<GeoRSSLayerView>(ref cloneReader, newOptions);
                case "graphics":
                    return JsonSerializer.Deserialize<GraphicsLayerView>(ref cloneReader, newOptions);
                case "imagery":
                    return JsonSerializer.Deserialize<ImageryLayerView>(ref cloneReader, newOptions);
                case "kml":
                    return JsonSerializer.Deserialize<KMLLayerView>(ref cloneReader, newOptions);
                case "wfs":
                    return JsonSerializer.Deserialize<WFSLayerView>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.{typeValue.ToString()!.KebabToPascalCase()}LayerView";
                    Type? type = Assembly.Load("dymaptic.GeoBlazor.Pro").GetType(typeName, false, true);
                    if (type is not null)
                    {
                        return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as LayerView;
                    }

                    temp.TryGetValue("spatialReferenceSupported", out object? spatialReferenceSupportedValue);
                    bool.TryParse(spatialReferenceSupportedValue?.ToString(), out bool spatialReferenceSupported);
                    temp.TryGetValue("suspended", out object? suspendedValue);
                    bool.TryParse(suspendedValue?.ToString(), out bool suspended);
                    temp.TryGetValue("updating", out object? updatingValue);
                    bool.TryParse(updatingValue?.ToString(), out bool updating);
                    temp.TryGetValue("visibleAtCurrentScale", out object? visibleAtCurrentScaleValue);
                    bool.TryParse(visibleAtCurrentScaleValue?.ToString(), out bool visibleAtCurrentScale);
                    temp.TryGetValue("visibleAtCurrentTimeExtent", out object? visibleAtCurrentTimeExtentValue);
                    bool.TryParse(visibleAtCurrentTimeExtentValue?.ToString(), out bool visibleAtCurrentTimeExtent);
                    return new LayerView(spatialReferenceSupported,
                        suspended,
                        updating,
                        visibleAtCurrentScale,
                        visibleAtCurrentTimeExtent);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, LayerView value, JsonSerializerOptions options)
    { 
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), GeoBlazorSerialization.JsonSerializerOptions));
    }
}