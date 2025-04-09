namespace dymaptic.GeoBlazor.Core.Serialization;

internal class WidgetConverter : JsonConverter<Widget>
{
    public override Widget? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                case "basemap-gallery":
                    return JsonSerializer.Deserialize<BasemapGalleryWidget>(ref cloneReader, newOptions);
                case "basemap-layer-list":
                    return JsonSerializer.Deserialize<BasemapLayerListWidget>(ref cloneReader, newOptions);
                case "basemap-toggle":
                    return JsonSerializer.Deserialize<BasemapToggleWidget>(ref cloneReader, newOptions);
                case "bookmarks":
                    return JsonSerializer.Deserialize<BookmarksWidget>(ref cloneReader, newOptions);
                case "compass":
                    return JsonSerializer.Deserialize<CompassWidget>(ref cloneReader, newOptions);
                case "expand":
                    return JsonSerializer.Deserialize<ExpandWidget>(ref cloneReader, newOptions);
                case "home":
                    return JsonSerializer.Deserialize<HomeWidget>(ref cloneReader, newOptions);
                case "layer-list":
                    return JsonSerializer.Deserialize<LayerListWidget>(ref cloneReader, newOptions);
                case "legend":
                    return JsonSerializer.Deserialize<LegendWidget>(ref cloneReader, newOptions);
                case "locate":
                    return JsonSerializer.Deserialize<LocateWidget>(ref cloneReader, newOptions);
                case "measurement":
                    return JsonSerializer.Deserialize<MeasurementWidget>(ref cloneReader, newOptions);
                case "popup":
                    return JsonSerializer.Deserialize<PopupWidget>(ref cloneReader, newOptions);
                case "scale-bar":
                    return JsonSerializer.Deserialize<ScaleBarWidget>(ref cloneReader, newOptions);
                case "search":
                    return JsonSerializer.Deserialize<SearchWidget>(ref cloneReader, newOptions);
                case "slider":
                    return JsonSerializer.Deserialize<SliderWidget>(ref cloneReader, newOptions);
                case "list-item-panel":
                    return JsonSerializer.Deserialize<ListItemPanelWidget>(ref cloneReader, newOptions);
                case "distance-measurement-2d":
                    return JsonSerializer.Deserialize<DistanceMeasurement2DWidget>(ref cloneReader, newOptions);
                case "zoom":
                    return JsonSerializer.Deserialize<ZoomWidget>(ref cloneReader, newOptions);
                case "grid-controls":
                    return JsonSerializer.Deserialize<GridControlsWidget>(ref cloneReader, newOptions);
                case null:
                    return null;
                default:
                    // look for the type in GeoBlazor Pro
                    string typeName = 
                        $"dymaptic.GeoBlazor.Pro.Components.Widgets.{typeValue.ToString()!.KebabToPascalCase()}Widget";

                    try
                    {
                        Type? type = Assembly.Load("dymaptic.GeoBlazor.Pro").GetType(typeName, false, true);

                        if (type is not null)
                        {
                            return JsonSerializer.Deserialize(ref cloneReader, type, newOptions) as Widget;
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

    public override void Write(Utf8JsonWriter writer, Widget value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), options));
    }
}
