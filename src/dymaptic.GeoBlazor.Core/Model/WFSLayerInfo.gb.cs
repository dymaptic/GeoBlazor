// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.WFSLayerInfo.html">GeoBlazor Docs</a>
///     The layer info from the WFS service.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="CustomParameters">
///     The custom parameters applied to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Extent">
///     The extent of the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Fields">
///     The fields on the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="GeometryType">
///     The geometry type of the features in the layer.
///     <a target="_blank" href="global.html#geometryType">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Name">
///     The name of the layer in the WFS service to display.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="NamespaceUri">
///     The namespace URI for the layer name.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ObjectIdField">
///     The field containing the object ID.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SpatialReference">
///     The spatial reference of the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SwapXY">
///     Determines whether the X and Y coordinates should be swapped.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Url">
///     The URL to the WFS service.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="WfsCapabilities">
/// </param>
public partial record WFSLayerInfo(
    Dictionary<string, object>? CustomParameters = null,
    Extent? Extent = null,
    IReadOnlyCollection<Field>? Fields = null,
    SimpleGeometryType? GeometryType = null,
    string? Name = null,
    string? NamespaceUri = null,
    string? ObjectIdField = null,
    SpatialReference? SpatialReference = null,
    bool? SwapXY = null,
    string? Url = null,
    WFSCapabilities? WfsCapabilities = null)
{
    /// <summary>
    ///     The custom parameters applied to the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public Dictionary<string, object>? CustomParameters { get; set; } = CustomParameters;
    
    /// <summary>
    ///     The extent of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public Extent? Extent { get; set; } = Extent;
    
    /// <summary>
    ///     The fields on the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public IReadOnlyCollection<Field>? Fields { get; set; } = Fields;
    
    /// <summary>
    ///     The geometry type of the features in the layer.
    ///     <a target="_blank" href="global.html#geometryType">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public SimpleGeometryType? GeometryType { get; set; } = GeometryType;
    
    /// <summary>
    ///     The name of the layer in the WFS service to display.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public string? Name { get; set; } = Name;
    
    /// <summary>
    ///     The namespace URI for the layer name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public string? NamespaceUri { get; set; } = NamespaceUri;
    
    /// <summary>
    ///     The field containing the object ID.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public string? ObjectIdField { get; set; } = ObjectIdField;
    
    /// <summary>
    ///     The spatial reference of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public SpatialReference? SpatialReference { get; set; } = SpatialReference;
    
    /// <summary>
    ///     Determines whether the X and Y coordinates should be swapped.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public bool? SwapXY { get; set; } = SwapXY;
    
    /// <summary>
    ///     The URL to the WFS service.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ogc-wfsUtils.html#WFSLayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public string? Url { get; set; } = Url;
    
    /// <summary>
    ///     
    /// </summary>
    public WFSCapabilities? WfsCapabilities { get; set; } = WfsCapabilities;
    
}
