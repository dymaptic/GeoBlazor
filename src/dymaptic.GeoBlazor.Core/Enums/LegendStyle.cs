namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
/// The Legend style type.
/// <a target="_blank" href=" https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#style">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LegendStyleType>))]
public enum LegendStyleType
{
#pragma warning disable CS1591
    Card,
    Classic,
#pragma warning restore CS1591
}