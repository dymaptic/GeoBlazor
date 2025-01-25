// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    Describes operations that can be performed on features in the layer.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="SupportsQuery">
///     Indicates if features in the layer can be <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#queryFeatures">queried</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsQueryAttachments">
///     Indicates if the layer supports <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/query-attachments-feature-service-layer-.htm">REST API queryAttachments</a> operation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record SublayerCapabilitiesOperations(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQuery = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsQueryAttachments = null);

