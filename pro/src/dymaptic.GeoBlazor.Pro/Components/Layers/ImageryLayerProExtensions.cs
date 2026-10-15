namespace dymaptic.GeoBlazor.Pro.Components.Layers;

public static partial class ImageryLayerProExtensions
{
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerfetchimage-method">GeoBlazor Docs</a>
    ///     Returns an image using the
    ///     <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/export-image.htm">export REST operation</a> that displays
    ///     data from an <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html">ImageryLayer</a>.
    ///     param width The width of the image in pixels.
    ///     param options The parameter options is an object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISImageService.html#fetchImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="extent">
    ///     The extent of the image to export.
    /// </param>
    /// <param name="width">
    ///     The width of the image in pixels.
    /// </param>
    /// <param name="height">
    ///     The height of the image in pixels.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    [Obsolete("Deprecated since GeoBlazor 4.2.0. Use ImageryLayer.FetchPixels instead.")]
    public static async Task<string?> FetchImage(this ImageryLayer imageryLayer,
        Extent extent,
        int width,
        int height,
        CancellationToken cancellationToken = default)
    {
        if (imageryLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            imageryLayer.JsComponentReference ??= await imageryLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryLayer.CancellationTokenSource.Token, imageryLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await imageryLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        string? result = await imageryLayer.JsComponentReference!.InvokeAsync<string?>(
            "fetchImage", 
            imageryLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,
            new { signal = abortSignal });
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
}