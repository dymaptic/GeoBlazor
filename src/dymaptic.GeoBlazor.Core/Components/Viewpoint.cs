namespace dymaptic.GeoBlazor.Core.Components;

public partial class Viewpoint : MapComponent
{


    /// <summary>
    /// The rotation of due north in relation to the top of the view in degrees.
    /// </summary>
    [Parameter]
    public double? Rotation { get; set; } = 0;

    /// <summary>
    ///  The scale of the viewpoint.
    /// </summary>
    [Parameter]
    public double? Scale { get; set; } = 0;
    
}