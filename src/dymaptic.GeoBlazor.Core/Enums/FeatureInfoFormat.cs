
// ReSharper disable InconsistentNaming


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The MIME type that will be requested by popups.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMSLayer.html#featureInfoFormat">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public enum FeatureInfoFormat
{
    /// <summary>
    ///     The feature information is returned as HTML.
    /// </summary>
    Text_Html,
    /// <summary>
    ///     The feature information is returned as plain text.
    /// </summary>
    Text_Plain
}