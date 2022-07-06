using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace dymaptic.Blazor.GIS.API.Core.Components.Widgets;

public class SearchWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "search";

    [Parameter]
    [JsonIgnore]
    public Func<SelectResult, Task>? OnSearchSelectResultEventHandler { get; set; }

    public DotNetObjectReference<SearchWidget> SearchWidgetObjectReference => DotNetObjectReference.Create(this);

    [JSInvokable]
    public void OnSearchSelectResult(SelectResult selectResult)
    {
        OnSearchSelectResultEventHandler?.Invoke(selectResult);
    }
}