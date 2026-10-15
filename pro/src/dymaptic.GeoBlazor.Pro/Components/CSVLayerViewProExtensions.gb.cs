namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Pro Extension methods for the CSVLayerView class.
/// </summary>
public static partial class CSVLayerViewProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewcreateaggregatequery-method">GeoBlazor Docs</a>
    ///     Creates query parameter object that can be used to <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#queryAggregates">fetch aggregate features</a> as they are being
    ///     displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#createAggregateQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateAggregateQuery(this CSVLayerView cSVLayerView)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await cSVLayerView.JsComponentReference!.InvokeAsync<Query?>(
            "createAggregateQuery", 
            cSVLayerView.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewcreatequery-method">GeoBlazor Docs</a>
    ///     Creates a query parameter object that can be used to fetch features as they are being
    ///     displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#createQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateQuery(this CSVLayerView cSVLayerView)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await cSVLayerView.JsComponentReference!.InvokeAsync<Query?>(
            "createQuery", 
            cSVLayerView.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewqueryaggregates-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against aggregate features (i.e.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#queryAggregates">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the parameters of the query. Leave this parameter empty to query all aggregates in the view.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryAggregates(this CSVLayerView cSVLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await cSVLayerView.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryAggregates", 
            cSVLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against features available for drawing, which groups features into bins based on ranges in numeric or date fields, and returns an
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this CSVLayerView cSVLayerView,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await cSVLayerView.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            cSVLayerView.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await cSVLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewqueryextent-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the layerView and
    ///     returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#queryExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ExtentQueryResult?> QueryExtent(this CSVLayerView cSVLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await cSVLayerView.JsComponentReference!.InvokeAsync<ExtentQueryResult?>(
            "queryExtent", 
            cSVLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewqueryfeaturecount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the layerView
    ///     and returns the number of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#queryFeatureCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> QueryFeatureCount(this CSVLayerView cSVLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await cSVLayerView.JsComponentReference!.InvokeAsync<int?>(
            "queryFeatureCount", 
            cSVLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewqueryfeatures-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in the LayerView
    ///     and returns a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a>.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#queryFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When this parameter is not passed to `queryFeatures()` method, then a default query is created using <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#createQuery">createQuery()</a> method and all features that pass the layer view <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#filter">filter</a> are returned along with their attributes that are <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#availableFields">available on the client</a>. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryFeatures(this CSVLayerView cSVLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await cSVLayerView.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryFeatures", 
            cSVLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CSVLayerView.html#csvlayerviewqueryobjectids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against features available for drawing in
    ///     the layerView and returns array of the ObjectIDs of features that satisfy the input query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-CSVLayerView.html#queryObjectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayerView">
    ///     The <see cref="CSVLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ObjectId[]?> QueryObjectIds(this CSVLayerView cSVLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayerView.JsComponentReference ??= await cSVLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayerView.CancellationTokenSource.Token, cSVLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[]? result = await cSVLayerView.JsComponentReference!.InvokeAsync<ObjectId[]?>(
            "queryObjectIds", 
            cSVLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    

}