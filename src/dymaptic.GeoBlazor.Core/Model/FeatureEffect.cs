namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureEffect.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FeatureEffect: MapComponent
{
    /// <summary>
    /// The effect applied to features that do not meet the filter requirements.
    /// </summary>
    public List<Effect>? ExcludedEffect { get; set; }

    /// <summary>
    /// Indicates if labels are visible for features that are excluded from the filter.
    /// </summary>
    public bool? ExcludedLabelsVisible { get; set; }

    /// <summary>
    ///  The filter that drives the effect.
    /// </summary>
    public FeatureFilter? Filter { get; set; }

    /// <summary>
    /// The effect applied to features that meet the filter requirements.
    /// </summary>
    public List<Effect>? IncludedEffect { get; set; }

}