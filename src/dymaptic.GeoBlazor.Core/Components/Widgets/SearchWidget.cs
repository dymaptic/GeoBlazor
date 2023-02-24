using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Search widget provides a way to perform search operations on locator service(s), map/feature service feature layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer, GeoJSONLayer, CSVLayer, OGCFeatureLayer, and/or table(s). If using a locator with a geocoding service, the findAddressCandidates operation is used, whereas queries are used on feature layers.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html">ArcGIS JS API</a>
/// </summary>
public class SearchWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "search";

    /// <summary>
    ///     A delegate for a handler of search selection result events.
    ///     Function must take in a <see cref="SearchResult"/> parameter, and return a <see cref="Task"/>
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SearchResult> OnSearchSelectResultEvent { get; set; }

    /// <summary>
    ///     A .NET object reference for calling this class from JavaScript.
    /// </summary>
    public DotNetObjectReference<SearchWidget> SearchWidgetObjectReference => DotNetObjectReference.Create(this);

    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a "select-result" event is fired by the search widget.
    /// </summary>
    /// <param name="searchResult">
    ///     The result selected in the search widget.
    /// </param>
    [JSInvokable]
    public async Task OnJavaScriptSearchSelectResult(SearchResult searchResult)
    {
        await OnSearchSelectResultEvent.InvokeAsync();
    }
}