using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Units for areal measurements. Use one of the possible values listed below or any of the numeric codes for area
///     units.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html#ArealUnits">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ArealUnit>))]
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