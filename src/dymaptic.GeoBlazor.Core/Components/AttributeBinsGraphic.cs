namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.AttributeBinsGraphic.html">GeoBlazor Docs</a>
///     A Graphic returned in a FeatureSet as result of running `queryAttributeBins()` method.
///     <a target="_blank"
///        href="https://developers.arcgis.com/javascript/latest/api-reference/esri-AttributeBinsGraphic.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class AttributeBinsGraphic : Graphic
{
    /// <summary>
    ///     The stackedAttributes contains an array of name-value pairs, where the names correspond to unique values of the specified field or expression alias.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-AttributeBinsGraphic.html#stackedAttributes">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public Dictionary<string, string>? StackedAttributes { get; set; }
}