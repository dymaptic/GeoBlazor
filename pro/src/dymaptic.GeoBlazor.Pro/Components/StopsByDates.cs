namespace dymaptic.GeoBlazor.Pro.Components;

public partial class StopsByDates: TimeSliderStops
{

    
    /// <inheritdoc />
    public override TimeSliderStopsType Type => TimeSliderStopsType.StopsByDates;
    
    /// <summary>
    ///     Array of dates.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<DateTime>? Dates { get; set; }
}