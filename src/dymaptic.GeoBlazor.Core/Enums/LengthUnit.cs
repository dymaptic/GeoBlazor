using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;
/// <summary>
/// Units for linear measurement. Use one of the possible values listed below or any of the numeric codes for linear units.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.htm">ArcGIS Maps SDK for JavaScript</a>
/// Used by Widgets.
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
    UsFeet
#pragma warning restore CS1591
}