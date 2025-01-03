namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Search widget provides a way to perform search operations on locator service(s), map/feature service feature
///     layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer,
///     GeoJSONLayer, CSVLayer, OGCFeatureLayer, and/or table(s). If using a locator with a geocoding service, the
///     findAddressCandidates operation is used, whereas queries are used on feature layers.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SearchWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Search;

    /// <summary>
    ///     Sets the current active menu of the Search widget. Default value is None.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SearchMenu? ActiveMenu { get; set; }
    
    /// <summary>
    ///     Sets the selected source's index. Default value is 0.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ActiveSourceIndex { get; set; }
    
    /// <summary>
    ///     String value used as a hint for input text when searching on multiple sources. See the image below to view the location and style of this text in the context of the widget.
    ///     Default Value: "Find address or place"
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AllPlaceholder { get; set; }
    
    /// <summary>
    ///     Indicates whether to automatically select and zoom to the first geocoded result. If false, the findAddressCandidates operation will still geocode the input string, but the top result will not be selected. To work with the geocoded results, you can set up a search-complete event handler and get the results through the event object.
    ///     Default value is True.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoSelect { get; set; }
    
    /// <summary>
    ///     When true, the widget is visually withdrawn and cannot be interacted with. Default value is False.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }
    
    /// <summary>
    ///     Indicates whether or not to include defaultSources in the Search UI.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IncludeDefaultSources { get; set; }
    
    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     Enables location services within the widget. Default value is True.
    /// </summary>
    /// <remarks>
    ///     The use of this property is only supported on secure origins. To use it, switch your application to a secure origin, such as HTTPS. Note that localhost is considered "potentially secure" and can be used for easy testing in browsers that supports Window.isSecureContext (currently Chrome and Firefox).
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LocationEnabled { get; set; }
    
    /// <summary>
    ///     The maximum number of results returned by the widget if not specified by the source. Default value is 6.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxResults { get; set; }
    
    /// <summary>
    ///     The maximum number of suggestions returned by the widget if not specified by the source.
    ///     If working with the default ArcGIS Online Geocoding service, the default remains at 5.
    ///     Default Value:6
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxSuggestions { get; set; }
    
    /// <summary>
    ///     The minimum number of characters needed for the search if not specified by the source.
    ///     Default Value:3
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinSuggestCharacters { get; set; }
    
    /// <summary>
    ///     Indicates whether to display the Popup on feature click. The graphic can be clicked to display a Popup.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }
    
    /// <summary>
    ///     Indicates if the resultGraphic will display at the location of the selected feature.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ResultGraphicEnabled { get; set; }
    
    /// <summary>
    ///     Indicates whether to display the option to search all sources. When true, the "All" option is displayed by default. When false, no option to search all sources at once is available.
    ///     Default Value is True.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SearchAllEnabled { get; set; }
    
    /// <summary>
    ///     The value of the search box input text string.
    /// </summary>
    /// <remarks>
    ///     Only use to set an initial value. Use SetSearchTerm() and GetSearchTerm() to update or read.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SearchTerm { get; set; }
    
    /// <summary>
    ///     Enable suggestions for the widget.
    ///     This is only available if working with a 10.3 or greater geocoding service that has suggest capability loaded or a 10.3 or greater feature layer that supports pagination, i.e. supportsPagination = true.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SuggestionsEnabled { get; set; }
    
    /// <summary>
    ///     A delegate for a handler of search selection result events.
    ///     Function must take in a <see cref="SearchResult" /> parameter, and return a <see cref="Task" />
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public EventCallback<SearchResult> OnSearchSelectResultEvent { get; set; }
    
    /// <summary>
    ///     This function provides the ability to override either the MapView goTo() or SceneView goTo() methods with your own implementation.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Action<GoToOverrideParameters>? GoToOverride { get; set; }

    /// <summary>
    ///     Identifies whether a custom <see cref="GoToOverride" /> was registered.
    /// </summary>
    public bool HasGoToOverride => GoToOverride is not null;
    
    /// <summary>
    ///     The Search widget may be used to search features in a map/feature service feature layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer, GeoJSONLayer, CSVLayer or OGCFeatureLayer, or table, or geocode locations with a locator. The sources property defines the sources from which to search for the view specified by the Search widget instance.
    ///     There are two types of sources: <see cref="LayerSearchSource"/> and <see cref="LocatorSearchSource"/>. Any combination of these sources may be used together in the same instance of the Search widget. 
    /// </summary>
    /// <remarks>
    ///     Feature layers created from client-side graphics are not supported.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SearchSource>? Sources { get; set; }
    
    /// <summary>
    ///     A customized PopupTemplate for the selected feature. Note that any templates defined on allSources take precedence over those defined directly on the template.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }
    
    /// <summary>
    ///     It is possible to search a specified portal instance's locator services Use this property to set this ArcGIS Portal instance to search.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Portal? Portal { get; set; }

    /// <summary>
    ///     Set the value of the search text box programmatically.
    /// </summary>
    public async Task SetSearchTerm(string searchTerm)
    {
#pragma warning disable BL0005
        SearchTerm = searchTerm;
#pragma warning restore BL0005
        await JsComponentReference!.InvokeVoidAsync("setSearchTerm", searchTerm);
    }

    /// <summary>
    ///     Retrieves the current value of the search text box.
    /// </summary>
    public async Task<string> GetSearchTerm()
    {
#pragma warning disable BL0005
        SearchTerm = await JsComponentReference!.InvokeAsync<string>("getSearchTerm");
#pragma warning restore BL0005
        return SearchTerm;
    }

    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The term to search for.
    /// </param>
    public async Task<SearchResponse> Search(string searchTerm)
    {
        return await JsComponentReference!.InvokeAsync<SearchResponse>("search", searchTerm);
    }
    
    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The geometry to search for.
    /// </param>
    public async Task<SearchResponse> Search(Geometry searchTerm)
    {
        return await JsComponentReference!.InvokeAsync<SearchResponse>("search", searchTerm);
    }
    
    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The <see cref="SuggestResult"/> to search for.
    /// </param>
    public async Task<SearchResponse> Search(SuggestResult searchTerm)
    {
        return await JsComponentReference!.InvokeAsync<SearchResponse>("search", searchTerm);
    }
    
    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The array of long/lat coordinate pairs to search for.
    /// </param>
    public async Task<SearchResponse> Search(double[][] searchTerm)
    {
        return await JsComponentReference!.InvokeAsync<SearchResponse>("search", new object[]{searchTerm});
    }
    
    /// <summary>
    ///     Performs a suggest() request on the active Locator. It also uses the current value of the widget or one that is passed in.
    /// </summary>
    /// <remarks>
    ///     Suggestions are available if working with a 10.3 or greater geocoding service that has suggest capability loaded or a 10.3 or greater feature layer that supports pagination, i.e. supportsPagination = true.
    /// </remarks>
    /// <param name="value">
    ///     The string value used to suggest() on an active Locator or feature layer. If nothing is passed in, takes the current value of the widget.
    /// </param>
    public async Task<SuggestResponse> Suggest(string? value = null)
    {
        return await JsComponentReference!.InvokeAsync<SuggestResponse>("suggest", value);
    }

    /// <summary>
    ///     Retrieves the source object currently selected. Can be either a LayerSearchSource or a LocatorSearchSource.
    /// </summary>
    public async Task<SearchSource?> GetActiveSource()
    {
        return await JsComponentReference!.InvokeAsync<SearchSource?>("getActiveSource");
    }
    
    /// <summary>
    ///     Retrieves the current active menu of the Search widget. Default value is None.
    /// </summary>
    public async Task<SearchMenu> GetActiveMenu()
    {
        return await JsComponentReference!.InvokeAsync<SearchMenu>("getActiveMenu");
    }

    /// <summary>
    ///     Retrieves the index of the currently selected source. This value is -1 when all sources are selected.
    /// </summary>
    public async Task<int> GetActiveSourceIndex()
    {
        return await JsComponentReference!.InvokeAsync<int>("getActiveSourceIndex");
    }

    /// <summary>
    ///     Retrieves the combined collection of defaultSources and sources. The defaultSources displays first in the Search UI.
    /// </summary>
    public async Task<IReadOnlyList<SearchSource>> GetAllSources()
    {
        return await JsComponentReference!.InvokeAsync<IReadOnlyList<SearchSource>>("getAllSources");
    }

    /// <summary>
    ///     Retrieves a Collection of LayerSearchSource and/or LocatorSearchSource. This may contain ArcGIS Portal locators and any web map or web scene configurable search sources. Web maps or web scenes may contain map/feature service feature layer(s), and/or table(s) as sources.
    /// </summary>
    public async Task<IReadOnlyList<SearchSource>> GetDefaultSources()
    {
        return await JsComponentReference!.InvokeAsync<IReadOnlyList<SearchSource>>("getDefaultSources");
    }

    /// <summary>
    ///     The graphic used to highlight the resulting feature or location.
    /// </summary>
    /// <remarks>
    ///     A graphic will be placed in the View's graphics for layer views that do not support the highlight method.
    /// </remarks>
    public async Task<Graphic?> GetResultGraphic()
    {
        return await JsComponentReference!.InvokeAsync<Graphic?>("getResultGraphic");
    }

    /// <summary>
    ///     Retrieves an array of objects, each containing a SearchResult from the search.
    /// </summary>
    public async Task<SearchResultResponse[]> GetResults()
    {
        return await JsComponentReference!.InvokeAsync<SearchResultResponse[]>("getResults");
    }

    /// <summary>
    ///    Retrieves the result selected from a search.
    /// </summary>
    public async Task<SearchResult> GetSelectedResult()
    {
        return await JsComponentReference!.InvokeAsync<SearchResult>("getSelectedResult");
    }

    /// <summary>
    ///     Retrieves an array of results from the suggest method.
    ///     This is available if working with a 10.3 or greater geocoding service that has suggest capability loaded or a 10.3 or greater feature layer that supports pagination, i.e. supportsPagination = true.
    /// </summary>
    public async Task<SuggestResult[]> GetSuggestions()
    {
        return await JsComponentReference!.InvokeAsync<SuggestResult[]>("getSuggestions");
    }

    /// <summary>
    ///     A JavaScript invokable method that is triggered whenever a "select-result" event is fired by the search widget.
    /// </summary>
    /// <param name="searchResult">
    ///     The result selected in the search widget.
    /// </param>
    [JSInvokable]
    public async Task OnJavaScriptSearchSelectResult(SearchResult searchResult)
    {
        await OnSearchSelectResultEvent.InvokeAsync(searchResult);
    }
    
    /// <summary>
    ///     JavaScript-invokable method for internal use
    /// </summary>
    [JSInvokable]
    public void OnJavaScriptGoToOverride(GoToOverrideParameters goToOverrideParams)
    {
        GoToOverride?.Invoke(goToOverrideParams);
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SearchSource source:
                Sources ??= new List<SearchSource>();
                Sources.Add(source);
                WidgetChanged = true;
                break;
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                    WidgetChanged = true;
                }

                break;
            case Portal portal:
                if (!portal.Equals(Portal))
                {
                    Portal = portal;
                    WidgetChanged = true;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SearchSource source:
                Sources?.Remove(source);
                break;
            case PopupTemplate _:
                PopupTemplate = null;

                break;
            case Portal _:
                Portal = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    internal override void ValidateRequiredChildren()
    {
        if (Sources is not null)
        {
            foreach (SearchSource source in Sources)
            {
                source.ValidateRequiredChildren();
            }
        }
        PopupTemplate?.ValidateRequiredChildren();
        Portal?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}