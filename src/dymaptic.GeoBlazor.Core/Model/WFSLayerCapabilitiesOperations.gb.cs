// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.WFSLayerCapabilitiesOperations.html">GeoBlazor Docs</a>
///     Describes operations that can be performed on features in the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="SupportsAdd">
///     Indicates if new features can be <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#applyEdits">added</a> to the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsCalculate">
///     Indicates if values of one or more field values in the layer can be updated.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsDelete">
///     Indicates if features can be <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#applyEdits">deleted</a> from the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsEditing">
///     Indicates if features in the layer can be <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#applyEdits">edited</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsQuery">
///     Indicates if features in the layer can be <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#queryFeatures">queried</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsQueryAttachments">
///     Indicates if the layer supports <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/query-attachments-feature-service-layer-.htm">REST API queryAttachments</a> operation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsResizeAttachments">
///     Indicates if resized attachments are supported in the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsUpdate">
///     Indicates if features in the layer can be <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#applyEdits">updated</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsValidateSql">
///     Indicates if the layer supports a SQL-92 expression or where clause.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record WFSLayerCapabilitiesOperations(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsAdd = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsCalculate = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsDelete = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsEditing = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQuery = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryAttachments = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsResizeAttachments = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsUpdate = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsValidateSql = null);
