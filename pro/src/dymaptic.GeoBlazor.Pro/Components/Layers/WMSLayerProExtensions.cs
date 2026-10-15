namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the WMSLayer class.
/// </summary>
public static partial class WMSLayerProExtensions
{
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WMSLayer.html#wmslayerfetchimage-method">GeoBlazor Docs</a>
    ///     Fetching the WMS image.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMSLayer.html#fetchImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wMSLayer">
    ///     The <see cref="WMSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="extent">
    ///     The extent of the view.
    /// </param>
    /// <param name="width">
    ///     The width of the view in pixels.
    /// </param>
    /// <param name="height">
    ///     The height of the view in pixels.
    /// </param>
    /// <param name="options">
    ///     - options.pixelRatio: The ratio of the resolution in physical pixels of the image to the resolution it will be displayed at.
    ///     - options.timeExent: The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-time-TimeExtent.html">TimeExtent</a> of the exported image.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public static async Task<IJSObjectReference?> FetchImage(this WMSLayer wMSLayer,
        Extent extent,
        int width,
        int height,
        WMSLayerFetchImageOptions options,
        CancellationToken cancellationToken = default)
    {
        if (wMSLayer.CoreJsModule is null)
        {
            return null;
        }

        try
        {
            wMSLayer.JsComponentReference ??= await wMSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wMSLayer.CancellationTokenSource.Token, wMSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (wMSLayer.JsComponentReference is null)
        {
            return null;
        }

        IJSObjectReference abortSignal = await wMSLayer.AbortManager!.CreateAbortSignal(cancellationToken);

        IJSObjectReference? result = await wMSLayer.JsComponentReference!.InvokeAsync<IJSObjectReference?>("fetchImage",
            wMSLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,

            //esri has a typo in TimeExent
            new
            {
                rotation = options.Rotation,
                pixelRatio = options.PixelRatio,
                timeExent = options.TimeExent,
                signal = abortSignal
            });

        await wMSLayer.AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WMSLayer.html#wmslayerfetchimage-method">GeoBlazor Docs</a>
    ///     Fetching the WMS image content as a string.     
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMSLayer.html#fetchImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wMSLayer">
    ///     The <see cref="WMSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="extent">
    ///     The extent of the view.
    /// </param>
    /// <param name="width">
    ///     The width of the view in pixels.
    /// </param>
    /// <param name="height">
    ///     The height of the view in pixels.
    /// </param>
    /// <param name="options">
    ///     - options.pixelRatio: The ratio of the resolution in physical pixels of the image to the resolution it will be displayed at.
    ///     - options.timeExent: The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-time-TimeExtent.html">TimeExtent</a> of the exported image.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    ///
    public static async Task<string?> FetchImageHtmlAsString(this WMSLayer wMSLayer,
        Extent extent,
        int width,
        int height,
        WMSLayerFetchImageOptions options,
        CancellationToken cancellationToken = default)
    {
        if (wMSLayer.CoreJsModule is null)
        {
            return null;
        }

        try
        {
            wMSLayer.JsComponentReference ??= await wMSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wMSLayer.CancellationTokenSource.Token, wMSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (wMSLayer.JsComponentReference is null)
        {
            return null;
        }

        IJSObjectReference abortSignal = await wMSLayer.AbortManager!.CreateAbortSignal(cancellationToken);

        string? result = await wMSLayer.JsComponentReference!.InvokeAsync<string?>("fetchImageAsString",
            wMSLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,

            //esri has a typo in TimeExent
            new
            {
                rotation = options.Rotation,
                pixelRatio = options.PixelRatio,
                timeExent = options.TimeExent,
                signal = abortSignal
            });

        await wMSLayer.AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
}