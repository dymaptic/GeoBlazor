// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <summary>
///          <summary>
///           Temporal units. Used by TimeInterval on Feature Layers.
///            <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeInterval.html">ArcGIS Maps SDK for JavaScript</a>
///           Used by Feature Layer.
///           </summary>
///      </summary>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TemporalTime>))]
public enum TemporalTime
{
#pragma warning disable CS1591
    Milliseconds,
    Seconds,
    Minutes,
    Hours,
    Days,
    Weeks,
    Months,
    Years,
    Decades,
    Centuries
#pragma warning restore CS1591
}
