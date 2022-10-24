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
    public Func<ListItem, Task<ListItem>>? onBaseListItemCreatedHandler { get; set; }
    
    public DotNetObjectReference<BasemapLayerListWidget> BasemapLayerListWidgetObjectReference => DotNetObjectReference.Create(this);
    
    public bool HasCustomHandler => OnBaseListItemCreatedHandler is not null;

    [JSInvokable]
    public Task<ListItem>? OnBaseListItemCreated(ListItem item)
    {
        return onBaseListItemCreatedHandler?.Invoke(item);
    }
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? onReferenceListItemCreatedHandler { get; set; }
    
    public DotNetObjectReference<BasemapLayerListWidget> ReferenceLayerListWidgetObjectReference => DotNetObjectReference.Create(this);
    
    public bool HasCustomHandler => onReferenceListItemCreatedHandler is not null;

    [JSInvokable]
    public Task<ListItem>? OnReferenceListItemCreated(ListItem item)
    {
        return onReferenceListItemCreatedHandler?.Invoke(item);
    }
    
    
}