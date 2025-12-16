namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(SpatialReferenceConverter))]
[ProtobufSerializable]
public partial class SpatialReference : MapComponent, IEquatable<SpatialReference>, 
    IProtobufSerializable<SpatialReferenceSerializationRecord>
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
    public SpatialReference(int? wkid = null, string? imageCoordinateSystem = null, string? wkt = null, string? wkt2 = null)
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

    /// <inheritdoc />
    public SpatialReferenceSerializationRecord ToProtobuf()
    {
        return new SpatialReferenceSerializationRecord(Wkid, Wkt, Wkt2);
    }

    /// <summary>
    ///     Determines whether the specified <see cref="SpatialReference" /> is equal to the current <see cref="SpatialReference" />.
    /// </summary>
    public bool Equals(SpatialReference? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Wkid == other.Wkid && Wkt == other.Wkt && Wkt2 == other.Wkt2 && Equals(ImageCoordinateSystem, other.ImageCoordinateSystem);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((SpatialReference)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Wkid, Wkt, Wkt2, ImageCoordinateSystem);
    }

    /// <summary>
    ///     Override to provide custom equality
    /// </summary>
    public static bool operator ==(SpatialReference? left, SpatialReference? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///    Override to provide custom inequality
    /// </summary>
    public static bool operator !=(SpatialReference? left, SpatialReference? right)
    {
        return !Equals(left, right);
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