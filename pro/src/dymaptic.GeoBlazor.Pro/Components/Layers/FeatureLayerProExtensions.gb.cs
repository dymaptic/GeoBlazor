namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the FeatureLayer class.
/// </summary>
public static partial class FeatureLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#featurelayeraddattachment-method">GeoBlazor Docs</a>
    ///     Adds an attachment to a feature.
    ///     param attachment HTML form that contains a file upload field pointing to the file to be added as an attachment.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#addAttachment">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="feature">
    ///     Feature to which the attachment is to be added.
    /// </param>
    /// <param name="attachment">
    ///     HTML form that contains a file upload field pointing to the file to be added as an attachment.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureEditResult?> AddAttachment(this FeatureLayer featureLayer,
        Graphic feature,
        ElementReference attachment)
    {
        if (featureLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            featureLayer.JsComponentReference ??= await featureLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayer.CancellationTokenSource.Token, featureLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await featureLayer.JsComponentReference!.InvokeAsync<FeatureEditResult?>(
            "addAttachment", 
            featureLayer.CancellationTokenSource.Token,
            feature,
            attachment);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#featurelayerdeleteattachments-method">GeoBlazor Docs</a>
    ///     Deletes attachments from a feature.
    ///     param attachmentIds Ids of the attachments to be deleted.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#deleteAttachments">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="feature">
    ///     Feature containing attachments to be deleted.
    /// </param>
    /// <param name="attachmentIds">
    ///     Ids of the attachments to be deleted.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureEditResult[]?> DeleteAttachments(this FeatureLayer featureLayer,
        Graphic feature,
        IReadOnlyCollection<long> attachmentIds)
    {
        if (featureLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            featureLayer.JsComponentReference ??= await featureLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayer.CancellationTokenSource.Token, featureLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await featureLayer.JsComponentReference!.InvokeAsync<FeatureEditResult[]?>(
            "deleteAttachments", 
            featureLayer.CancellationTokenSource.Token,
            feature,
            attachmentIds);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#featurelayerqueryattachments-method">GeoBlazor Docs</a>
    ///     Query information about attachments associated with features.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#queryAttachments">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="attachmentQuery">
    ///     Specifies the attachment parameters for query.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> QueryAttachments(this FeatureLayer featureLayer,
        AttachmentQuery attachmentQuery,
        CancellationToken cancellationToken = default)
    {
        if (featureLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            featureLayer.JsComponentReference ??= await featureLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayer.CancellationTokenSource.Token, featureLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await featureLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        string? result = await featureLayer.JsComponentReference!.InvokeAsync<string?>(
            "queryAttachments", 
            featureLayer.CancellationTokenSource.Token,
            attachmentQuery,
            abortSignal);
                
        await featureLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#featurelayerqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against a feature service, which groups features into bins based on ranges in numeric or date fields, and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this FeatureLayer featureLayer,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (featureLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            featureLayer.JsComponentReference ??= await featureLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayer.CancellationTokenSource.Token, featureLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await featureLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await featureLayer.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            featureLayer.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await featureLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#featurelayersave-method">GeoBlazor Docs</a>
    ///     Saves the layer to its existing portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a>
    ///     authenticated within the user's current session.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#save">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> Save(this FeatureLayer featureLayer,
        FeatureLayerSaveOptions options)
    {
        if (featureLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            featureLayer.JsComponentReference ??= await featureLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayer.CancellationTokenSource.Token, featureLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await featureLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "save", 
            featureLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#featurelayersaveas-method">GeoBlazor Docs</a>
    ///     Saves the layer to a new portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a>
    ///     authenticated within the user's current session.
    ///     param options Various options for saving the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#saveAs">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item to which the layer will be saved.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> SaveAs(this FeatureLayer featureLayer,
        PortalItem portalItem,
        FeatureLayerSaveAsOptions options)
    {
        if (featureLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            featureLayer.JsComponentReference ??= await featureLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayer.CancellationTokenSource.Token, featureLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await featureLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "saveAs", 
            featureLayer.CancellationTokenSource.Token,
            portalItem,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#featurelayerupdateattachment-method">GeoBlazor Docs</a>
    ///     Updates an existing attachment for a feature.
    ///     param attachmentId Id of the attachment to be updated.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#updateAttachment">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="featureLayer">
    ///     The <see cref="FeatureLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="feature">
    ///     The feature containing the attachment to be updated.
    /// </param>
    /// <param name="attachmentId">
    ///     Id of the attachment to be updated.
    /// </param>
    /// <param name="attachment">
    ///     HTML form that contains a file upload field pointing to the file to be added as an attachment.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureEditResult?> UpdateAttachment(this FeatureLayer featureLayer,
        Graphic feature,
        long attachmentId,
        ElementReference attachment)
    {
        if (featureLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            featureLayer.JsComponentReference ??= await featureLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", featureLayer.CancellationTokenSource.Token, featureLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (featureLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await featureLayer.JsComponentReference!.InvokeAsync<FeatureEditResult?>(
            "updateAttachment", 
            featureLayer.CancellationTokenSource.Token,
            feature,
            attachmentId,
            attachment);
    }
    

}