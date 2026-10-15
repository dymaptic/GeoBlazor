namespace dymaptic.GeoBlazor.Pro.Components;

public partial class StopsByInterval: TimeSliderStops
{

    
    /// <inheritdoc />
    public override TimeSliderStopsType Type => TimeSliderStopsType.StopsByInterval;
    
    /// <summary>
    ///     Specifies a granularity of temporal data and allows you to visualize the data at specified intervals.
    ///     It can be set at regular interval such as every hour or every day.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeInterval? Interval { get; set; }
    
    /// <summary>
    ///     The time period to divide. If unspecified, the time slider's fullTimeExtent will be used.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }
}