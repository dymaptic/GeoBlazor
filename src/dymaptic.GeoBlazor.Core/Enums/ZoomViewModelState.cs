// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.ZoomViewModelState.html">GeoBlazor Docs</a>
///     The current state of the widget.
///     default "disabled"
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Zoom-ZoomViewModel.html#state">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ZoomViewModelState>))]
public enum ZoomViewModelState
{
#pragma warning disable CS1591
    Disabled,
    Ready
#pragma warning restore CS1591
}
