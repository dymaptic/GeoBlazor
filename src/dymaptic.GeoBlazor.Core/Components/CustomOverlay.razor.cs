using Microsoft.AspNetCore.Components;
using System.ComponentModel;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
public partial class CustomOverlay
{
    [Parameter, EditorRequired]
    [RequiredProperty]
    public OverlayPosition Position { get; set; }
    [Parameter]
    [RequiredProperty]
    public RenderFragment? ChildContent { get; set; }

    public void Refresh()
    {
        StateHasChanged();
    }

    private string CalculatedPosition => Position switch {
        OverlayPosition.BottomLeft => "esri-ui-bottom-left esri-ui-corner",
        OverlayPosition.BottomRight => "esri-ui-bottom-right esri-ui-corner",
        OverlayPosition.TopLeft => "esri-ui-top-left esri-ui-corner",
        OverlayPosition.TopRight => "esri-ui-top-right esri-ui-corner",
        OverlayPosition.Manual => "",
        _ => throw new InvalidEnumArgumentException()
    };   
}