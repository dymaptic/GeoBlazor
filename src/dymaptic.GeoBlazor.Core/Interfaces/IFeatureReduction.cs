namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for FeatureReduction classes available in GeoBlazor Pro.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureReduction.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IFeatureReduction>))]
public interface IFeatureReduction: IMapComponent
{
    // Add custom code to this file to override generated code
}