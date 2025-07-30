namespace dymaptic.GeoBlazor.Core.Serialization;

internal class LayerConverter : JsonConverter<Layer>
{
    public override Layer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                    return JsonSerializer.Deserialize<FeatureLayer>(ref cloneReader, newOptions);
                case "graphics":
                    return JsonSerializer.Deserialize<GraphicsLayer>(ref cloneReader, newOptions);
                case "geo-json":
                case "geojson":
                    return JsonSerializer.Deserialize<GeoJSONLayer>(ref cloneReader, newOptions);
                case "geo-rss":
                case "georss":
                    return JsonSerializer.Deserialize<GeoRSSLayer>(ref cloneReader, newOptions);
                case "tile":
                    return JsonSerializer.Deserialize<TileLayer>(ref cloneReader, newOptions);
                case "vector-tile":
                    return JsonSerializer.Deserialize<VectorTileLayer>(ref cloneReader, newOptions);
                case "open-street-map":
                    return JsonSerializer.Deserialize<OpenStreetMapLayer>(ref cloneReader, newOptions);
                case "csv":
                    return JsonSerializer.Deserialize<CSVLayer>(ref cloneReader, newOptions);
                case "kml":
                    return JsonSerializer.Deserialize<KMLLayer>(ref cloneReader, newOptions);
                case "wcs":
                    return JsonSerializer.Deserialize<WCSLayer>(ref cloneReader, newOptions);
#pragma warning disable CS0618 // Type or member is obsolete
                case "bing-maps":
#pragma warning disable CS0618 // Type or member is obsolete
                    return JsonSerializer.Deserialize<BingMapsLayer>(ref cloneReader, newOptions);
#pragma warning restore CS0618 // Type or member is obsolete
                case "imagery":
                    return JsonSerializer.Deserialize<ImageryLayer>(ref cloneReader, newOptions);
                case "map-image":
                    return JsonSerializer.Deserialize<MapImageLayer>(ref cloneReader, newOptions);
                case "imagery-tile":
                    return JsonSerializer.Deserialize<ImageryTileLayer>(ref cloneReader, newOptions);
                case "wfs":
                    return JsonSerializer.Deserialize<WFSLayer>(ref cloneReader, newOptions);
                case "wms":
                    return JsonSerializer.Deserialize<WMSLayer>(ref cloneReader, newOptions);
                case "wmts":
                    return JsonSerializer.Deserialize<WMTSLayer>(ref cloneReader, newOptions);
                case "unsupported":
                    return JsonSerializer.Deserialize<UnsupportedLayer>(ref cloneReader, newOptions);
                case "unknown":
                    return JsonSerializer.Deserialize<UnknownLayer>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.Layers.{typeValue.ToString()!.KebabToPascalCase()}Layer";

                    try
                    {
                        Type? type = Assembly.Load("dymaptic.GeoBlazor.Pro").GetType(typeName, false, true);

                        if (type is not null)
                        {
                            return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as Layer;
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

    public override void Write(Utf8JsonWriter writer, Layer value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}
