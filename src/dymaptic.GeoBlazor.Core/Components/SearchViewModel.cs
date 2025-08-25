namespace dymaptic.GeoBlazor.Core.Components;

public partial class SearchViewModel : MapComponent
{
    // Add custom code to this file to override generated code
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
    ///    JS-invokable method that triggers the <see cref = "GoToOverride"/> function.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsGoToOverride(IJSStreamReference jsStreamRef)
    {
        GoToOverrideParameters? goToParameters = await jsStreamRef.ReadJsStreamReference<GoToOverrideParameters>()!;
        if (GoToOverride is not null && goToParameters is not null)
        {
            await GoToOverride.Invoke(goToParameters);
        }
    }

    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref = "GoToOverride"/> function was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasGoToOverride => GoToOverride is not null;
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.SearchViewModel.html#searchviewmodelsearch-method">GeoBlazor Docs</a>
    ///     Depending on the sources specified, `search()` queries the feature layer(s) and/or performs
    ///     address matching using any specified <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-locator.html">Locator(s)</a> and
    ///     returns the applicable results.
    ///     param options An object containing an optional `signal` property that can be used to cancel the request.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchViewModel.html#search">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="searchItem">
    ///     This searchItem can be a string, point geometry, suggest candidate object, or an array containing [latitude,longitude]. If a geometry is supplied, then it will reverse geocode (locator) or findAddressCandidates with geometry instead of text (featurelayer).
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the search operation.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<SearchResponse?> Search(string searchItem, CancellationToken cancellationToken = default)
    {
        if (CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cancellationToken, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        return await JsComponentReference!.InvokeAsync<SearchResponse?>(
            "search", 
            cancellationToken,
            searchItem,
            new { signal = abortSignal });
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.SearchViewModel.html#searchviewmodelsearchnearby-method">GeoBlazor Docs</a>
    ///     Returns search results near your current location.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchViewModel.html#searchNearby">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the search operation.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<SearchResponse?> SearchNearby(CancellationToken cancellationToken = default)
    {
        if (CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cancellationToken, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        return await JsComponentReference!.InvokeAsync<SearchResponse?>(
            "searchNearby", 
            cancellationToken,
            new { signal = abortSignal });
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.SearchViewModel.html#searchviewmodelsuggest-method">GeoBlazor Docs</a>
    ///     Performs a suggest() request on the active Locator.
    ///     param suggestionDelay The millisecond delay after keyup and before making a `suggest()` network request.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchViewModel.html#suggest">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="value">
    ///     The string value used to suggest() on an active Locator or feature layer. If nothing is passed in, takes the current value.
    /// </param>
    /// <param name="suggestionDelay">
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the search operation.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<SuggestResponse?> Suggest(string value,
        double suggestionDelay,
        CancellationToken cancellationToken = default)
    {
        if (CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cancellationToken, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        return await JsComponentReference!.InvokeAsync<SuggestResponse?>(
            "suggest", 
            cancellationToken,
            value,
            suggestionDelay,
            new { signal = abortSignal });
    }
}