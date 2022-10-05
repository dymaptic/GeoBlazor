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

public class LayerListWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "layerList";

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IconClass { get; set; }
    [Parameter]
    public string? Label { get; set; }
    public Func<ListItem, Task<ListItem>>? OnListItemSelectedHandler { get; set; } 
    public DotNetObjectReference<LayerListWidget> LayerListWidgetObjectReference => DotNetObjectReference.Create(this);
    [JSInvokable]
    public Task<ListItem>? OnListItemSelected(ListItem item)
    {
        return OnListItemSelectedHandler?.Invoke(item);
    }
    
    

}
