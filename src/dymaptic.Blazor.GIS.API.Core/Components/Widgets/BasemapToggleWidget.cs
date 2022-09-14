using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Widgets;

public class BasemapToggleWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "basemapToggle";
    
    [Parameter, EditorRequired]
    public string? NextBasemap { get; set; }
}