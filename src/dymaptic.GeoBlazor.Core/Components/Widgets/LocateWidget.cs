using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public class LocateWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "locate";
    [Parameter]
    public bool UseHeadingEnabled { get; set; }
    [Parameter]
    public int? ZoomTo { get; set; }
}