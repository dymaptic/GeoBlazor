using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
/// Units for area measurement. Use one of the possible values listed below or any of the numeric codes for area units.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html#AreaUnits">ArcGIS Maps SDK for JavaScript</a>
/// Used by Widgets.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<GeometryEngineAreaUnit>))]
public enum GeometryEngineAreaUnit
{
#pragma warning disable CS1591
    Acres,
    Ares,
    Hectares,
    SquareFeet,
    SquareMeters,
    SquareYards,
    SquareKilometers,
    SquareMiles
}
#pragma warning restore CS1591