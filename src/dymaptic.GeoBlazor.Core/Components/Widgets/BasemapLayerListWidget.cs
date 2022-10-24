using dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public class BasemapLayerListWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "basemapLayerList";
    
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IconClass { get; set; }
    
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? onListItemCreatedHandler { get; set; }
    
    public DotNetObjectReference<BasemapLayerListWidget> BasemapLayerListWidgetObjectReference => DotNetObjectReference.Create(this);
}