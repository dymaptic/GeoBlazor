namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the WCSLayer class.
/// </summary>
public static partial class WCSLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WCSLayer.html#wcslayercreatepopuptemplate-method">GeoBlazor Docs</a>
    ///     Creates a default popup template for the layer, populated with all the fields of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#createPopupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wCSLayer">
    ///     The <see cref="WCSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    [ArcGISMethod]
    public static async Task<PopupTemplate?> CreatePopupTemplate(this WCSLayer wCSLayer,
        CreatePopupTemplateOptions options)
    {
        if (wCSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wCSLayer.JsComponentReference ??= await wCSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wCSLayer.CancellationTokenSource.Token, wCSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wCSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wCSLayer.JsComponentReference!.InvokeAsync<PopupTemplate?>(
            "createPopupTemplate", 
            wCSLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WCSLayer.html#wcslayerfetchpixels-method">GeoBlazor Docs</a>
    ///     Fetches pixels for a given extent.
    ///     param width The width of the image in pixels.
    ///     param options The parameter options is an object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#fetchPixels">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wCSLayer">
    ///     The <see cref="WCSLayer"/> instance to extend with this method.
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
    /// <param name="options">
    ///     The parameter options is an object with the following properties.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<PixelData?> FetchPixels(this WCSLayer wCSLayer,
        Extent extent,
        int width,
        int height,
        ImageryTileMixinFetchPixelsOptions options,
        CancellationToken cancellationToken = default)
    {
        if (wCSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wCSLayer.JsComponentReference ??= await wCSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wCSLayer.CancellationTokenSource.Token, wCSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wCSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wCSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        PixelData? result = await wCSLayer.JsComponentReference!.InvokeAsync<PixelData?>(
            "fetchPixels", 
            wCSLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,
            options,
            abortSignal);
                
        await wCSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WCSLayer.html#wcslayergetsamples-method">GeoBlazor Docs</a>
    ///     Returns sample point locations, pixel values and corresponding resolutions of the source data for a given geometry.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#getSamples">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wCSLayer">
    ///     The <see cref="WCSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="interpolation">
    ///     Defines how to interpolate pixel values.
    ///     default "nearest"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#interpolation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="outFields">
    ///     The list of fields associated with the rasters to be included in the response.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#outFields">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="returnFirstValueOnly">
    ///     When `true`, returns the first valid pixel value that meets specified conditions at each sampling point location.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#returnFirstValueOnly">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sampleCount">
    ///     Specifies the approximate number of locations to sample from the provided geometry when the input geometry is <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">polyline</a>,
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">polygon</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">extent</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#sampleCount">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sampleDistance">
    ///     Specifies the distance interval to sample points from the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#geometry">geometry</a> when input geometry is <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">polyline</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#sampleDistance">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sliceId">
    ///     Specifies the slice id of a multidimensional raster.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#sliceId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     Input geometry that defines the locations to be sampled.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="locations">
    ///     When sampling multiple locations, you can use an array of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">points</a> instead of providing
    ///     a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Multipoint.html">multipoint</a> for the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#geometry">geometry</a> property.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#locations">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="mosaicRule">
    ///     Specifies the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MosaicRule.html">mosaic rule</a> defining the image sort order and selection.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#mosaicRule">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pixelSize">
    ///     Specifies the pixel size (or the resolution) that will be used for the sampling.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#pixelSize">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeExtent">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-time-TimeExtent.html">time extent</a> for which to perform sampling.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageSampleParameters.html#timeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageSampleResult?> GetSamples(this WCSLayer wCSLayer,
        Interpolation? interpolation,
        IReadOnlyCollection<string>? outFields,
        bool? returnFirstValueOnly,
        int? sampleCount,
        double? sampleDistance,
        long? sliceId,
        Geometry? geometry,
        IReadOnlyCollection<Point>? locations,
        MosaicRule? mosaicRule,
        Point? pixelSize,
        TimeExtent? timeExtent,
        RequestOptions requestOptions,
        CancellationToken cancellationToken = default)
    {
        if (wCSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wCSLayer.JsComponentReference ??= await wCSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wCSLayer.CancellationTokenSource.Token, wCSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wCSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wCSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ImageSampleResult? result = await wCSLayer.JsComponentReference!.InvokeAsync<ImageSampleResult?>(
            "getSamples", 
            wCSLayer.CancellationTokenSource.Token,
            new { interpolation, outFields, returnFirstValueOnly, sampleCount, sampleDistance, sliceId, geometry, locations, mosaicRule, pixelSize, timeExtent },
            requestOptions,
            abortSignal);
                
        await wCSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WCSLayer.html#wcslayeridentify-method">GeoBlazor Docs</a>
    ///     Identify pixel values at a given location.
    ///     param options Optional settings for the identify request. At version 4.25, the `transposedVariableName` was added to get pixel values from specific dimensional definitions if the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html">ImageryTileLayer</a> references a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#hasMultidimensionalTranspose">transposed multidimensional</a> image service. Set the `transposedVariableName` and `multidimensionalDefinition` get pixel values for the specified dimensional definitions from a transposed multidimensional service. If `multidimensionalDefinition` is not specified, pixel values will be returned from all the dimensional slices.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#identify">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wCSLayer">
    ///     The <see cref="WCSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="point">
    ///     Input point that defines the location to be identified.
    /// </param>
    /// <param name="options">
    ///     Optional settings for the identify request.
    ///     At version 4.25, the <code>transposedVariableName</code> was added to get pixel values from specific dimensional definitions if the <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html">ImageryTileLayer</a>
    ///     references a <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#hasMultidimensionalTranspose">transposed multidimensional</a> image service.
    ///     Set the <code>transposedVariableName</code> and <code>multidimensionalDefinition</code> get pixel values for the specified dimensional definitions from a transposed multidimensional service.
    ///     If <code>multidimensionalDefinition</code> is not specified, pixel values will be returned from all the dimensional slices.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<RasterIdentifyResult?> Identify(this WCSLayer wCSLayer,
        Point point,
        RasterIdentifyOptions options,
        CancellationToken cancellationToken = default)
    {
        if (wCSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wCSLayer.JsComponentReference ??= await wCSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wCSLayer.CancellationTokenSource.Token, wCSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wCSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wCSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        RasterIdentifyResult? result = await wCSLayer.JsComponentReference!.InvokeAsync<RasterIdentifyResult?>(
            "identify", 
            wCSLayer.CancellationTokenSource.Token,
            point,
            options,
            abortSignal);
                
        await wCSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WCSLayer.html#wcslayersave-method">GeoBlazor Docs</a>
    ///     Saves the layer to its existing portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a>
    ///     authenticated within the user's current session.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#save">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wCSLayer">
    ///     The <see cref="WCSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> Save(this WCSLayer wCSLayer,
        WCSLayerSaveOptions options)
    {
        if (wCSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wCSLayer.JsComponentReference ??= await wCSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wCSLayer.CancellationTokenSource.Token, wCSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wCSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wCSLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "save", 
            wCSLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WCSLayer.html#wcslayersaveas-method">GeoBlazor Docs</a>
    ///     Saves the layer to a new portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a> authenticated within the user's current session.
    ///     param options Various options for saving the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#saveAs">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wCSLayer">
    ///     The <see cref="WCSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item to which the layer will be saved.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> SaveAs(this WCSLayer wCSLayer,
        PortalItem portalItem,
        WCSLayerSaveAsOptions options)
    {
        if (wCSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wCSLayer.JsComponentReference ??= await wCSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wCSLayer.CancellationTokenSource.Token, wCSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wCSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wCSLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "saveAs", 
            wCSLayer.CancellationTokenSource.Token,
            portalItem,
            options);
    }
    

}