// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    
/// </summary>
/// <param name="Pixels">
///     A two dimensional array representing the pixels to add.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#addData">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Statistics">
///     An array of objects containing numeric statistical properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#addData">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record PixelBlockAddDataPlaneData(
    IReadOnlyCollection<double>? Pixels = null,
    IReadOnlyCollection<string>? Statistics = null)
{
    /// <summary>
    ///     A two dimensional array representing the pixels to add.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#addData">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public IReadOnlyCollection<double>? Pixels { get; set; } = Pixels;
    
    /// <summary>
    ///     An array of objects containing numeric statistical properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-PixelBlock.html#addData">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public IReadOnlyCollection<string>? Statistics { get; set; } = Statistics;
    
}

