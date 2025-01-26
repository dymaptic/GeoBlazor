namespace dymaptic.GeoBlazor.Core.Components.Popups;
/// <summary>
///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
///     When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned
///     to it. Rather it is placed in one of the corners of the view or to the top or bottom of it. This property allows
///     the developer to set various options for docking the popup.
/// </summary>
public class PopupDockOptions : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PopupDockOptions()
    {
    }

    /// <summary>
    ///     Constructor for creating a PopupDockOptions object in code.
    /// </summary>
    /// <param name = "position">
    ///     The position in the view at which to dock the popup.
    /// </param>
    /// <param name = "buttonEnabled">
    ///     If true, displays the dock button. If false, hides the dock button from the popup.
    /// </param>
    /// <param name = "breakPoint">
    ///     Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.
    /// </param>
    public PopupDockOptions(PopupDockPosition? position = null, bool? buttonEnabled = null, BreakPoint? breakPoint = null)
    {
#pragma warning disable BL0005
        Position = position;
        ButtonEnabled = buttonEnabled;
        BreakPoint = breakPoint;
#pragma warning restore BL0005
    }

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

