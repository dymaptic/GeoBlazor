using dymaptic.GeoBlazor.Pro.Components.Widgets;


namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     Default create options set for the Sketch widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Sketch.html#defaultCreateOptions">ArcGIS JS API</a>
/// </summary>
/// <param name="Mode">
///     Create operation mode how the graphic can be created.
/// </param>
/// <param name="HasZ">
///     Controls whether the created geometry has z-values or not.
/// </param>
/// <param name="DefaultZ">
///     The default z-value of the newly created geometry. Ignored when hasZ is false or the layer's elevation mode is set to absolute-height.
/// </param>
public record SketchToolCreateOptions(CreateOptionsMode Mode, bool HasZ, bool DefaultZ);