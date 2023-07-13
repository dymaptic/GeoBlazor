using dymaptic.GeoBlazor.Core.Components;
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
    SquareKilometers,
    SquareMiles
#pragma warning restore CS1591
}

/// <summary>
/// Units for area measurement. Use one of the possible values listed below or any of the numeric codes for area units.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.htm">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AreaUnit>))]
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
    SquareUSFeet,
#pragma warning restore CS1591
}

/// <summary>
/// Units for linear measurement. Use one of the possible values listed below or any of the numeric codes for linear units.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.htm">
///         ArcGIS
///         JS API
///     </a>`
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LengthUnit>))]
public enum LengthUnit
{
#pragma warning disable CS1591
    Millimeters,
    Centimeters,
    Decimeters,
    Meters,
    Kilometers,
    Inches,
    Feet,
    Yards,
    Miles,
    NauticalMiles,
    USFeet
#pragma warning restore CS1591
}