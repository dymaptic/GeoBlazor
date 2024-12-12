using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Enums;

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

internal class GeometryTypeConverter : EnumToKebabCaseStringConverter<GeometryType>
{
    public override GeometryType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.Replace("-", string.Empty)
            .Replace("esri", string.Empty)
            .Replace("Geometry", string.Empty)
            .Replace("Type", string.Empty);

        return value is not null ? (GeometryType)Enum.Parse(typeof(GeometryType), value, true) : default(GeometryType);
    }
}