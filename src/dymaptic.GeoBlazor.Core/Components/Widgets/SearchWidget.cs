namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class SearchWidget : Widget
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
    
#region Event Handlers
   
    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsSearchComplete(IJSStreamReference jsStreamRef)
    {
        View!.ExtentChangedInJs = true;
        SearchCompleteEvent? searchCompleteEvent = await jsStreamRef.ReadJsStreamReference<SearchCompleteEvent>();

        if (searchCompleteEvent is null)
        {
            return;
        }
        
        if (searchCompleteEvent.Results is { Count: > 0 })
        {
            foreach (SearchCompleteEventResults results in searchCompleteEvent.Results)
            {
                if (results.Source is LayerSearchSource layerSearchSource)
                {
                    if (Sources?.FirstOrDefault(s => s.Id == layerSearchSource.Id)
                        is LayerSearchSource matchingSource)
                    {
#pragma warning disable BL0005
                        layerSearchSource.Layer = matchingSource.Layer;
#pragma warning restore BL0005
                    }
                }
            }
        }

        await OnSearchComplete.InvokeAsync(searchCompleteEvent);
    }
    
    /// <summary>
    ///     Event Listener for SearchComplete.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SearchCompleteEvent> OnSearchComplete { get; set; }
    
    /// <summary>
    ///     Used in JavaScript to determine if the event listener is set.
    /// </summary>
    public bool HasSearchCompleteListener => true; // always return true, required event handler
   
    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsSelectResult(IJSStreamReference jsStreamRef)
    {
        SearchSelectResultEvent? selectResultEvent = await jsStreamRef.ReadJsStreamReference<SearchSelectResultEvent>();
        
        if (selectResultEvent is null)
        {
            return;
        }
        
        if (selectResultEvent.Source is LayerSearchSource layerSearchSource)
        {
            if (Sources?.FirstOrDefault(s => s.Id == layerSearchSource.Id) 
                is LayerSearchSource matchingSource)
            {
#pragma warning disable BL0005
                layerSearchSource.Layer = matchingSource.Layer;
#pragma warning restore BL0005
            }
        }
        await OnSelectResult.InvokeAsync(selectResultEvent);
#pragma warning disable CS0618 // Type or member is obsolete
        await OnSearchSelectResultEvent.InvokeAsync(selectResultEvent.Result);
#pragma warning restore CS0618 // Type or member is obsolete
    }
    
    /// <summary>
    ///     Event Listener for SelectResult.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SearchSelectResultEvent> OnSelectResult { get; set; }
    
#pragma warning disable CS0618 // Type or member is obsolete
    /// <summary>
    ///     Used in JavaScript to determine if the event listener is set.
    /// </summary>
    public bool HasSelectResultListener => OnSelectResult.HasDelegate || OnSearchSelectResultEvent.HasDelegate;
#pragma warning restore CS0618 // Type or member is obsolete
   
    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsSuggestComplete(IJSStreamReference jsStreamRef)
    {
        SearchSuggestCompleteEvent? suggestCompleteEvent =
            await jsStreamRef.ReadJsStreamReference<SearchSuggestCompleteEvent>();

        if (suggestCompleteEvent is null)
        {
            return;
        }
        
        if (suggestCompleteEvent.Results is { Count: > 0 })
        {
            foreach (SearchSuggestCompleteEventResults results in suggestCompleteEvent.Results)
            {
                if (results.Source is LayerSearchSource layerSearchSource)
                {
                    if (Sources?.FirstOrDefault(s => s.Id == layerSearchSource.Id) 
                        is LayerSearchSource matchingSource)
                    {
#pragma warning disable BL0005
                        layerSearchSource.Layer = matchingSource.Layer;
#pragma warning restore BL0005
                    }
                }
            }
        }
        await OnSuggestComplete.InvokeAsync(suggestCompleteEvent);
    }
    
    /// <summary>
    ///     Event Listener for SuggestComplete.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<SearchSuggestCompleteEvent> OnSuggestComplete { get; set; }
    
    /// <summary>
    ///     Used in JavaScript to determine if the event listener is set.
    /// </summary>
    public bool HasSuggestCompleteListener => OnSuggestComplete.HasDelegate;
    
    /// <summary>
    ///     A delegate for a handler of search selection result events.
    ///     Function must take in a <see cref="SearchResult" /> parameter, and return a <see cref="Task" />
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [Obsolete("Use OnSelectResult instead")]
    public EventCallback<SearchResult> OnSearchSelectResultEvent { get; set; }

    
    /// <summary>
    ///     This function provides the ability to override either the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#goTo">MapView goTo()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#goTo">SceneView goTo()</a> methods.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-support-GoTo.html#goToOverride">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public GoToOverride? GoToOverride { get; set; }
    
    /// <summary>
    ///    JS-invokable method that triggers the <see cref="GoToOverride"/> function.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsGoToOverride(IJSStreamReference jsStreamRef)
    {
        GoToOverrideParameters? goToParameters = await jsStreamRef.ReadJsStreamReference<GoToOverrideParameters>();
        if (GoToOverride is not null && goToParameters is not null)
        {
            await GoToOverride.Invoke(goToParameters);
        }
    }
    
    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="GoToOverride" /> function was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasGoToOverride => GoToOverride is not null;
    
#endregion

    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The term to search for.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public Task<SearchResponse> Search(string searchTerm)
    {
        return SearchImplementation(searchTerm);
    }
    
    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The geometry to search for.
    /// </param>
    [CodeGenerationIgnore]
    public Task<SearchResponse> Search(Geometry searchTerm)
    {
        return SearchImplementation(searchTerm);
    }
    
    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The <see cref="SuggestResult"/> to search for.
    /// </param>
    [CodeGenerationIgnore]
    public Task<SearchResponse> Search(SuggestResult searchTerm)
    {
        return SearchImplementation(searchTerm);
    }
    
    /// <summary>
    ///     Depending on the sources specified, search() queries the feature layer(s) and/or performs address matching using any specified locator(s) and returns any applicable results.
    /// </summary>
    /// <param name="searchTerm">
    ///     The array of long/lat coordinate pairs to search for.
    /// </param>
    [CodeGenerationIgnore]
    public Task<SearchResponse> Search(double[][] searchTerm)
    {
        return SearchImplementation(searchTerm);
    }

    private async Task<SearchResponse> SearchImplementation(object searchTerm)
    {
        if (CoreJsModule is null)
        {
            throw new InvalidOperationException("SearchWidget is not initialized with CoreJsModule.");
        }
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        
        IJSStreamReference jsStreamRef = 
            await JsComponentReference!.InvokeAsync<IJSStreamReference>("search", searchTerm);
        return (await jsStreamRef.ReadJsStreamReference<SearchResponse>())!;
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
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<SuggestResponse> Suggest(string? value = null)
    {
        if (CoreJsModule is null)
        {
            throw new InvalidOperationException("SearchWidget is not initialized with CoreJsModule.");
        }
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        
        IJSStreamReference jsStreamRef =
            await JsComponentReference!.InvokeAsync<IJSStreamReference>("suggest", value);
        return (await jsStreamRef.ReadJsStreamReference<SuggestResponse>())!;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ActiveSource property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<SearchSource?> GetActiveSource()
    {
        if (CoreJsModule is null)
        {
            return ActiveSource;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return ActiveSource;
        }

        IJSStreamReference jsStreamRef = await JsComponentReference.InvokeAsync<IJSStreamReference>(
            "getActiveSource", CancellationTokenSource.Token);

        SearchSource? result = await jsStreamRef.ReadJsStreamReference<SearchSource>();
        
        if (result is not null)
        {
#pragma warning disable BL0005
            ActiveSource = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(ActiveSource)] = ActiveSource;
        }
        
        return ActiveSource;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the AllSources property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<SearchSource>?> GetAllSources()
    {
        if (CoreJsModule is null)
        {
            return AllSources;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return AllSources;
        }

        IJSStreamReference jsStreamRef = await JsComponentReference.InvokeAsync<IJSStreamReference>(
            "getAllSources", CancellationTokenSource.Token);

        IReadOnlyList<SearchSource>? result = await jsStreamRef.ReadJsStreamReference<IReadOnlyList<SearchSource>>();
        
        if (result is not null)
        {
#pragma warning disable BL0005
            AllSources = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(AllSources)] = AllSources;
        }
        
        return AllSources;
    }

    /// <summary>
    ///    Retrieves the result selected from a search.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<SearchResult> GetSelectedResult()
    {
        IJSStreamReference jsStreamRef =
            await JsComponentReference!.InvokeAsync<IJSStreamReference>("getSelectedResult");
        return (await jsStreamRef.ReadJsStreamReference<SearchResult>())!;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Sources property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<SearchSource>?> GetSources()
    {
        if (CoreJsModule is null)
        {
            return Sources;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Sources;
        }

        IJSStreamReference jsStreamRef =
            await JsComponentReference!.InvokeAsync<IJSStreamReference>("getSources", CancellationTokenSource.Token);
        IReadOnlyList<SearchSource>? result = await jsStreamRef.ReadJsStreamReference<IReadOnlyList<SearchSource>>();
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Sources = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Sources)] = Sources;
        }
        
        return Sources;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Suggestions property.
    /// </summary>
    public async Task<IReadOnlyList<SuggestResult>?> GetSuggestions()
    {
        if (CoreJsModule is null)
        {
            return Suggestions;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Suggestions;
        }

        IJSStreamReference jsStreamRef =
            await JsComponentReference!.InvokeAsync<IJSStreamReference>("getSources", CancellationTokenSource.Token);
        IReadOnlyList<SuggestResult>? result = await jsStreamRef.ReadJsStreamReference<IReadOnlyList<SuggestResult>>();
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Suggestions = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Suggestions)] = Suggestions;
        }
        
        return Suggestions;
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SearchSource source:
                Sources ??= new List<SearchSource>();
                Sources = [..Sources, source];
                if (MapRendered)
                {
                    await UpdateWidget();
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
                Sources = Sources?.Except([source]).ToList();
                
                break;

            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}