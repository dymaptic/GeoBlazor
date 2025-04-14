namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The legend style layout when there are multiple legends <a target="_blank" href=" https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#style">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LegendStyleLayout>))]
public enum LegendStyleLayout
{
#pragma warning disable CS1591
    Auto,
    SideBySide,
    Stack
#pragma warning restore CS1591
}