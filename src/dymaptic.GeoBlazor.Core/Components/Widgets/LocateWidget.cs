using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     Provides a simple widget that animates the View to the user's current location. The view rotates according to the direction where the tracked device is heading towards.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Locate.html">ArcGIS JS API</a>
/// </summary>
public class LocateWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "locate";
    
    /// <summary>
    ///     Indicates whether the widget will automatically rotate to user's direction.
    /// </summary>
    [Parameter]
    public bool UseHeadingEnabled { get; set; }
    
    /// <summary>
    ///     Indicates the scale to set on the view when navigating to the position of the geolocated result once a location is returned from the track event.
    /// </summary>
    [Parameter]
    public int? Scale { get; set; }
}