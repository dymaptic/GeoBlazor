// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Results.EditedFeatureResult.html">GeoBlazor Docs</a>
///     Results returned from the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#applyEdits">applyEdits</a> method if the `returnServiceEditsOption` parameter is set to `original-and-current-features`.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditedFeatureResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="LayerId">
///     The layerId of the feature layer where features were edited.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditedFeatureResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="EditedFeatures">
///     Object containing all edited features belonging to the specified layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditedFeatureResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record EditedFeatureResult(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? LayerId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    EditedFeatureResultEditedFeatures? EditedFeatures = null);
