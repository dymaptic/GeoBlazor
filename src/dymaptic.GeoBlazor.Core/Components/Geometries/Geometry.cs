using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     The base class for geometry objects. This class has no constructor. To construct geometries see <see cref="Point"/>, <see cref="PolyLine"/>, or <see cref="Polygon"/>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html">ArcGIS JS API</a>
/// </summary>
[JsonConverter(typeof(GeometryConverter))]
public class Geometry : MapComponent
{
    /// <summary>
    ///     The <see cref="Extent"/> of the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; set; }

    /// <summary>
    ///     The <see cref="SpatialReference"/> of the geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <summary>
    ///     The Geometry "type", used internally to render.
    /// </summary>
    public virtual string Type => default!;

    /// <inheritdoc />
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
                // ReSharper disable once RedundantCast
                if (!((object)spatialReference).Equals(SpatialReference))
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

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Extent?.ValidateRequiredChildren();
        SpatialReference?.ValidateRequiredChildren();
    }
}

internal class GeometryConverter : JsonConverter<Geometry>
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

/// <summary>
///     Possible types of geometries
/// </summary>
[JsonConverter(typeof(GeometryTypeConverter))]
public enum GeometryType
{
#pragma warning disable CS1591
    Point,
    Multipoint,
    Polyline,
    Polygon,
    Multipatch,
    Mesh
#pragma warning restore CS1591
}

internal class GeometryTypeConverter : JsonConverter<GeometryType>
{
    public override GeometryType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, GeometryType value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(GeometryType), value);
        writer.WriteRawValue($"\"{stringVal?.ToLower()}\"");
    }
}