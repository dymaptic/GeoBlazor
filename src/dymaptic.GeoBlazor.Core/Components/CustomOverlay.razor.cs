using Microsoft.AspNetCore.Components;
using System.ComponentModel;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A container for placing custom html or Razor Components on top of the Map View.
/// </summary>
public partial class CustomOverlay
{
    /// <summary>
    ///     The position to place the child content over the map.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public OverlayPosition Position { get; set; }

    /// <summary>
    ///     The child content to place over the map.
    /// </summary>
    [Parameter]
    [RequiredProperty]
    public RenderFragment? ChildContent { get; set; }

    private string CalculatedPosition => Position switch
    {
        OverlayPosition.BottomLeft => "esri-ui-bottom-left esri-ui-corner",
        OverlayPosition.BottomRight => "esri-ui-bottom-right esri-ui-corner",
        OverlayPosition.TopLeft => "esri-ui-top-left esri-ui-corner",
        OverlayPosition.TopRight => "esri-ui-top-right esri-ui-corner",
        OverlayPosition.Manual => "",
        _ => throw new InvalidEnumArgumentException()
    };

    /// <summary>
    ///     A convenience method to force the child content to call StateHasChanged
    /// </summary>
    public void Refresh()
    {
        StateHasChanged();
    }
}