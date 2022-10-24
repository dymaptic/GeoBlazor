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
    public Func<ListItem, Task<ListItem>>? OnBaseListItemCreatedHandler { get; set; }
    
    public DotNetObjectReference<BasemapLayerListWidget> BaseLayerListWidgetObjectReference => DotNetObjectReference.Create(this);

    public bool HasCustomBaseListHandler => OnBaseListItemCreatedHandler is not null;

    [JSInvokable]
    public Task<ListItem>? OnBaseListItemCreated(ListItem item)
    {
        return OnBaseListItemCreatedHandler?.Invoke(item);
    }
    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnReferenceListItemCreatedHandler { get; set; }
    
    public DotNetObjectReference<BasemapLayerListWidget> ReferenceLayerListWidgetObjectReference => DotNetObjectReference.Create(this);

    public bool HasCustomReferenceListHandler => OnReferenceListItemCreatedHandler is not null;

    [JSInvokable]
    public Task<ListItem>? OnReferenceListItemCreated(ListItem item)
    {
        return OnReferenceListItemCreatedHandler?.Invoke(item);
    }
    
    
}