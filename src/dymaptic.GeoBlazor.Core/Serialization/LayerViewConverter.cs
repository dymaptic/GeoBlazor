using System.Runtime.CompilerServices;


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
                case "imagery-tile":
                    return JsonSerializer.Deserialize<ImageryTileLayerView>(ref cloneReader, newOptions);
                case "kml":
                    return JsonSerializer.Deserialize<KMLLayerView>(ref cloneReader, newOptions);
                case "vector-tile":
                    return JsonSerializer.Deserialize<VectorTileLayerView>(ref cloneReader, newOptions);
                case "wfs":
                    return JsonSerializer.Deserialize<WFSLayerView>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.{typeValue.ToString()!.KebabToPascalCase()}LayerView";

                    try
                    {
                        Type? type = Assembly.Load("dymaptic.GeoBlazor.Pro").GetType(typeName, false, true);

                        if (type is not null)
                        {
                            return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as LayerView;
                        }
                    }
                    catch
                    {
                        // ignore, this means we're in GeoBlazor Core
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
                    if (!Enum.TryParse(typeValue.ToString()!.KebabToPascalCase(), out LayerType layerType))
                    {
                        layerType = LayerType.Unknown;
                    }
                    
                    return new LayerView(layerType,
                        spatialReferenceSupported,
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
        switch (value)
        {
            case FeatureLayerView flv:
                JsonSerializer.Serialize(writer, flv, options);

                break;
            case CSVLayerView csvlv:
                JsonSerializer.Serialize(writer, csvlv, options);

                break;
            case GeoJSONLayerView geojsonlv:
                JsonSerializer.Serialize(writer, geojsonlv, options);

                break;
            case GeoRSSLayerView georsslv:
                JsonSerializer.Serialize(writer, georsslv, options);

                break;
            case GraphicsLayerView glv:
                JsonSerializer.Serialize(writer, glv, options);

                break;
            case ImageryLayerView ilv:
                JsonSerializer.Serialize(writer, ilv, options);

                break;
            case KMLLayerView klv: 
                JsonSerializer.Serialize(writer, klv, options);

                break;
            case WFSLayerView wfs:
                JsonSerializer.Serialize(writer, wfs, options);

                break;
            default:
                writer.WriteStartObject();
                writer.WriteString(nameof(LayerView.Type), value.Type?.ToString());

                if (value.SpatialReferenceSupported is not null)
                {
                    writer.WriteBoolean(nameof(LayerView.SpatialReferenceSupported), value.SpatialReferenceSupported.Value);
                }
        
                if (value.Suspended is not null)
                {
                    writer.WriteBoolean(nameof(LayerView.Suspended), value.Suspended.Value);
                }
        
                if (value.Updating is not null)
                {
                    writer.WriteBoolean(nameof(LayerView.Updating), value.Updating.Value);
                }
        
                if (value.VisibleAtCurrentScale is not null)
                {
                    writer.WriteBoolean(nameof(LayerView.VisibleAtCurrentScale), value.VisibleAtCurrentScale.Value);
                }
        
                if (value.VisibleAtCurrentTimeExtent is not null)
                {
                    writer.WriteBoolean(nameof(LayerView.VisibleAtCurrentTimeExtent), value.VisibleAtCurrentTimeExtent.Value);
                }
        
                writer.WriteEndObject();

                break;
        }
    }
}