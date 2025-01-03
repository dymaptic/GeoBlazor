namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     A collection of units for measuring Linear distances.
/// <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html#LinearUnits">ArcGIS Maps SDK for JavaScript</a>
/// Used by the Geometry Engine.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<GeometryEngineLinearUnit>))]
public enum GeometryEngineLinearUnit
{
#pragma warning disable CS1591
    Meters,
    Feet,
    Kilometers,
    Miles,
    NauticalMiles,
    Yards
#pragma warning restore CS1591
}