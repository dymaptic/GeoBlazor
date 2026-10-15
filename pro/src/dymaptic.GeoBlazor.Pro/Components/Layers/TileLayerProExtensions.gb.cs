namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the TileLayer class.
/// </summary>
public static partial class TileLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html#tilelayercreateservicesublayers-method">GeoBlazor Docs</a>
    ///     Returns a deep clone of a map service's
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html">sublayers</a> as defined by the service.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html#createServiceSublayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="tileLayer">
    ///     The <see cref="TileLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Sublayer[]?> CreateServiceSublayers(this TileLayer tileLayer)
    {
        if (tileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            tileLayer.JsComponentReference ??= await tileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", tileLayer.CancellationTokenSource.Token, tileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (tileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await tileLayer.JsComponentReference!.InvokeAsync<Sublayer[]?>(
            "createServiceSublayers", 
            tileLayer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html#tilelayerfetchtile-method">GeoBlazor Docs</a>
    ///     This method fetches a tile for the given level, row and column present in the view.
    ///     param row The row(y) position of the tile fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    ///     param options Optional settings for the tile request. The options have the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html#fetchTile">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="tileLayer">
    ///     The <see cref="TileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     Level of detail of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="row">
    ///     The row(y) position of the tile fetch. This value is provided by <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="col">
    ///     The column(x) position of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ElementReference?> FetchTile(this TileLayer tileLayer,
        double level,
        double row,
        double col,
        CancellationToken cancellationToken = default)
    {
        if (tileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            tileLayer.JsComponentReference ??= await tileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", tileLayer.CancellationTokenSource.Token, tileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (tileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await tileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ElementReference? result = await tileLayer.JsComponentReference!.InvokeAsync<ElementReference?>(
            "fetchTile", 
            tileLayer.CancellationTokenSource.Token,
            level,
            row,
            col,
            abortSignal);
                
        await tileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html#tilelayerfindsublayerbyid-method">GeoBlazor Docs</a>
    ///     Returns the sublayer with the given layerId.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html#findSublayerById">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="tileLayer">
    ///     The <see cref="TileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="id">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#id">id</a> of the sublayer.
    /// </param>
    [ArcGISMethod]
    public static async Task<Sublayer?> FindSublayerById(this TileLayer tileLayer,
        long id)
    {
        if (tileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            tileLayer.JsComponentReference ??= await tileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", tileLayer.CancellationTokenSource.Token, tileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (tileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await tileLayer.JsComponentReference!.InvokeAsync<Sublayer?>(
            "findSublayerById", 
            tileLayer.CancellationTokenSource.Token,
            id);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html#tilelayergettileurl-method">GeoBlazor Docs</a>
    ///     This method returns a URL to a tile for a given level, row and column.
    ///     param row The requested tile's row.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html#getTileUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="tileLayer">
    ///     The <see cref="TileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     The requested tile's level.
    /// </param>
    /// <param name="row">
    ///     The requested tile's row.
    /// </param>
    /// <param name="col">
    ///     The requested tile's column.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetTileUrl(this TileLayer tileLayer,
        double level,
        double row,
        double col)
    {
        if (tileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            tileLayer.JsComponentReference ??= await tileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", tileLayer.CancellationTokenSource.Token, tileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (tileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await tileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getTileUrl", 
            tileLayer.CancellationTokenSource.Token,
            level,
            row,
            col);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html#tilelayerloadall-method">GeoBlazor Docs</a>
    ///     Loads all of the sublayers.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html#loadAll">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="tileLayer">
    ///     The <see cref="TileLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<TileLayer?> LoadAll(this TileLayer tileLayer)
    {
        if (tileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            tileLayer.JsComponentReference ??= await tileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", tileLayer.CancellationTokenSource.Token, tileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (tileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await tileLayer.JsComponentReference!.InvokeAsync<TileLayer?>(
            "loadAll", 
            tileLayer.CancellationTokenSource.Token);
    }
    

}