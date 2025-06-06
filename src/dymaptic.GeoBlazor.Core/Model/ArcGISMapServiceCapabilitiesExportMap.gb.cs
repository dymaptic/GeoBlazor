// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.ArcGISMapServiceCapabilitiesExportMap.html">GeoBlazor Docs</a>
///     Indicates options supported by the exportMap operation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="SupportsArcadeExpressionForLabeling">
///     Indicates if sublayers support Arcade expressions for labeling.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsCIMSymbols">
///     _Since 4.23_ Indicates if <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-CIMSymbol.html">CIMSymbol</a> can be used in a sublayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#renderer">renderer</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsDynamicLayers">
///     Indicates if sublayers rendering can be modified or added using dynamic layers.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsSublayerDefinitionExpression">
///     Indicates if sublayers <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#definitionExpression">definition expression</a> can be set.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsSublayerOrderBy">
/// </param>
/// <param name="SupportsSublayersChanges">
///     Indicates if sublayers can be added, or removed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SupportsSublayerVisibility">
///     Indicates if sublayers <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#visible">visibility</a> can be changed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ArcGISMapService.html#capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ArcGISMapServiceCapabilitiesExportMap(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsArcadeExpressionForLabeling = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsCIMSymbols = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsDynamicLayers = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSublayerDefinitionExpression = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSublayerOrderBy = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSublayersChanges = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? SupportsSublayerVisibility = null);
