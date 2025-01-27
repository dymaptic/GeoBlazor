// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///    Indicates if the layer's query operation supports querying features or records related to features in the layer.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="SupportsCount">
///     Indicates if the layer's query response includes the number of features or records related to features in the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsOrderBy">
///     Indicates if the related features or records returned in the query response can be ordered by one or more fields.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsPagination">
///     Indicates if the query response supports pagination for related features or records.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record GeoJSONLayerCapabilitiesQueryRelated(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsCount = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsOrderBy = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsPagination = null);

