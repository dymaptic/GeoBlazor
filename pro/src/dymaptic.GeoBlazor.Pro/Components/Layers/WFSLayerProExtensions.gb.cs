namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the WFSLayer class.
/// </summary>
public static partial class WFSLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayercreatepopuptemplate-method">GeoBlazor Docs</a>
    ///     Creates a popup template for the layer, populated with all the fields of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#createPopupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    [ArcGISMethod]
    public static async Task<PopupTemplate?> CreatePopupTemplate(this WFSLayer wFSLayer,
        CreatePopupTemplateOptions options)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wFSLayer.JsComponentReference!.InvokeAsync<PopupTemplate?>(
            "createPopupTemplate", 
            wFSLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayercreatequery-method">GeoBlazor Docs</a>
    ///     Creates query parameter object that can be used to fetch features that satisfy the layer's configurations.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#createQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateQuery(this WFSLayer wFSLayer)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wFSLayer.JsComponentReference!.InvokeAsync<Query?>(
            "createQuery", 
            wFSLayer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayergetfield-method">GeoBlazor Docs</a>
    ///     Returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Field.html">Field</a> instance for a field name (case-insensitive).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#getField">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="fieldName">
    ///     Name of the field.
    /// </param>
    [ArcGISMethod]
    public static async Task<Field?> GetField(this WFSLayer wFSLayer,
        string fieldName)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wFSLayer.JsComponentReference!.InvokeAsync<Field?>(
            "getField", 
            wFSLayer.CancellationTokenSource.Token,
            fieldName);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayergetfielddomain-method">GeoBlazor Docs</a>
    ///     Returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html">Domain</a> associated with the given field name.
    ///     param options An object specifying additional options. See the object specification table below for the required properties of this object.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#getFieldDomain">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="fieldName">
    ///     Name of the field.
    /// </param>
    /// <param name="options">
    ///     An object specifying additional options. See the
    ///     object specification table below for the required properties of this object.
    /// </param>
    [ArcGISMethod]
    public static async Task<Domain?> GetFieldDomain(this WFSLayer wFSLayer,
        string fieldName,
        WFSLayerGetFieldDomainOptions options)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wFSLayer.JsComponentReference!.InvokeAsync<Domain?>(
            "getFieldDomain", 
            wFSLayer.CancellationTokenSource.Token,
            fieldName,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayerqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against a WFSLayer, which groups features into bins based on ranges in numeric or date fields, and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this WFSLayer wFSLayer,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await wFSLayer.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            wFSLayer.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await wFSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayerqueryextent-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and
    ///     returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#queryExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ExtentQueryResult?> QueryExtent(this WFSLayer wFSLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await wFSLayer.JsComponentReference!.InvokeAsync<ExtentQueryResult?>(
            "queryExtent", 
            wFSLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayerqueryfeaturecount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and
    ///     returns the number of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#queryFeatureCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> QueryFeatureCount(this WFSLayer wFSLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await wFSLayer.JsComponentReference!.InvokeAsync<int?>(
            "queryFeatureCount", 
            wFSLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayerqueryfeatures-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a> once the promise resolves.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#queryFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryFeatures(this WFSLayer wFSLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await wFSLayer.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryFeatures", 
            wFSLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayerqueryobjectids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and returns an
    ///     array of Object IDs for features that satisfy the input query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#queryObjectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wFSLayer">
    ///     The <see cref="WFSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the Object IDs of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ObjectId[]?> QueryObjectIds(this WFSLayer wFSLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (wFSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wFSLayer.JsComponentReference ??= await wFSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wFSLayer.CancellationTokenSource.Token, wFSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wFSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wFSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[]? result = await wFSLayer.JsComponentReference!.InvokeAsync<ObjectId[]?>(
            "queryObjectIds", 
            wFSLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await wFSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    

}