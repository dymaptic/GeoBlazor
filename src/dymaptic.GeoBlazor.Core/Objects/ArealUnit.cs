using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Extensions;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Units for areal measurements. Use one of the possible values listed below or any of the numeric codes for area units.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html#ArealUnits">ArcGIS JS API</a>
/// </summary>
[JsonConverter(typeof(ArealUnitsConverter))]
public enum ArealUnit
{
#pragma warning disable CS1591
    Acres,
    Ares,
    Hectares,
    SquareFeet,
    SquareMeters,
    SquareYards,
    SquareKilometers
#pragma warning restore CS1591
}

internal class ArealUnitsConverter : JsonConverter<ArealUnit>
{
    public override ArealUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ArealUnit value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(ArealUnit), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteRawValue($"\"{resultString}\"");
    }
}