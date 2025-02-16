namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(SearchSourceConverter))]
public abstract partial class SearchSource : MapComponent
{
    /// <summary>
    ///     The type of source.
    /// </summary>
    public abstract SearchSourceType Type { get; }

    /// <summary>
    ///     Indicates whether to automatically navigate to the selected result once selected.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoNavigate { get; set; }

    /// <summary>
    ///     Indicates the maximum number of search results to return. Default value is 6.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxResults { get; set; }

    /// <summary>
    ///     Indicates the minimum number of characters required before querying for a suggestion. Default value is 1.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinSuggestCharacters { get; set; }


    /// <summary>
    ///     Used as a hint for the source input text.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Placeholder { get; set; }

    /// <summary>
    ///     Indicates whether to display a Popup when a selected result is clicked.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }

    /// <summary>
    ///     Specify this to prefix the user's input of the search text.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Prefix { get; set; }

    /// <summary>
    ///     Indicates whether to show a graphic on the map for the selected source using the resultSymbol.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ResultGraphicEnabled { get; set; }

    /// <summary>
    ///     Specify this to add a suffix to the user's input for the search value.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Suffix { get; set; }

    /// <summary>
    ///     Indicates whether to display suggestions as the user enters input text in the widget. Default value is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SuggestionsEnabled { get; set; }

    /// <summary>
    ///     Indicates whether to constrain the search results to the view's extent. Default value is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? WithinViewEnabled { get; set; }

    /// <summary>
    ///     The set zoom scale for the resulting search result. This scale is automatically honored. Default value is null.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ZoomScale { get; set; }

    /// <summary>
    ///     Function used to get search results. See GetResultsHandler for the function definition. When resolved, returns an object containing an array of search results.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<GetResultsParameters, Task<IList<SearchResult>>>? GetResultsHandler { get; set; }

    /// <summary>
    ///     Function used to get search suggestions. See GetSuggestionsParameters for the function definition. When resolved, returns an object containing an array of suggest results.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<GetSuggestionsParameters, Task<IList<SuggestResult>>>? GetSuggestionsHandler { get; set; }

    /// <summary>
    ///     Indicates for the JavaScript engine whether to set up the GetResults handler
    /// </summary>
    public bool HasGetResultsHandler => GetResultsHandler is not null;
    /// <summary>
    ///     Indicates for the JavaScript engine whether to set up the GetSuggestions handler
    /// </summary>
    public bool HasGetSuggestionsHandler => GetSuggestionsHandler is not null;

    /// <summary>
    ///     JavaScript-invokable method for internal use.
    /// </summary>
    [JSInvokable]
    public async Task<IList<SearchResult>> OnJavaScriptGetResults(GetResultsParameters resultsParams)
    {
        return await GetResultsHandler!.Invoke(resultsParams);
    }

    /// <summary>
    ///     JavaScript-invokable method for internal use.
    /// </summary>
    [JSInvokable]
    public async Task<IList<SuggestResult>> OnJavaScriptGetSuggestions(GetSuggestionsParameters suggestionsParams)
    {
        return await GetSuggestionsHandler!.Invoke(suggestionsParams);
    }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {

            case Symbol symbol:
                if (!symbol.Equals(ResultSymbol))
                {
                    ResultSymbol = symbol;
                }

                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {

            case Symbol:
                ResultSymbol = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

}


internal class SearchSourceConverter : JsonConverter<SearchSource>
{
    public override SearchSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            return null;
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDocument.RootElement;
        if (rootElement.TryGetProperty("url", out JsonElement _))
        {
            return JsonSerializer.Deserialize<LocatorSearchSource>(rootElement.GetRawText(), options);
        }

        if (rootElement.TryGetProperty("layer", out JsonElement _) || rootElement.TryGetProperty("layerId", out JsonElement _))
        {
            return JsonSerializer.Deserialize<LayerSearchSource>(rootElement.GetRawText(), options);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, SearchSource value, JsonSerializerOptions options)
    {
        if (value is LocatorSearchSource locatorSource)
        {
            JsonSerializer.Serialize(writer, locatorSource, options);
        }
        else if (value is LayerSearchSource layerSource)
        {
            JsonSerializer.Serialize(writer, layerSource, options);
        }
    }
}