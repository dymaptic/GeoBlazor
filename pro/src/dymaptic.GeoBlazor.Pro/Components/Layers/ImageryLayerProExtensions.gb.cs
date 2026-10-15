namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the ImageryLayer class.
/// </summary>
public static partial class ImageryLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayercalculatevolume-method">GeoBlazor Docs</a>
    ///     Calculates volume on the elevation data for the specified <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageVolumeParameters.html#mosaicRule">mosaicRule</a>, base surface type
    ///     and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">polygon</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">extent</a> geometries.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#calculateVolume">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="baseType">
    ///     Surface type of the base elevation plane.
    ///     default "plane"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageVolumeParameters.html#baseType">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="constantZ">
    ///     Constant Z value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageVolumeParameters.html#constantZ">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometries">
    ///     An array of geometries containing <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">extents</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">polygons</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageVolumeParameters.html#geometries">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="mosaicRule">
    ///     Specifies the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MosaicRule.html">mosaic rule</a> on how individual images should be mosaicked
    ///     when the measure is computed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageVolumeParameters.html#mosaicRule">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pixelSize">
    ///     Specifies the pixel size.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageVolumeParameters.html#pixelSize">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageVolumeResult?> CalculateVolume(this ImageryLayer imageryLayer,
        BaseType? baseType,
        double? constantZ,
        IReadOnlyCollection<Geometry>? geometries,
        MosaicRule? mosaicRule,
        Point? pixelSize,
        RequestOptions requestOptions,
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
        ImageVolumeResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageVolumeResult?>(
            "calculateVolume", 
            imageryLayer.CancellationTokenSource.Token,
            new { baseType, constantZ, geometries, mosaicRule, pixelSize },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayercomputeangles-method">GeoBlazor Docs</a>
    ///     Computes the rotation angle of a ImageryLayer at a given location.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#computeAngles">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="angleNames">
    ///     Angle names to be computed.
    ///     default ["north","up"]
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAngleParameters.html#angleNames">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="rasterId">
    ///     The rasterId of a raster catalog in the image service.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAngleParameters.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="point">
    ///     A <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">point</a> geometry that defines the reference point of rotation to
    ///     compute the angle direction.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAngleParameters.html#point">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference used to compute the angles.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAngleParameters.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageAngleResult?> ComputeAngles(this ImageryLayer imageryLayer,
        IReadOnlyCollection<string>? angleNames,
        long? rasterId,
        Point? point,
        SpatialReference? spatialReference,
        RequestOptions requestOptions,
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
        ImageAngleResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageAngleResult?>(
            "computeAngles", 
            imageryLayer.CancellationTokenSource.Token,
            new { angleNames, rasterId, point, spatialReference },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayercomputehistograms-method">GeoBlazor Docs</a>
    ///     Computes histograms based on the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html">ImageHistogramParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#computeHistograms">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
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
    public static async Task<HistogramsResult?> ComputeHistograms(this ImageryLayer imageryLayer,
        Geometry? geometry,
        MosaicRule? mosaicRule,
        Point? pixelSize,
        RasterFunction? rasterFunction,
        TimeExtent? timeExtent,
        RequestOptions requestOptions,
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
        HistogramsResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<HistogramsResult?>(
            "computeHistograms", 
            imageryLayer.CancellationTokenSource.Token,
            new { geometry, mosaicRule, pixelSize, rasterFunction, timeExtent },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayercomputepixelspacelocations-method">GeoBlazor Docs</a>
    ///     Computes the corresponding pixel location in columns and rows for an image based on input geometry.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#computePixelSpaceLocations">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterId">
    ///     The rasterId of a raster catalog in the image service.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePixelLocationParameters.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometries">
    ///     An array of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">points</a> that defines pixel locations.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePixelLocationParameters.html#geometries">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImagePixelLocationResult?> ComputePixelSpaceLocations(this ImageryLayer imageryLayer,
        long? rasterId,
        IReadOnlyCollection<Point>? geometries,
        RequestOptions requestOptions,
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
        ImagePixelLocationResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImagePixelLocationResult?>(
            "computePixelSpaceLocations", 
            imageryLayer.CancellationTokenSource.Token,
            new { rasterId, geometries },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayercomputestatisticshistograms-method">GeoBlazor Docs</a>
    ///     Computes <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterBandStatistics">statistics</a> and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#RasterHistogram">histograms</a>
    ///     for the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHistogramParameters.html">ImageHistogramParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#computeStatisticsHistograms">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
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
    public static async Task<string?> ComputeStatisticsHistograms(this ImageryLayer imageryLayer,
        Geometry? geometry,
        MosaicRule? mosaicRule,
        Point? pixelSize,
        RasterFunction? rasterFunction,
        TimeExtent? timeExtent,
        RequestOptions requestOptions,
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
            "computeStatisticsHistograms", 
            imageryLayer.CancellationTokenSource.Token,
            new { geometry, mosaicRule, pixelSize, rasterFunction, timeExtent },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayercreatepopuptemplate-method">GeoBlazor Docs</a>
    ///     Creates a default popup template for the layer, populated with all the fields of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#createPopupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    [ArcGISMethod]
    public static async Task<PopupTemplate?> CreatePopupTemplate(this ImageryLayer imageryLayer,
        CreatePopupTemplateOptions options)
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
        
        return await imageryLayer.JsComponentReference!.InvokeAsync<PopupTemplate?>(
            "createPopupTemplate", 
            imageryLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerfetchpixels-method">GeoBlazor Docs</a>
    ///     Fetches raw pixel data for a specified extent, width, and height, preserving full pixel depth and including all bands without applying renderer to the layer.
    ///     param width The width of the image in pixels.
    ///     param options The parameter options is an object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#fetchPixels">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="extent">
    ///     The extent of the image to export.
    /// </param>
    /// <param name="width">
    /// </param>
    /// <param name="height">
    ///     The height of the image in pixels.
    /// </param>
    /// <param name="options">
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> FetchPixels(this ImageryLayer imageryLayer,
        Extent extent,
        int width,
        int height,
        ArcGISImageServiceFetchPixelsOptions options,
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
            "fetchPixels", 
            imageryLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,
            options,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerfindimages-method">GeoBlazor Docs</a>
    ///     Finds images based on the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FindImagesParameters.html">FindImagesParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#findImages">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="maxCount">
    ///     The maximum image count.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FindImagesParameters.html#maxCount">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="objectIds">
    ///     An array of ObjectIDs to filter images.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FindImagesParameters.html#objectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="where">
    ///     A where clause for the query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FindImagesParameters.html#where">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fromGeometry">
    ///     A <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">point</a> geometry with `z` value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FindImagesParameters.html#fromGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="toGeometry">
    ///     A <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">point</a> geometry with `z` value that defines the target geometry's location.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FindImagesParameters.html#toGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FindImagesResult?> FindImages(this ImageryLayer imageryLayer,
        int? maxCount,
        IReadOnlyCollection<ObjectId>? objectIds,
        string? where,
        Point? fromGeometry,
        Point? toGeometry,
        RequestOptions requestOptions,
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
        FindImagesResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<FindImagesResult?>(
            "findImages", 
            imageryLayer.CancellationTokenSource.Token,
            new { maxCount, objectIds, where, fromGeometry, toGeometry },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayergeneraterasterinfo-method">GeoBlazor Docs</a>
    ///     Generates raster info for the specified raster function.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#generateRasterInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterFunction">
    ///     Raster function for the requested raster info.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<RasterInfo?> GenerateRasterInfo(this ImageryLayer imageryLayer,
        RasterFunction rasterFunction,
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
        RasterInfo? result = await imageryLayer.JsComponentReference!.InvokeAsync<RasterInfo?>(
            "generateRasterInfo", 
            imageryLayer.CancellationTokenSource.Token,
            rasterFunction,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayergetcatalogitemicsinfo-method">GeoBlazor Docs</a>
    ///     Gets the <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/raster-ics.htm">image coordinate system</a>
    ///     information of a catalog item in an image service.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#getCatalogItemICSInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterId">
    ///     Raster catalog id.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetCatalogItemICSInfo(this ImageryLayer imageryLayer,
        long rasterId,
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
            "getCatalogItemICSInfo", 
            imageryLayer.CancellationTokenSource.Token,
            rasterId,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayergetcatalogitemrasterinfo-method">GeoBlazor Docs</a>
    ///     Get the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RasterInfo.html">raster info</a> of a
    ///     <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/raster-catalog-item.htm">catalog item</a> in an image service.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#getCatalogItemRasterInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterId">
    ///     Raster catalog id.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<RasterInfo?> GetCatalogItemRasterInfo(this ImageryLayer imageryLayer,
        long rasterId,
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
        RasterInfo? result = await imageryLayer.JsComponentReference!.InvokeAsync<RasterInfo?>(
            "getCatalogItemRasterInfo", 
            imageryLayer.CancellationTokenSource.Token,
            rasterId,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayergetimageurl-method">GeoBlazor Docs</a>
    ///     Retrieves an image's url using the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageUrlParameters.html">ImageUrlParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#getImageUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterId">
    ///     The raster's object id.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageUrlParameters.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="referenceUri">
    ///     The relative reference to the image's uri.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageUrlParameters.html#referenceUri">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageUrlResult?> GetImageUrl(this ImageryLayer imageryLayer,
        long? rasterId,
        string? referenceUri,
        RequestOptions requestOptions,
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
        ImageUrlResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageUrlResult?>(
            "getImageUrl", 
            imageryLayer.CancellationTokenSource.Token,
            new { rasterId, referenceUri },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayergetsamples-method">GeoBlazor Docs</a>
    ///     Returns sample point locations, pixel values and corresponding resolutions of the source data for a given geometry.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#getSamples">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
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
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageSampleResult?> GetSamples(this ImageryLayer imageryLayer,
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
        ImageSampleResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageSampleResult?>(
            "getSamples", 
            imageryLayer.CancellationTokenSource.Token,
            new { interpolation, outFields, returnFirstValueOnly, sampleCount, sampleDistance, sliceId, geometry, locations, mosaicRule, pixelSize, timeExtent },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayeridentify-method">GeoBlazor Docs</a>
    ///     Sends a request to the ArcGIS REST image service to identify content based on the
    ///     specified <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html">ImageIdentifyParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#identify">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="maxItemCount">
    ///     Controls the maximum number of returned catalog items, set to 1 to return
    ///     the top most raster only.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#maxItemCount">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="processAsMultidimensional">
    ///     When `true`, the request is processed for all variables and dimensions.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#processAsMultidimensional">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="returnCatalogItems">
    ///     If `true`, returns both geometry and attributes of the catalog items.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#returnCatalogItems">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="returnGeometry">
    ///     When `true`, each feature in the catalog items includes the geometry.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#returnGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="returnPixelValues">
    ///     If `true`, the pixel values of all raster catalog items under the requested geometry.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#returnPixelValues">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     Input geometry that defines the location to be identified.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="mosaicRule">
    ///     Specifies the mosaic rules defining the image sorting order.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#mosaicRule">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pixelSize">
    ///     Specifies the pixel level being identified on the x and y axis.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#pixelSize">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="rasterFunction">
    ///     Specifies the raster function for how the requested image should be processed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#rasterFunction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="rasterFunctions">
    ///     An array the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#rasterFunction">raster functions</a> to retrieve multiple processed pixel values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#rasterFunctions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeExtent">
    ///     A time extent for a temporal data against <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#timeInfo">time-aware imagery layer</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageIdentifyParameters.html#timeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageIdentifyResult?> Identify(this ImageryLayer imageryLayer,
        int? maxItemCount,
        bool? processAsMultidimensional,
        bool? returnCatalogItems,
        bool? returnGeometry,
        bool? returnPixelValues,
        Geometry? geometry,
        MosaicRule? mosaicRule,
        Point? pixelSize,
        RasterFunction? rasterFunction,
        IReadOnlyCollection<RasterFunction>? rasterFunctions,
        TimeExtent? timeExtent,
        RequestOptions requestOptions,
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
        ImageIdentifyResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageIdentifyResult?>(
            "identify", 
            imageryLayer.CancellationTokenSource.Token,
            new { maxItemCount, processAsMultidimensional, returnCatalogItems, returnGeometry, returnPixelValues, geometry, mosaicRule, pixelSize, rasterFunction, rasterFunctions, timeExtent },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerimagetomap-method">GeoBlazor Docs</a>
    ///     Converts a geometry from an image space to a map space using the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapParameters.html">ImageToMapParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#imageToMap">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="adjust">
    ///     When `true`, it will adjust the background vertices to be in the foreground.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapParameters.html#adjust">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="depthOffset">
    ///     The depth offset.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapParameters.html#depthOffset">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="rasterId">
    ///     The corresponding raster id for the input <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapParameters.html#geometry">geometry</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapParameters.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     The geometry in an image space.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference for the output geometry.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapParameters.html#outSpatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<Geometry?> ImageToMap(this ImageryLayer imageryLayer,
        bool? adjust,
        double? depthOffset,
        long? rasterId,
        Geometry? geometry,
        SpatialReference? outSpatialReference,
        RequestOptions requestOptions,
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
        Geometry? result = await imageryLayer.JsComponentReference!.InvokeAsync<Geometry?>(
            "imageToMap", 
            imageryLayer.CancellationTokenSource.Token,
            new { adjust, depthOffset, rasterId, geometry, outSpatialReference },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerimagetomapmultiray-method">GeoBlazor Docs</a>
    ///     Creates a map space geometry from multiray image space geometries using the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapMultirayParameters.html">ImageToMapMultirayParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#imageToMapMultiray">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterIds">
    ///     The rasterIds of the raster items that correspond to the input <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapMultirayParameters.html#geometries">geometries</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapMultirayParameters.html#rasterIds">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometries">
    ///     An array of geometries in image space coordinates representing the same map location on different images.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapMultirayParameters.html#geometries">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference for the output geometry.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageToMapMultirayParameters.html#outSpatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<Geometry?> ImageToMapMultiray(this ImageryLayer imageryLayer,
        IReadOnlyCollection<long>? rasterIds,
        IReadOnlyCollection<Geometry>? geometries,
        SpatialReference? outSpatialReference,
        RequestOptions requestOptions,
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
        Geometry? result = await imageryLayer.JsComponentReference!.InvokeAsync<Geometry?>(
            "imageToMapMultiray", 
            imageryLayer.CancellationTokenSource.Token,
            new { rasterIds, geometries, outSpatialReference },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayermaptoimage-method">GeoBlazor Docs</a>
    ///     Converts a given geometry from a map space to an image space using the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MapToImageParameters.html">MapToImageParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#mapToImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterId">
    ///     The raster id of the raster item corresponding to the input <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MapToImageParameters.html#geometry">geometry</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MapToImageParameters.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibleOnly">
    ///     When `true`, the operation will return an empty geometry if the input geometry is not visible.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MapToImageParameters.html#visibleOnly">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     The geometry in a map space (coordinates).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MapToImageParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<Geometry?> MapToImage(this ImageryLayer imageryLayer,
        long? rasterId,
        bool? visibleOnly,
        Geometry? geometry,
        RequestOptions requestOptions,
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
        Geometry? result = await imageryLayer.JsComponentReference!.InvokeAsync<Geometry?>(
            "mapToImage", 
            imageryLayer.CancellationTokenSource.Token,
            new { rasterId, visibleOnly, geometry },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayermeasureareaandperimeter-method">GeoBlazor Docs</a>
    ///     Calculates the area and perimeter of a given geometry on an image service.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measureAreaAndPerimeter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="areaUnit">
    ///     The area unit used for an area calculation.
    ///     default "square-meters"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAreaParameters.html#areaUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="is3D">
    ///     When `true`, this method calculates the 3D measurements for the area and perimeter of a given geometry on an image service.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAreaParameters.html#is3D">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="linearUnit">
    ///     Linear unit used for a perimeter calculation.
    ///     default "meters"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAreaParameters.html#linearUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     The extent or polygon geometry used to perform the area and perimeter measurement.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageAreaParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageAreaResult?> MeasureAreaAndPerimeter(this ImageryLayer imageryLayer,
        ImageAreaUnit? areaUnit,
        bool? is3D,
        LengthUnit? linearUnit,
        Geometry? geometry,
        RequestOptions requestOptions,
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
        ImageAreaResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageAreaResult?>(
            "measureAreaAndPerimeter", 
            imageryLayer.CancellationTokenSource.Token,
            new { areaUnit, is3D, linearUnit, geometry, type = "area-perimeter" },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayermeasureareafromimage-method">GeoBlazor Docs</a>
    ///     Measures the area and the perimeter of a polygon in an image space on a selected raster when the following conditions are met:
    ///     Image service must be published from a mosaic dataset.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measureAreaFromImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterId">
    ///     The id of the raster to be measured.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MeasureFromImageParameters.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     The polyline or polygon geometry used to perform length or area measurements in an image space.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MeasureFromImageParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<MeasureAreaFromImageResult?> MeasureAreaFromImage(this ImageryLayer imageryLayer,
        long? rasterId,
        Geometry? geometry,
        RequestOptions requestOptions,
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
        MeasureAreaFromImageResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<MeasureAreaFromImageResult?>(
            "measureAreaFromImage", 
            imageryLayer.CancellationTokenSource.Token,
            new { rasterId, geometry },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayermeasuredistanceandangle-method">GeoBlazor Docs</a>
    ///     Calculates the distance and angle between two points on an image service.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measureDistanceAndAngle">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="angularUnit">
    ///     The angular unit used for angle calculation.
    ///     default "degrees"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageDistanceParameters.html#angularUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="is3D">
    ///     When `true`, this method calculates the 3D measurements for the distance and angle between two points on an image service.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageDistanceParameters.html#is3D">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="linearUnit">
    ///     The linear unit used for distance calculation.
    ///     default "meters"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageDistanceParameters.html#linearUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fromGeometry">
    ///     A point that defines the from location of the distance and angle measurement.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageDistanceParameters.html#fromGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="toGeometry">
    ///     A point that defines the to location of the distance and angle measurement.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageDistanceParameters.html#toGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageDistanceResult?> MeasureDistanceAndAngle(this ImageryLayer imageryLayer,
        AngularUnit? angularUnit,
        bool? is3D,
        LengthUnit? linearUnit,
        Point? fromGeometry,
        Point? toGeometry,
        RequestOptions requestOptions,
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
        ImageDistanceResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageDistanceResult?>(
            "measureDistanceAndAngle", 
            imageryLayer.CancellationTokenSource.Token,
            new { angularUnit, is3D, linearUnit, fromGeometry, toGeometry, type = "distance-angle" },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayermeasureheight-method">GeoBlazor Docs</a>
    ///     Calculates the height of an object between two points on an image service if the sensor info is available.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measureHeight">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="linearUnit">
    ///     Linear unit used for height calculation.
    ///     default "meters"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#linearUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="operationType">
    ///     Determines how the height will be measured when the sensor info is available.
    ///     default "base-and-top"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#operationType">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fromGeometry">
    ///     A point that defines the from location of the height measurement.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#fromGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="toGeometry">
    ///     A point that defines the to location of the height measurement.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageHeightParameters.html#toGeometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageHeightResult?> MeasureHeight(this ImageryLayer imageryLayer,
        LengthUnit? linearUnit,
        OperationType? operationType,
        Point? fromGeometry,
        Point? toGeometry,
        RequestOptions requestOptions,
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
        ImageHeightResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageHeightResult?>(
            "measureHeight", 
            imageryLayer.CancellationTokenSource.Token,
            new { linearUnit, operationType, fromGeometry, toGeometry, type = "height" },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayermeasurelengthfromimage-method">GeoBlazor Docs</a>
    ///     Measures the length of a polyline in an image space on a selected raster when the following conditions are met:
    ///     Image service must be published from a mosaic dataset.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measureLengthFromImage">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="rasterId">
    ///     The id of the raster to be measured.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MeasureFromImageParameters.html#rasterId">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     The polyline or polygon geometry used to perform length or area measurements in an image space.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MeasureFromImageParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<MeasureLengthFromImageResult?> MeasureLengthFromImage(this ImageryLayer imageryLayer,
        long? rasterId,
        Geometry? geometry,
        RequestOptions requestOptions,
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
        MeasureLengthFromImageResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<MeasureLengthFromImageResult?>(
            "measureLengthFromImage", 
            imageryLayer.CancellationTokenSource.Token,
            new { rasterId, geometry },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayermeasurepointorcentroid-method">GeoBlazor Docs</a>
    ///     Returns the location for a given point or centroid of a given area on an image service.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#measurePointOrCentroid">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="is3D">
    ///     When `true`, this method calculates the z-value for the returned point geometry.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePointParameters.html#is3D">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     Input geometry to determine a point location or a centroid of a given area.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImagePointParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImagePointResult?> MeasurePointOrCentroid(this ImageryLayer imageryLayer,
        bool? is3D,
        Geometry? geometry,
        RequestOptions requestOptions,
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
        ImagePointResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImagePointResult?>(
            "measurePointOrCentroid", 
            imageryLayer.CancellationTokenSource.Token,
            new { is3D, geometry, type = "point" },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerqueryboundary-method">GeoBlazor Docs</a>
    ///     Returns the boundary of an image for the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageBoundaryParameters.html">ImageBoundaryParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#queryBoundary">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference for the output boundary geometry.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageBoundaryParameters.html#outSpatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageBoundaryResult?> QueryBoundary(this ImageryLayer imageryLayer,
        SpatialReference? outSpatialReference,
        RequestOptions requestOptions,
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
        ImageBoundaryResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageBoundaryResult?>(
            "queryBoundary", 
            imageryLayer.CancellationTokenSource.Token,
            new { outSpatialReference },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerquerygpsinfo-method">GeoBlazor Docs</a>
    ///     Returns GPS information for the provided <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfoParameters.html">ImageGPSInfoParameters</a>.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#queryGPSInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="objectIds">
    ///     An array of ObjectIDs to be used to query images.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfoParameters.html#objectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialRelationship">
    ///     For spatial queries, this parameter defines the spatial relationship to query image footprints
    ///     in the layer against the input <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfoParameters.html#geometry">geometry</a>.
    ///     default "intersects"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfoParameters.html#spatialRelationship">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="where">
    ///     A where clause for the query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfoParameters.html#where">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     The geometry to query images.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfoParameters.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeExtent">
    ///     A time extent for a temporal query to query images.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ImageGPSInfoParameters.html#timeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ImageGPSInfoResult?> QueryGPSInfo(this ImageryLayer imageryLayer,
        IReadOnlyCollection<ObjectId>? objectIds,
        SpatialRelationship? spatialRelationship,
        string? where,
        Geometry? geometry,
        TimeExtent? timeExtent,
        RequestOptions requestOptions,
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
        ImageGPSInfoResult? result = await imageryLayer.JsComponentReference!.InvokeAsync<ImageGPSInfoResult?>(
            "queryGPSInfo", 
            imageryLayer.CancellationTokenSource.Token,
            new { objectIds, spatialRelationship, where, geometry, timeExtent },
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerqueryobjectids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the image service and returns an
    ///     array of Object IDs for the rasters.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#queryObjectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the query parameters. If no parameters are specified, then all Object IDs satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ObjectId[]?> QueryObjectIds(this ImageryLayer imageryLayer,
        Query query,
        RequestOptions requestOptions,
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
        ObjectId[]? result = await imageryLayer.JsComponentReference!.InvokeAsync<ObjectId[]?>(
            "queryObjectIds", 
            imageryLayer.CancellationTokenSource.Token,
            query,
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerqueryrastercount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the image service and
    ///     returns the number of rasters that satisfy the query.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#queryRasterCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the query parameters. If no parameters are specified, then count of all rasters satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> QueryRasterCount(this ImageryLayer imageryLayer,
        Query query,
        RequestOptions requestOptions,
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
        int? result = await imageryLayer.JsComponentReference!.InvokeAsync<int?>(
            "queryRasterCount", 
            imageryLayer.CancellationTokenSource.Token,
            query,
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerqueryrasters-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against an image service and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a> once the promise resolves.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request (will override requestOptions defined during construction).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#queryRasters">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the query parameters. If no parameters are specified, then all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request
    ///     (will override requestOptions defined during construction).
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryRasters(this ImageryLayer imageryLayer,
        Query query,
        RequestOptions requestOptions,
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
        FeatureSet? result = await imageryLayer.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryRasters", 
            imageryLayer.CancellationTokenSource.Token,
            query,
            requestOptions,
            abortSignal);
                
        await imageryLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayerredraw-method">GeoBlazor Docs</a>
    ///     Executes the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#pixelFilter">pixelFilter</a> function and redraws the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#redraw">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task Redraw(this ImageryLayer imageryLayer)
    {
        if (imageryLayer.CoreJsModule is null)
        {
            return;
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
            return;
        }
        
        await imageryLayer.JsComponentReference!.InvokeVoidAsync(
            "redraw", 
            imageryLayer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayersave-method">GeoBlazor Docs</a>
    ///     Saves the layer to its existing portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a>
    ///     authenticated within the user's current session.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#save">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> Save(this ImageryLayer imageryLayer,
        ImageryLayerSaveOptions options)
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
        
        return await imageryLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "save", 
            imageryLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.ImageryLayer.html#imagerylayersaveas-method">GeoBlazor Docs</a>
    ///     Saves the layer to a new portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a> authenticated within the user's current session.
    ///     param options Various options for saving the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#saveAs">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="imageryLayer">
    ///     The <see cref="ImageryLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item to which the layer will be saved.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> SaveAs(this ImageryLayer imageryLayer,
        PortalItem portalItem,
        ImageryLayerSaveAsOptions options)
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
        
        return await imageryLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "saveAs", 
            imageryLayer.CancellationTokenSource.Token,
            portalItem,
            options);
    }
    

}