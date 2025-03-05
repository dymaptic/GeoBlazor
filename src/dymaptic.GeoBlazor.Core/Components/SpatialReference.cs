namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(SpatialReferenceConverter))]
public partial class SpatialReference : MapComponent
{
    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name = "wkid">
    ///     The well-known ID of a spatial reference.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#wkid">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name = "imageCoordinateSystem">
    ///     An [image coordinate system](https://developers.arcgis.com/rest/services-reference/raster-ics.htm) defines the spatial reference used to display the image in its original coordinates without distortion, map transformations or ortho-rectification.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#imageCoordinateSystem">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name = "wkt">
    ///     The well-known text that defines a spatial reference.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#wkt">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name = "wkt2">
    ///     The well-known text of the coordinate system as defined by OGC standard for well-known text strings.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#wkt2">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public SpatialReference(int? wkid = null, object? imageCoordinateSystem = null, string? wkt = null, string? wkt2 = null)
    {
#pragma warning disable BL0005
        Wkid = wkid;
        ImageCoordinateSystem = imageCoordinateSystem;
        Wkt = wkt;
        Wkt2 = wkt2;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     A convenience static instance for WGS84 Spatial Reference.
    /// </summary>
    [JsonIgnore]
    [CodeGenerationIgnore]
    public static SpatialReference Wgs84 => new(4326);

    /// <summary>
    ///     A convenience static instance for WebMercator Spatial Reference.
    /// </summary>
    [JsonIgnore]
    [CodeGenerationIgnore]
    public static SpatialReference WebMercator => new(3857);

    /// <summary>
    ///     Indicates if the spatial reference refers to a geographic coordinate system.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public bool? IsGeographic { get; set; }

    /// <summary>
    ///     Indicates if the wkid of the spatial reference object is one of the following values: 102113, 102100, 3857.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    [CodeGenerationIgnore]
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
    [CodeGenerationIgnore]
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
    ///    The well-known text of the coordinate system as defined by OGC standard for well-known text strings.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Wkt2 { get; set; }

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
                        case "wkt2":
                            spatialReference.Wkt2 = reader.GetString();
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
                            spatialReference.ImageCoordinateSystem = reader.GetString();
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

    public override void Write(Utf8JsonWriter writer, SpatialReference? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartObject();
        if (value.Wkid.HasValue)
        {
            writer.WriteNumber("wkid", value.Wkid.Value);
        }
        else if (!string.IsNullOrWhiteSpace(value.Wkt))
        {
            writer.WriteString("wkt", value.Wkt);
        }
        else if (!string.IsNullOrWhiteSpace(value.Wkt2))
        {
            writer.WriteString("wkt2", value.Wkt2);
        }
        else
        {
            throw new ArgumentException("SpatialReference must have either a Wkid, Wkt, or Wkt2");
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

    public SpatialReferenceSerializationRecord(int? Wkid, string? Wkt = null)
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