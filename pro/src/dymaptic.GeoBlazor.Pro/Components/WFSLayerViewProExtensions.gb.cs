namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Pro Extension methods for the WFSLayerView class.
/// </summary>
public static partial class WFSLayerViewProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewcreateaggregatequery-method">GeoBlazor Docs</a>
    ///     Creates query parameter object that can be used to <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#queryAggregates">fetch aggregate features</a> as they are being
    ///     displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#createAggregateQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateAggregateQuery(this WFSLayerView wFSLayerView)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await wFSLayerView.JsComponentReference!.InvokeAsync<Query?>(
            "createAggregateQuery", 
            wFSLayerView.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewcreatequery-method">GeoBlazor Docs</a>
    ///     Creates a query parameter object that can be used to fetch features as they are being
    ///     displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#createQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateQuery(this WFSLayerView wFSLayerView)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await wFSLayerView.JsComponentReference!.InvokeAsync<Query?>(
            "createQuery", 
            wFSLayerView.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewqueryaggregates-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against aggregate features (i.e.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#queryAggregates">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the parameters of the query. Leave this parameter empty to query all aggregates in the view.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryAggregates(this WFSLayerView wFSLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await wFSLayerView.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryAggregates", 
            wFSLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against features available for drawing, which groups features into bins based on ranges in numeric or date fields, and returns an
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this WFSLayerView wFSLayerView,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await wFSLayerView.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            wFSLayerView.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await wFSLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewqueryextent-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the layerView and
    ///     returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#queryExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ExtentQueryResult?> QueryExtent(this WFSLayerView wFSLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await wFSLayerView.JsComponentReference!.InvokeAsync<ExtentQueryResult?>(
            "queryExtent", 
            wFSLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewqueryfeaturecount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the layerView
    ///     and returns the number of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#queryFeatureCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> QueryFeatureCount(this WFSLayerView wFSLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await wFSLayerView.JsComponentReference!.InvokeAsync<int?>(
            "queryFeatureCount", 
            wFSLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewqueryfeatures-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the LayerView
    ///     and returns a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a>.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#queryFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When this parameter is not passed to `queryFeatures()` method, then a default query is created using <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#createQuery">createQuery()</a> method and all features that pass the layer view <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#filter">filter</a> are returned along with their attributes that are <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#availableFields">available on the client</a>. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryFeatures(this WFSLayerView wFSLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await wFSLayerView.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryFeatures", 
            wFSLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WFSLayerView.html#wfslayerviewqueryobjectids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in
    ///     the layerView and returns array of the ObjectIDs of features that satisfy the input query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-WFSLayerView.html#queryObjectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayerView">
    ///     The <see cref="WFSLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ObjectId[]?> QueryObjectIds(this WFSLayerView wFSLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayerView.JsComponentReference ??= await wFSLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayerView.CancellationTokenSource.Token, wFSLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[]? result = await wFSLayerView.JsComponentReference!.InvokeAsync<ObjectId[]?>(
            "queryObjectIds", 
            wFSLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    

}