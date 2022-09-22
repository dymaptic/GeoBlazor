using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public class BasemapToggleWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "basemapToggle";
    [Parameter]
    public string? NextBasemap { get; set; }
}