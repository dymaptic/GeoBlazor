namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the MapImageLayer class.
/// </summary>
public static partial class MapImageLayerProExtensions
{
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayerfetchimage-method">GeoBlazor Docs</a>
    ///     This method fetches the image for the specified extent and size.
    ///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#fetchImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
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
    ///     - options.rotation: The rotation in degrees of the exported image. Available since ArcGIS Server 10.3.
    ///     - options.timeExtent: The time instant or time extent of content to render.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public static async Task<IJSObjectReference?> FetchImage(this MapImageLayer mapImageLayer,
        Extent extent,
        int width,
        int height,
        MapImageLayerFetchImageOptions options,
        CancellationToken cancellationToken = default)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }

        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }

        IJSObjectReference abortSignal = await mapImageLayer.AbortManager!.CreateAbortSignal(cancellationToken);

        IJSObjectReference? result = await mapImageLayer.JsComponentReference!.InvokeAsync<IJSObjectReference?>(
            "fetchImage",
            mapImageLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,
            new
            {
                rotation = options.Rotation,
                pixelRatio = options.PixelRatio,
                timeExtent = options.TimeExtent,
                signal = abortSignal
            });

        await mapImageLayer.AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayerfetchimage-method">GeoBlazor Docs</a>
    ///     This method fetches the image for the specified extent and size.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#fetchImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
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
    ///     - options.rotation: The rotation in degrees of the exported image. Available since ArcGIS Server 10.3.
    ///     - options.timeExtent: The time instant or time extent of content to render.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    public static async Task<string?> FetchImageHtmlAsString(this MapImageLayer mapImageLayer,
        Extent extent,
        int width,
        int height,
        MapImageLayerFetchImageOptions options,
        CancellationToken cancellationToken = default)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }

        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }

        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }

        IJSObjectReference abortSignal = await mapImageLayer.AbortManager!.CreateAbortSignal(cancellationToken);

        string? result = await mapImageLayer.JsComponentReference!.InvokeAsync<string?>("fetchImageAsString",
            mapImageLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,
            new
            {
                rotation = options.Rotation,
                pixelRatio = options.PixelRatio,
                timeExtent = options.TimeExtent,
                signal = abortSignal
            });

        await mapImageLayer.AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
}