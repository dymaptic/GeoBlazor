using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

[JsonConverter(typeof(GeometryConverter))]
public class Geometry : MapComponent
{
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasM { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasZ { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    public virtual string Type => default!;
    
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent extent:
                if (!extent.Equals(Extent))
                {
                    Extent = extent;
                    await UpdateComponent();
                }

                break;
            case SpatialReference spatialReference:
                if (!((Object)spatialReference).Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
                    await UpdateComponent();
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Extent _:
                Extent = null;

                break;
            case SpatialReference _:
                SpatialReference = null;
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Extent?.ValidateRequiredChildren();
        SpatialReference?.ValidateRequiredChildren();
    }
}

public class GeometryConverter : JsonConverter<Geometry>
{
    public override Geometry? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        Utf8JsonReader cloneReader = reader;
        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.ContainsKey("type"))
        {
            switch (temp["type"]?.ToString())
            {
                case "extent":
                    return JsonSerializer.Deserialize<Extent>(ref cloneReader, newOptions);
                case "point":
                    return JsonSerializer.Deserialize<Point>(ref cloneReader, newOptions);
                case "polygon":
                    return JsonSerializer.Deserialize<Polygon>(ref cloneReader, newOptions);
                case "polyline":
                    return JsonSerializer.Deserialize<PolyLine>(ref cloneReader, newOptions);
            }
        }

        if (temp.ContainsKey("rings"))
        {
            return JsonSerializer.Deserialize<Polygon>(ref cloneReader, newOptions);
        }

        if (temp.ContainsKey("paths"))
        {
            return JsonSerializer.Deserialize<PolyLine>(ref cloneReader, newOptions);
        }

        if (temp.ContainsKey("latitude"))
        {
            return JsonSerializer.Deserialize<Point>(ref cloneReader, newOptions);
        }

        if (temp.ContainsKey("xmax"))
        {
            return JsonSerializer.Deserialize<Extent>(ref cloneReader, newOptions);
        }

        return null;
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