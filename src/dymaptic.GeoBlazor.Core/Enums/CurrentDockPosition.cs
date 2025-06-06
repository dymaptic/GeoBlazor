// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.CurrentDockPosition.html">GeoBlazor Docs</a>
///     Dock position in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html#currentDockPosition">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<CurrentDockPosition>))]
public enum CurrentDockPosition
{
#pragma warning disable CS1591
    Auto,
    TopCenter,
    TopRight,
    TopLeft,
    BottomLeft,
    BottomCenter,
    BottomRight
#pragma warning restore CS1591
}
