// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.TimeField.html">GeoBlazor Docs</a>
///     Indicates which field from the layer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TimeInfo.html">timeInfo</a> will be used to
///     calculate observation ages for <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TrackInfo.html#maxDisplayDuration">trackInfo.maxDisplayDuration</a>.
///     default "startTimeField"
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TrackInfo.html#timeField">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TimeField>))]
public enum TimeField
{
#pragma warning disable CS1591
    TimeReceived,
    StartTimeField,
    EndTimeField
#pragma warning restore CS1591
}
