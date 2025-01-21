namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     The following properties define generic sources properties for use in the Search widget. Please see the subclasses that extend this class for more information about working with Search widget sources.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonDerivedType(typeof(LocatorSearchSource), "locator")]
[JsonDerivedType(typeof(LayerSearchSource), "layer")]
public abstract class SearchSource : MapComponent
{
    /// <summary>
    ///     The type of source.
    /// </summary>
    public virtual string Type => "";

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
    ///     The name of the source for display.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    ///     Specifies the fields returned with the search results.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OutFields { get; set; }

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
    ///     A template string used to display multiple fields in a defined order when results are displayed.
    /// </summary>
    /// <remarks>
    ///     Example: "{County}, {State}"
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SearchTemplate { get; set; }

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
    ///     The popup template used to display search results. If no popup is needed, set the source's popupTemplate to null.
    /// </summary>
    /// <remarks>
    ///     This property should be set in instances where there is no existing PopupTemplate configured. For example, feature sources will default to any existing popupTemplate configured on the layer.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    /// <summary>
    ///     The symbol used to display the result.
    /// </summary>
    /// <remarks>
    ///     This property only applies when the layer/locator/source is not part of the map.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Symbol? ResultSymbol { get; set; }
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
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                }

                break;
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
            case PopupTemplate _:
                PopupTemplate = null;
                break;
            case Symbol:
                ResultSymbol = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    internal override void ValidateRequiredChildren()
    {
        PopupTemplate?.ValidateRequiredChildren();
        ResultSymbol?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}