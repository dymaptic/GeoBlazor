using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

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