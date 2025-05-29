namespace dymaptic.GeoBlazor.Core.Components;

public partial class FeatureEffect : MapComponent
{


    /// <summary>
    ///     The [effect](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#Effect) applied to features that do not meet the [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter) requirements.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#excludedEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Effect>? ExcludedEffect { get; set; }


    /// <summary>
    ///     The [effect](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#Effect) applied to features that meet the [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter) requirements.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#includedEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Effect>? IncludedEffect { get; set; }
}