namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.WfsUtils.html">GeoBlazor Docs</a>
///     Provides utility functions for the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html">WFSLayer</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class WfsUtils: ProLogicComponent
{ 
    // Add custom code to this file to override generated code
    
    /// <summary>
    ///     Constructs a new instance of the <see cref="WfsUtils"/> class.
    /// </summary>
   public WfsUtils(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager,
      IAppValidator appValidator, IJSRuntime jsRuntime)
      : base(authenticationManager, jsModuleManager, appValidator, jsRuntime)
   {
   }
   
    /// <inheritdoc />
   protected override string ComponentName => nameof(WfsUtils);
   
   /// <inheritdoc />
   protected override string Library => "Pro";
   
   /// <summary>
   ///     The maximum size of query results that will be returned in a stream. Note that setting this to a smaller value might create errors in query returns.
   /// </summary>
   public long QueryResultsMaxSizeLimit { get; set; } = 1_000_000_000L;
   
#region Public Methods

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.WfsUtils.html#wfsutilsgetcapabilities-method">GeoBlazor Docs</a>
    ///     Fetches the GetCapabilities document of a WFS service which contains information about the
    ///     list of layers in the service and the available operations.
    ///     param options
    ///     param options.signal An <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal">AbortSignal</a> to abort the executions of the remote method. If canceled, the promise will be rejected with an error named `AbortError`. See also <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/AbortController">AbortController</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#getCapabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     The URL to the WFS endpoint.
    /// </param>
    /// <param name="options">
    ///     - options.customParameters: A list of key-value pairs of parameters to append to the url.
    /// </param>
    [ArcGISMethod]
    public async Task<WFSCapabilities?> GetCapabilities(string url,
        WfsUtilsGetCapabilitiesOptions? options = null)
    {
        _wfsCapabilities = null;
        await InvokeAsync<WFSCapabilities?>("getCapabilities", url, options);
        return _wfsCapabilities;
    }

    /// <summary>
    ///     JS-Invoked response handler for the GetCapabilities request.
    /// </summary>
    [JSInvokable]
    public async Task OnGetCapabilities(IJSStreamReference jsStreamReference)
    {
        _wfsCapabilities = await jsStreamReference.ReadJsStreamReference<WFSCapabilities>();
    }

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.WfsUtils.html#wfsutilsgetwfslayerinfo-method">GeoBlazor Docs</a>
    ///     Returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">WFSLayerInfo</a> from the capabilities of the WFS service.
    ///     param name The type name to get information for. If not specified, the first layer of the service is chosen.
    ///     param options An object specifying additional options. See the object specification table below for the required properties of this object.
    ///     param options.spatialReference The desired spatial reference for the layer. By default will use the default spatial reference of the feature type.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#getWFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="capabilities">
    ///     The capabilities of the WFS service.
    /// </param>
    /// <param name="name">
    /// </param>
    /// <param name="namespaceUri">
    ///     The namespace URI of the type name. If not specified, the first namespace found for the `name` is chosen.
    /// </param>
    /// <param name="options">
    ///     - options.customParameters: A list of key-value pairs of parameters to append to the url.
    ///     - options.signal: An <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/AbortSignal">AbortSignal</a> to abort the executions of the remote method. If canceled, the promise will be rejected with an error named `AbortError`. See also <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/AbortController">AbortController</a>.
    /// </param>
    [ArcGISMethod]
    public async Task<WFSLayerInfo?> GetWFSLayerInfo(WFSCapabilities capabilities,
        string? name = null,
        string? namespaceUri = null,
        WfsUtilsGetWFSLayerInfoOptions? options = null)
    {
        // capabilities are too expensive to pass back and forth, so we pass just the url
        WFSLayerInfo? layerInfo = await InvokeAsync<WFSLayerInfo?>("getWFSLayerInfo", capabilities.Url, name, 
            namespaceUri, options);
        
        if (layerInfo is not null)
        {
            // then we set the capabilities on the layer info result
            layerInfo.WfsCapabilities = capabilities;
        }

        return layerInfo;
    }
    
    /// <summary>
    ///     Converts the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">WFSLayerInfo</a> to a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html">WFSLayer</a>.
    /// </summary>
    [ArcGISMethod]
    public async Task<WFSLayer?> GetLayerFromLayerInfo(WFSLayerInfo wfsLayerInfo)
    {
        // remove the WfsCapabilities from the layer info to speed up the serialization
        WFSCapabilities? capabilities = wfsLayerInfo.WfsCapabilities;
        wfsLayerInfo.WfsCapabilities = null;
        WFSLayer? layer = await InvokeAsync<WFSLayer?>("getLayerFromLayerInfo", wfsLayerInfo);
        if (layer is not null)
        {
            // set the WfsCapabilities on the layer and the layer info
            wfsLayerInfo.WfsCapabilities = capabilities;
        }

        return layer;
    }
    
#endregion
    
    private WFSCapabilities? _wfsCapabilities;
}