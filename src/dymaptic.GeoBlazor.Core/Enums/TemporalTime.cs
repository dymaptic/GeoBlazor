namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
/// Temporal units. Used by TimeInterval on Feature Layers.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeInterval.html">ArcGIS Maps SDK for JavaScript</a>
/// Used by Feature Layer.
/// </summary>
[JsonConverter(typeof(TimeEnumToKebabCaseStringConverter<TemporalTime>))]
public enum TemporalTime
{
#pragma warning disable CS1591
    Days,
    Hours,
    Milliseconds,
    Minutes,
    Months,
    Seconds,
    Weeks,
    Years,
    Decades,
    Centuries
#pragma warning restore CS1591
}