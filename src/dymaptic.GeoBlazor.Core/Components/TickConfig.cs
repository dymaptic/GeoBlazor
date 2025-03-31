namespace dymaptic.GeoBlazor.Core.Components;

public partial class TickConfig : MapComponent
{
    /// <summary>
    /// The mode or method of positioning ticks along the slider track. 
    /// </summary>
    [Parameter]
    public TickConfigMode Mode { get; set; }

    /// <summary>
    /// Indicates where ticks will be rendered below the track. See the description for mode for more information about how this property is interpreted by each mode.
    /// </summary>
    [Parameter]
    public List<double>? Values { get; set; }

    /// <summary>
    /// Indicates whether to render labels for the ticks.
    /// </summary>
    [Parameter]
    public bool? LabelsVisible { get; set; }

}


