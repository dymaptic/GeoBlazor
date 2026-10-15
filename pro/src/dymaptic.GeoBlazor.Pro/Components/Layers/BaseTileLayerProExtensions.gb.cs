namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the BaseTileLayer class.
/// </summary>
public static partial class BaseTileLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.BaseTileLayer.html#basetilelayeraddresolvingpromise-method">GeoBlazor Docs</a>
    ///     Adds a Promise to the layer's loadable chain.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BaseTileLayer.html#addResolvingPromise">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="baseTileLayer">
    ///     The <see cref="BaseTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="promiseToLoad">
    ///     A promise that must resolve for the layer to resolve and move from the `loading` <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BaseTileLayer.html#loadStatus">status</a> to being <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BaseTileLayer.html#loaded">loaded</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task AddResolvingPromise(this BaseTileLayer baseTileLayer,
        string promiseToLoad)
    {
        if (baseTileLayer.CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            baseTileLayer.JsComponentReference ??= await baseTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", baseTileLayer.CancellationTokenSource.Token, baseTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (baseTileLayer.JsComponentReference is null)
        {
            return;
        }
        
        await baseTileLayer.JsComponentReference!.InvokeVoidAsync(
            "addResolvingPromise", 
            baseTileLayer.CancellationTokenSource.Token,
            promiseToLoad);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.BaseTileLayer.html#basetilelayerfetchtile-method">GeoBlazor Docs</a>
    ///     This method fetches a tile for the given level, row and column present in the view.
    ///     param row The row (y) position of the tile fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    ///     param options Optional settings for the tile request. The options have the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BaseTileLayer.html#fetchTile">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="baseTileLayer">
    ///     The <see cref="BaseTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     Level of detail of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="row">
    ///     The row (y) position of the tile fetch. This value is provided by <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="col">
    ///     The column (x) position of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ElementReference?> FetchTile(this BaseTileLayer baseTileLayer,
        double level,
        double row,
        double col,
        CancellationToken cancellationToken = default)
    {
        if (baseTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            baseTileLayer.JsComponentReference ??= await baseTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", baseTileLayer.CancellationTokenSource.Token, baseTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (baseTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await baseTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ElementReference? result = await baseTileLayer.JsComponentReference!.InvokeAsync<ElementReference?>(
            "fetchTile", 
            baseTileLayer.CancellationTokenSource.Token,
            level,
            row,
            col,
            abortSignal);
                
        await baseTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.BaseTileLayer.html#basetilelayergettileurl-method">GeoBlazor Docs</a>
    ///     This method returns a URL to an image for a given level, row and column.
    ///     param row Tile row. This value is provided by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BaseTileLayer.html#getTileUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="baseTileLayer">
    ///     The <see cref="BaseTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     Level of detail. This value is provided by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="row">
    ///     Tile row. This value is provided by the
    ///     <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="col">
    ///     Tile column. This value is provided by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetTileUrl(this BaseTileLayer baseTileLayer,
        double level,
        double row,
        double col)
    {
        if (baseTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            baseTileLayer.JsComponentReference ??= await baseTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", baseTileLayer.CancellationTokenSource.Token, baseTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (baseTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await baseTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getTileUrl", 
            baseTileLayer.CancellationTokenSource.Token,
            level,
            row,
            col);
    }
    

}