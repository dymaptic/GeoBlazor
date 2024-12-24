namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible types of geometries for features in a layer or table
/// </summary>
[JsonConverter(typeof(FeatureGeometryTypeConverter))]
public enum FeatureGeometryType
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

internal class FeatureGeometryTypeConverter : EnumToKebabCaseStringConverter<FeatureGeometryType>
{
    public override FeatureGeometryType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.Replace("-", string.Empty)
            .Replace("esri", string.Empty)
            .Replace("Geometry", string.Empty)
            .Replace("Type", string.Empty);

        return value is not null 
            ? (FeatureGeometryType)Enum.Parse(typeof(FeatureGeometryType), value, true) 
            : default(FeatureGeometryType);
    }
}