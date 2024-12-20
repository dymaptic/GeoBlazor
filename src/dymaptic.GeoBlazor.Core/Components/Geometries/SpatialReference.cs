using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     Defines the spatial reference of a view, layer, or method parameters. This indicates the projected or geographic
///     coordinate system used to locate geographic features in the map. Each projected and geographic coordinate system is
///     defined by either a well-known ID (WKID) or a definition string (WKT). Note that for versions prior to ArcGIS 10,
///     only WKID was supported. For a full list of supported spatial reference IDs and their corresponding definition
///     strings, see Using spatial references.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(SpatialReferenceConverter))]
public class SpatialReference : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
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
    
    /// <summary>
    ///     Returns a deep clone of the Spatial Reference.
    /// </summary>
    public SpatialReference Clone()
    {
        return Wkid.HasValue ? new SpatialReference(Wkid!.Value) : new SpatialReference();
    }

    internal SpatialReferenceSerializationRecord ToSerializationRecord()
    {
        return new SpatialReferenceSerializationRecord(Wkid, Wkt);
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

[ProtoContract(Name = "SpatialReference")]
internal record SpatialReferenceSerializationRecord : MapComponentSerializationRecord
{
    public SpatialReferenceSerializationRecord()
    {
    }
    
    public SpatialReferenceSerializationRecord(int? Wkid,
        string? Wkt = null)
    {
        this.Wkid = Wkid;
        this.Wkt = Wkt;
    }

    public SpatialReference FromSerializationRecord()
    {
        return new SpatialReference(Wkid ?? 4326);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public int? Wkid { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Wkt { get; init; }
}