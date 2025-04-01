namespace dymaptic.GeoBlazor.Core.Components;

public partial class TickConfig : MapComponent
{
    /// <summary>
    /// The mode or method of positioning ticks along the slider track. 
    /// </summary>
    [Parameter]
    public TickConfigMode Mode { get; set; }


    /// <summary>
    /// Indicates whether to render labels for the ticks.
    /// </summary>
    [Parameter]
    public bool? LabelsVisible { get; set; }

}


