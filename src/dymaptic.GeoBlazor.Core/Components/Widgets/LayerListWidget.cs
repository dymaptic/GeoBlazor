using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using dymaptic.GeoBlazor.Core.Components.Widgets.LayerList;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     Displays a widget with a list of all layers in a view.
/// </summary>
public class LayerListWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "layerList";

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IconClass { get; set; }
    
    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    [JsonIgnore]
    public Func<ListItem, Task<ListItem>>? OnListItemCreatedHandler { get; set; } 
    
    public DotNetObjectReference<LayerListWidget> LayerListWidgetObjectReference => DotNetObjectReference.Create(this);

    public bool HasCustomHandler => OnListItemCreatedHandler is not null; 
    
    [JSInvokable]
    public Task<ListItem>? OnListItemCreated(ListItem item)
    {
        return OnListItemCreatedHandler?.Invoke(item);
    }
}
