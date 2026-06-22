namespace dymaptic.GeoBlazor.Core.Serialization;

internal class GeometryConverter : JsonConverter<Geometry>
{
    public override Geometry? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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

        Geometry? geometry = null;

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "extent":
                    geometry = JsonSerializer.Deserialize<Extent>(ref cloneReader, newOptions);
                    break;
                case "point":
                    geometry = JsonSerializer.Deserialize<Point>(ref cloneReader, newOptions);
                    break;
                case "polygon":
                    geometry = JsonSerializer.Deserialize<Polygon>(ref cloneReader, newOptions);
                    break;
                case "polyline":
                    geometry = JsonSerializer.Deserialize<Polyline>(ref cloneReader, newOptions);
                    break;
                case "multipoint":
                    // multipoint is in GeoBlazor Pro and must be loaded via Reflection
                    Type? multipointType = Type.GetType("dymaptic.GeoBlazor.Pro.Components.Geometries.Multipoint, " +
                        "dymaptic.GeoBlazor.Pro");
                    if (multipointType is not null)
                    {
                        geometry = (Geometry?)JsonSerializer.Deserialize(ref cloneReader, multipointType, newOptions);
                    }

                    break;
            }
        }

        if (geometry is null)
        {
            if (temp.ContainsKey("rings"))
            {
                geometry = JsonSerializer.Deserialize<Polygon>(ref cloneReader, newOptions);
            }
            else if (temp.ContainsKey("paths"))
            {
                geometry = JsonSerializer.Deserialize<Polyline>(ref cloneReader, newOptions);
            }
            else if (temp.ContainsKey("latitude") || temp.ContainsKey("x"))
            {
                geometry = JsonSerializer.Deserialize<Point>(ref cloneReader, newOptions);
            }
            else if (temp.ContainsKey("xmax"))
            {
                geometry = JsonSerializer.Deserialize<Extent>(ref cloneReader, newOptions);
            }
        }

        // Operator results (e.g. Union) send a computed `extent`, but deserializing the concrete
        // geometry type does not carry the nested Extent through; populate it explicitly so callers
        // (e.g. map.GoTo(extent)) get a usable Extent.
        if (geometry is not null and not Extent
            && geometry.Extent is null
            && temp.TryGetValue("extent", out object? extentValue)
            && extentValue is JsonElement { ValueKind: JsonValueKind.Object } extentElement)
        {
            geometry.Extent = extentElement.Deserialize<Extent>(newOptions);
        }

        return geometry;
    }

    public override void Write(Utf8JsonWriter writer, Geometry value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}