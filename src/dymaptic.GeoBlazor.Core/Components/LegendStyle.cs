namespace dymaptic.GeoBlazor.Core.Components;

public partial class LegendStyle : MapComponent
{
    /// <summary>
    /// The Legend style type.
    /// </summary>
    [Parameter]
    public LegendStyleType? Type { get; set; }

    /// <summary>
    /// The legend style layout when there are multiple legends
    /// </summary>
    [Parameter]
    public LegendStyleLayout? Layout { get; set; }
}