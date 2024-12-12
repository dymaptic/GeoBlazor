namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     The SketchTooltipOptions allows users to configure the tooltips which are shown while sketching and editing.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-interactive-sketch-SketchTooltipOptions.html">ArcGIS JS API</a>
/// </summary>
/// <param name="Enabled">
///     Whether tooltips are shown while sketching and editing.
///     Default Value:false
/// </param>
public record SketchTooltipOptions(bool Enabled);