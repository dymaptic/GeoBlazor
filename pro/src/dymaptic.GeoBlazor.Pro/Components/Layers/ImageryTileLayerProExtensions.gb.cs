namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the ImageryTileLayer class.
/// </summary>
public static partial class ImageryTileLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayercomputestatisticshistograms-method">GeoBlazor Docs</a>
    ///     Computes <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">statistics</a> and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">histograms</a>
    ///     for the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html">ImageHistogramParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#computeStatisticsHistograms">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="geometry">
    ///     Input geometry that defines the area of interest for which the histograms and statistics will be computed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="mosaicRule">
    ///     Specifies the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MosaicRule.html">mosaic rule</a> on how individual images should be mosaicked
    ///     when the histogram is computed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html#mosaicRule">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pixelSize">
    ///     Specifies the pixel size (or the resolution).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html#pixelSize">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="rasterFunction">
    ///     Specifies the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterFunction.html">raster function</a> from which to compute the statistics and histogram.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html#rasterFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeExtent">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-time-TimeExtent.html">time extent</a> for which to compute the statistics and histogram.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html#timeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> ComputeStatisticsHistograms(this ImageryTileLayer imageryTileLayer,
        Geometry? geometry,
        MosaicRule? mosaicRule,
        Point? pixelSize,
        RasterFunction? rasterFunction,
        TimeExtent? timeExtent,
        RequestOptions requestOptions,
        CancellationToken cancellationToken = default)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await imageryTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        string? result = await imageryTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "computeStatisticsHistograms", 
            imageryTileLayer.CancellationTokenSource.Token,
            new { geometry, mosaicRule, pixelSize, rasterFunction, timeExtent },
            requestOptions,
            abortSignal);
                
        await imageryTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayercreatepopuptemplate-method">GeoBlazor Docs</a>
    ///     Creates a default popup template for the layer, populated with all the fields of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#createPopupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    [ArcGISMethod]
    public static async Task<PopupTemplate?> CreatePopupTemplate(this ImageryTileLayer imageryTileLayer,
        CreatePopupTemplateOptions options)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await imageryTileLayer.JsComponentReference!.InvokeAsync<PopupTemplate?>(
            "createPopupTemplate", 
            imageryTileLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayerfetchpixels-method">GeoBlazor Docs</a>
    ///     Fetches pixels for a given extent.
    ///     param width The width of the image in pixels.
    ///     param options The parameter options is an object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#fetchPixels">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
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
    public static async Task<PixelData?> FetchPixels(this ImageryTileLayer imageryTileLayer,
        Extent extent,
        int width,
        int height,
        ImageryTileMixinFetchPixelsOptions options,
        CancellationToken cancellationToken = default)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await imageryTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        PixelData? result = await imageryTileLayer.JsComponentReference!.InvokeAsync<PixelData?>(
            "fetchPixels", 
            imageryTileLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,
            options,
            abortSignal);
                
        await imageryTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayerfetchtile-method">GeoBlazor Docs</a>
    ///     This method fetches a tile for the given level, row and column present in the view.
    ///     param row The row (y) position of the tile fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    ///     param options Optional settings for the tile request.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#fetchTile">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     Level of detail of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="row">
    ///     The row (y) position of the tile fetch. This value is provided by <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="col">
    ///     The column (x) position of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> FetchTile(this ImageryTileLayer imageryTileLayer,
        double level,
        double row,
        double col,
        CancellationToken cancellationToken = default)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await imageryTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        string? result = await imageryTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "fetchTile", 
            imageryTileLayer.CancellationTokenSource.Token,
            level,
            row,
            col,
            abortSignal);
                
        await imageryTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayergeneraterasterinfo-method">GeoBlazor Docs</a>
    ///     Generates a new raster info for the specified client side raster function.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#generateRasterInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterFunction">
    ///     Raster function for the requested raster info.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<RasterInfo?> GenerateRasterInfo(this ImageryTileLayer imageryTileLayer,
        RasterFunction rasterFunction,
        CancellationToken cancellationToken = default)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await imageryTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        RasterInfo? result = await imageryTileLayer.JsComponentReference!.InvokeAsync<RasterInfo?>(
            "generateRasterInfo", 
            imageryTileLayer.CancellationTokenSource.Token,
            rasterFunction,
            abortSignal);
                
        await imageryTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayergetsamples-method">GeoBlazor Docs</a>
    ///     Returns sample point locations, pixel values and corresponding resolutions of the source data for a given geometry.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#getSamples">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
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
    public static async Task<ImageSampleResult?> GetSamples(this ImageryTileLayer imageryTileLayer,
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
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await imageryTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ImageSampleResult? result = await imageryTileLayer.JsComponentReference!.InvokeAsync<ImageSampleResult?>(
            "getSamples", 
            imageryTileLayer.CancellationTokenSource.Token,
            new { interpolation, outFields, returnFirstValueOnly, sampleCount, sampleDistance, sliceId, geometry, locations, mosaicRule, pixelSize, timeExtent },
            requestOptions,
            abortSignal);
                
        await imageryTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayeridentify-method">GeoBlazor Docs</a>
    ///     Identify pixel values at a given location.
    ///     param options Optional settings for the identify request. At version 4.25, the `transposedVariableName` was added to get pixel values from specific dimensional definitions if the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html">ImageryTileLayer</a> references a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html#hasMultidimensionalTranspose">transposed multidimensional</a> image service. Set the `transposedVariableName` and `multidimensionalDefinition` get pixel values for the specified dimensional definitions from a transposed multidimensional service. If `multidimensionalDefinition` is not specified, pixel values will be returned from all the dimensional slices.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#identify">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
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
    public static async Task<RasterIdentifyResult?> Identify(this ImageryTileLayer imageryTileLayer,
        Point point,
        RasterIdentifyOptions options,
        CancellationToken cancellationToken = default)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await imageryTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        RasterIdentifyResult? result = await imageryTileLayer.JsComponentReference!.InvokeAsync<RasterIdentifyResult?>(
            "identify", 
            imageryTileLayer.CancellationTokenSource.Token,
            point,
            options,
            abortSignal);
                
        await imageryTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayersave-method">GeoBlazor Docs</a>
    ///     Saves the layer to its existing portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a>
    ///     authenticated within the user's current session.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#save">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> Save(this ImageryTileLayer imageryTileLayer,
        ImageryTileLayerSaveOptions options)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await imageryTileLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "save", 
            imageryTileLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryTileLayer.html#imagerytilelayersaveas-method">GeoBlazor Docs</a>
    ///     Saves the layer to a new portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a> authenticated within the user's current session.
    ///     param options Various options for saving the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryTileLayer.html#saveAs">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryTileLayer">
    ///     The <see cref="ImageryTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item to which the layer will be saved.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> SaveAs(this ImageryTileLayer imageryTileLayer,
        PortalItem portalItem,
        ImageryTileLayerSaveAsOptions options)
    {
        if (imageryTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            imageryTileLayer.JsComponentReference ??= await imageryTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", imageryTileLayer.CancellationTokenSource.Token, imageryTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (imageryTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await imageryTileLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "saveAs", 
            imageryTileLayer.CancellationTokenSource.Token,
            portalItem,
            options);
    }
    

}