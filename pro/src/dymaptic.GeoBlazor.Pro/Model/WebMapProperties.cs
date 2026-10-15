namespace dymaptic.GeoBlazor.Pro.Model;
/// <summary>
/// A helper class that contains the properties that are read from a WebMap and used by the TimeSlider widget.
/// </summary>
public record WebMapProperties
{
    /// <summary>
    /// The full TimeExtent of the time aware layer(s) in the webmap.
    /// </summary>
    public TimeExtent? FullTimeExtent { get; set; }
    /// <summary>
    ///  When true, the time slider should play its animation in a loop.
    /// </summary>
    public bool? Loop { get; set; }
    /// <summary>
    /// The time (in milliseconds) between animation steps.
    /// </summary>
    public double? PlayRate { get; set; }
    /// <summary>
    /// The time slider mode.
    /// </summary>
    public TimeSliderMode Mode { get; set; }
    /// <summary>
    ///     Defines specific locations on the time slider where thumbs will snap to when manipulated StopsByDates | StopsByCount | StopsByInterval
    /// </summary>
    public TimeSliderStops? Stops { get; set; }
    /// <summary>
    ///  The current time extent the time slider should be set to.
    /// </summary>
    public TimeExtent? TimeExtent { get; set; }
}