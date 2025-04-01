namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Measurement systems or an area units.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.html#SystemOrAreaUnit">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SystemOrAreaUnit>))]
[CodeGenerationIgnore]
public enum SystemOrAreaUnit
{
#pragma warning disable CS1591
    Imperial,
    Metric,
    SquareMillimeters,
    SquareCentimeters,
    SquareDecimeters,
    SquareMeters,
    SquareKilometers,
    SquareInches,
    SquareFeet,
    SquareYards,
    SquareMiles,
    SquareUsFeet,
    Acres,
    Ares,
    Hectares
#pragma warning restore CS1591
}