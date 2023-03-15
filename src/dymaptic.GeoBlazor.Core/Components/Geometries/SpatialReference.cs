using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     Defines the spatial reference of a view, layer, or method parameters. This indicates the projected or geographic
///     coordinate system used to locate geographic features in the map. Each projected and geographic coordinate system is
///     defined by either a well-known ID (WKID) or a definition string (WKT). Note that for versions prior to ArcGIS 10,
///     only WKID was supported. For a full list of supported spatial reference IDs and their corresponding definition
///     strings, see Using spatial references.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
[JsonConverter(typeof(SpatialReferenceConverter))]
public class SpatialReference : MapComponent, IEquatable<SpatialReference>
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public SpatialReference()
    {
    }

    /// <summary>
    ///     Creates a new SpatialReference in code with a Wkid
    /// </summary>
    /// <param name="wkid">
    ///     The well-known Id for the spatial reference
    /// </param>
    public SpatialReference(int wkid)
    {
#pragma warning disable BL0005
        Wkid = wkid;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     Compares two SpatialReference objects for equality
    /// </summary>
    public static bool operator ==(SpatialReference? left, SpatialReference? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Compares two SpatialReference objects for inequality
    /// </summary>
    public static bool operator !=(SpatialReference? left, SpatialReference? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    ///     A convenience static instance for WGS84 Spatial Reference.
    /// </summary>
    [JsonIgnore]
    public static SpatialReference Wgs84 { get; set; } = new(4326);

    /// <summary>
    ///     A convenience static instance for WebMercator Spatial Reference.
    /// </summary>
    [JsonIgnore]
    public static SpatialReference WebMercator { get; set; } = new(3857);

    /// <summary>
    ///     An image coordinate system defines the spatial reference used to display the image in its original coordinates
    ///     without distortion, map transformations or ortho-rectification.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public object? ImageCoordinateSystem { get; set; }

    /// <summary>
    ///     Indicates if the spatial reference refers to a geographic coordinate system.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsGeographic { get; set; }

    /// <summary>
    ///     Indicates if the wkid of the spatial reference object is one of the following values: 102113, 102100, 3857.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWebMercator { get; set; }

    /// <summary>
    ///     Indicates if the wkid of the spatial reference object is 4326.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWgs84 { get; set; }

    /// <summary>
    ///     Indicates if the spatial reference of the map supports wrapping around the International Date Line.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWrappable { get; set; }

    /// <summary>
    ///     The well-known ID of a spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public int? Wkid { get; set; }

    /// <summary>
    ///     The well-known text that defines a spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Wkt { get; set; }

    internal SpatialReferenceSerializationRecord ToSerializationRecord()
    {
        return new SpatialReferenceSerializationRecord(Wkid);
    }

    /// <inheritdoc />
    public bool Equals(SpatialReference? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Nullable.Equals(Wkid, other.Wkid);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((SpatialReference)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Wkid.GetHashCode();
    }
}

internal class SpatialReferenceConverter : JsonConverter<SpatialReference>
{
    public override SpatialReference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var spatialReference = new SpatialReference();

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.PropertyName:
                    string? propertyName = reader.GetString();
                    reader.Read();
#pragma warning disable BL0005
                    switch (propertyName)
                    {
                        case "wkid":
                            spatialReference.Wkid = reader.GetInt32();

                            break;
                        case "wkt":
                            spatialReference.Wkt = reader.GetString();

                            break;
                        case "isGeographic":
                            spatialReference.IsGeographic = reader.GetBoolean();

                            break;
                        case "isWebMercator":
                            spatialReference.IsWebMercator = reader.GetBoolean();

                            break;
                        case "isWgs84":
                            spatialReference.IsWgs84 = reader.GetBoolean();

                            break;
                        case "isWrappable":
                            spatialReference.IsWrappable = reader.GetBoolean();

                            break;
                        case "imageCoordinateSystem":
                            spatialReference.ImageCoordinateSystem =
                                JsonSerializer.Deserialize<object>(ref reader, options);

                            break;
                    }

                    break;
                case JsonTokenType.EndObject:
                    return spatialReference;
            }
#pragma warning restore BL0005
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, SpatialReference value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        if (value.Wkid.HasValue)
        {
            writer.WriteNumber("wkid", value.Wkid.Value);
        }
        else if (!string.IsNullOrWhiteSpace(value.Wkt))
        {
            writer.WriteString("wkt", value.Wkt);
        }
        else
        {
            throw new ArgumentException("SpatialReference must have either a Wkid or Wkt");
        }

        writer.WriteEndObject();
    }
}

internal record SpatialReferenceSerializationRecord([property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]int? Wkid)
    : MapComponentSerializationRecord;