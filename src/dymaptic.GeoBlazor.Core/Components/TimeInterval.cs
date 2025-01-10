namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
/// TimeInterval is a class that describes a length of time in one of ten temporal units such as seconds, days, or years.
/// TimeInterval is referenced by many classes, such as TimeInfo, which is referenced by time-aware layers and the TimeSlider widget.
/// <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeInterval.html">ArcGIS Maps SDK for JavaScript</a>
/// Used by Feature Layer.
/// </summary>
public partial class TimeInterval: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public TimeInterval()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="unit">
    ///     Temporal units.
    ///     default milliseconds
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeInterval.html#unit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="value">
    ///     The numerical value of the time extent.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeInterval.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public TimeInterval(
        TemporalTime unit,
        double value)
    {
#pragma warning disable BL0005
        Unit = unit;
        Value = value;
#pragma warning restore BL0005    
    }
    
    /// <summary>
    /// Temporal units.
    /// </summary>
    public TemporalTime Unit { get; set; } = TemporalTime.Milliseconds;

    /// <summary>
    /// The numerical value of the time extent.
    /// </summary>
    public double Value { get; set; }
}

