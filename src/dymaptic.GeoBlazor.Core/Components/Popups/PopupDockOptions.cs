namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class PopupDockOptions : MapComponent
{


    /// <summary>
    ///     The position in the view at which to dock the popup.
    /// </summary>
    [Parameter]
    public PopupDockPosition? Position { get; set; }

    /// <summary>
    ///     If true, displays the dock button. If false, hides the dock button from the popup.
    /// </summary>
    [Parameter]
    public bool? ButtonEnabled { get; set; }

    /// <summary>
    ///     Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
    /// </summary>
    [Parameter]
    public BreakPoint? BreakPoint { get; set; }
}
