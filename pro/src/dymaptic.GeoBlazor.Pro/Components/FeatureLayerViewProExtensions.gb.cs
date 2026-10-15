namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Pro Extension methods for the FeatureLayerView class.
/// </summary>
public static partial class FeatureLayerViewProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.FeatureLayerView.html#featurelayerviewcreateaggregatequery-method">GeoBlazor Docs</a>
    ///     Creates query parameter object that can be used to <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerView.html#queryAggregates">fetch aggregate features</a> as they are being
    ///     displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerView.html#createAggregateQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayerView">
    ///     The <see cref="FeatureLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateAggregateQuery(this FeatureLayerView featureLayerView)
    {
        if (featureLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            featureLayerView.JsComponentReference ??= await featureLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayerView.CancellationTokenSource.Token, featureLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await featureLayerView.JsComponentReference!.InvokeAsync<Query?>(
            "createAggregateQuery", 
            featureLayerView.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.FeatureLayerView.html#featurelayerviewqueryaggregates-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against aggregate features (i.e.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerView.html#queryAggregates">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayerView">
    ///     The <see cref="FeatureLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the parameters of the query. Leave this parameter empty to query all aggregates in the view.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryAggregates(this FeatureLayerView featureLayerView,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (featureLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            featureLayerView.JsComponentReference ??= await featureLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayerView.CancellationTokenSource.Token, featureLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await featureLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await featureLayerView.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryAggregates", 
            featureLayerView.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await featureLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.FeatureLayerView.html#featurelayerviewqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against features available for drawing, which groups features into bins based on ranges in numeric or date fields, and returns an
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerView.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayerView">
    ///     The <see cref="FeatureLayerView"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this FeatureLayerView featureLayerView,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (featureLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            featureLayerView.JsComponentReference ??= await featureLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayerView.CancellationTokenSource.Token, featureLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await featureLayerView.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await featureLayerView.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            featureLayerView.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await featureLayerView.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    

}