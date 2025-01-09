namespace dymaptic.GeoBlazor.Core.Enums;
/// <summary>
///     Enum that defines the imagery type used in the particular Oriented Imagery Layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-OrientedImageryLayer.html#orientedImageryType">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(OrientedImageryTypeConverter))]
public enum OrientedImageryType
{
#pragma warning disable CS1591
    Horizontal,
    Nadir,
    Oblique,
    ThreeHundredSixty,
    Inspection
#pragma warning restore CS1591
}

internal class OrientedImageryTypeConverter : JsonConverter<OrientedImageryType>
{
    public override OrientedImageryType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "horizontal" => OrientedImageryType.Horizontal,
            "nadir" => OrientedImageryType.Nadir,
            "oblique" => OrientedImageryType.Oblique,
            "360" => OrientedImageryType.ThreeHundredSixty,
            "inspection" => OrientedImageryType.Inspection,
            _ => OrientedImageryType.Horizontal
        };
    }

    public override void Write(Utf8JsonWriter writer, OrientedImageryType value, JsonSerializerOptions options)
    {
        string type = value switch
        {
            OrientedImageryType.Horizontal => "horizontal",
            OrientedImageryType.Nadir => "nadir",
            OrientedImageryType.Oblique => "oblique",
            OrientedImageryType.ThreeHundredSixty => "360",
            OrientedImageryType.Inspection => "inspection",
            _ => string.Empty
        };
        writer.WriteStringValue(type);
    }
}