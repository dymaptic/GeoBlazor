namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Pro Extension methods for the GeoJSONLayerView class.
/// </summary>
public static partial class GeoJSONLayerViewProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewcreateaggregatequery-method">GeoBlazor Docs</a>
    ///     Creates query parameter object that can be used to <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#queryAggregates">fetch aggregate features</a> as they are being
    ///     displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#createAggregateQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateAggregateQuery(this GeoJSONLayerView geoJSONLayerView)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await geoJSONLayerView.JsComponentReference!.InvokeAsync<Query?>(
            "createAggregateQuery", 
            geoJSONLayerView.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewcreatequery-method">GeoBlazor Docs</a>
    ///     Creates a query parameter object that can be used to fetch features as they are being
    ///     displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#createQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateQuery(this GeoJSONLayerView geoJSONLayerView)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await geoJSONLayerView.JsComponentReference!.InvokeAsync<Query?>(
            "createQuery", 
            geoJSONLayerView.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewqueryaggregates-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against aggregate features (i.e.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#queryAggregates">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the parameters of the query. Leave this parameter empty to query all aggregates in the view.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryAggregates(this GeoJSONLayerView geoJSONLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await geoJSONLayerView.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryAggregates", 
            geoJSONLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against features available for drawing, which groups features into bins based on ranges in numeric or date fields, and returns an
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this GeoJSONLayerView geoJSONLayerView,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await geoJSONLayerView.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            geoJSONLayerView.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await geoJSONLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewqueryextent-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the layerView and
    ///     returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#queryExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ExtentQueryResult?> QueryExtent(this GeoJSONLayerView geoJSONLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await geoJSONLayerView.JsComponentReference!.InvokeAsync<ExtentQueryResult?>(
            "queryExtent", 
            geoJSONLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewqueryfeaturecount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the layerView
    ///     and returns the number of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#queryFeatureCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> QueryFeatureCount(this GeoJSONLayerView geoJSONLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await geoJSONLayerView.JsComponentReference!.InvokeAsync<int?>(
            "queryFeatureCount", 
            geoJSONLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewqueryfeatures-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the LayerView
    ///     and returns a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a>.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#queryFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When this parameter is not passed to `queryFeatures()` method, then a default query is created using <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#createQuery">createQuery()</a> method and all features that pass the layer view <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#filter">filter</a> are returned along with their attributes that are <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#availableFields">available on the client</a>. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryFeatures(this GeoJSONLayerView geoJSONLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await geoJSONLayerView.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryFeatures", 
            geoJSONLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GeoJSONLayerView.html#geojsonlayerviewqueryobjectids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in
    ///     the layerView and returns array of the ObjectIDs of features that satisfy the input query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GeoJSONLayerView.html#queryObjectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayerView">
    ///     The <see cref="GeoJSONLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ObjectId[]?> QueryObjectIds(this GeoJSONLayerView geoJSONLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayerView.JsComponentReference ??= await geoJSONLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayerView.CancellationTokenSource.Token, geoJSONLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[]? result = await geoJSONLayerView.JsComponentReference!.InvokeAsync<ObjectId[]?>(
            "queryObjectIds", 
            geoJSONLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    

}