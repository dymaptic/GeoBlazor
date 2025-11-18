namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-ui-DefaultUI.html#add">ArcGIS Maps SDK for JavaScript</a>
///     A collection of possible positions for setting a <see cref="Widget" /> or <see cref="CustomOverlay" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<OverlayPosition>))]
public enum OverlayPosition
{
#pragma warning disable CS1591
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    Manual,
    TopLeading,
    TopTrailing,
    BottomLeading,
    BottomTrailing
#pragma warning restore CS1591
}