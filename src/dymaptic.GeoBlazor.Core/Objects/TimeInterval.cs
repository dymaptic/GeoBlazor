namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
/// TimeInterval is a class that describes a length of time in one of ten temporal units such as seconds, days, or years.
/// TimeInterval is referenced by many classes, such as TimeInfo, which is referenced by time-aware layers and the TimeSlider widget.
/// <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeInterval.html">ArcGIS Maps SDK for JavaScript</a>
/// Used by Feature Layer.
/// </summary>
public record TimeInterval
{
    /// <summary>
    /// Temporal units.
    /// </summary>
    public TemporalTime Unit { get; set; } = TemporalTime.Milliseconds;

    /// <summary>
    /// The numerical value of the time extent.
    /// </summary>
    public double Value { get; set; } = 0;
}


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
