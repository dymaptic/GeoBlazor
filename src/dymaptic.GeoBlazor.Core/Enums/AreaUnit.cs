namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Units for area measurement. Use one of the possible values listed below or any of the numeric codes for area units.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.htm">ArcGIS Maps SDK for JavaScript</a>
///     Used by Widgets.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AreaUnit>))]
[CodeGenerationIgnore]
public enum AreaUnit
{
#pragma warning disable CS1591
    Metric,
    Imperial,
    Acres,
    Ares,
    Hectares,
    SquareFeet,
    SquareMeters,
    SquareYards,
    SquareKilometers,
    SquareMiles,
    SquareInches,
    SquareUSFeet
#pragma warning restore CS1591
}