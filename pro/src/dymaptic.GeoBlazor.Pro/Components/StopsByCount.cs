namespace dymaptic.GeoBlazor.Pro.Components;

public partial class StopsByCount: TimeSliderStops
{


    /// <inheritdoc />
    public override TimeSliderStopsType Type => TimeSliderStopsType.StopsByCount;

    
    /// <summary>
    ///     The time period to divide. If unspecified, the time slider's fullTimeExtent will be used.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }
}