namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     The SketchLabelOptions allows users to configure the labels which are shown next to each segment of a graphic while sketching and editing.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-interactive-sketch-SketchLabelOptions.html">ArcGIS JS API</a>
/// </summary>
/// <remarks>
///     Known Limitation: The SketchLabelOptions allows users to configure the labels which are shown next to each segment of a graphic while sketching and editing.
/// </remarks>
/// <param name="Enabled">
///     Whether labels are shown next to each segment of the graphic being sketched.
///     Default Value:false
/// </param>
public record SketchLabelOptions(bool Enabled);