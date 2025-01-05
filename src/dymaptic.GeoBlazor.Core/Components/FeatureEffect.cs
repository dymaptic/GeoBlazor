namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FeatureEffect : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public FeatureEffect()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="excludedEffect">
    ///     The [effect](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#Effect) applied to features that do not meet the [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter) requirements.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#excludedEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="excludedLabelsVisible">
    ///     Indicates if labels are visible for features that are [excluded](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#excludedEffect) from the [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter).
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#excludedLabelsVisible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filter">
    ///     The [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html) that drives the effect.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="includedEffect">
    ///     The [effect](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#Effect) applied to features that meet the [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter) requirements.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#includedEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public FeatureEffect(IReadOnlyList<Effect>? excludedEffect = null, bool? excludedLabelsVisible = null, FeatureFilter? filter = null, IReadOnlyList<Effect>? includedEffect = null)
    {
#pragma warning disable BL0005
        ExcludedEffect = excludedEffect;
        ExcludedLabelsVisible = excludedLabelsVisible;
        Filter = filter;
        IncludedEffect = includedEffect;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The [effect](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#Effect) applied to features that do not meet the [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter) requirements.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#excludedEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Effect>? ExcludedEffect { get; set; }
    /// <summary>
    /// Indicates if labels are visible for features that are excluded from the filter.
    /// </summary>
    public bool? ExcludedLabelsVisible { get; set; }
    /// <summary>
    ///  The filter that drives the effect.
    /// </summary>
    public FeatureFilter? Filter { get; set; }

    /// <summary>
    ///     The [effect](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#Effect) applied to features that meet the [filter](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#filter) requirements.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html#includedEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Effect>? IncludedEffect { get; set; }
}