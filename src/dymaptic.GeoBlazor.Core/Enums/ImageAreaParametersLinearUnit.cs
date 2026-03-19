namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.ImageAreaParametersLinearUnit.html">GeoBlazor Docs</a>
///     Linear unit used for a perimeter calculation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAreaParameters.html#linearUnit">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ImageAreaParametersLinearUnit>))]
[CodeGenerationIgnore]
public enum ImageAreaParametersLinearUnit
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
    UsFeet,
    DecimalDegrees,
    Points,
    Unknown
#pragma warning restore CS1591
}