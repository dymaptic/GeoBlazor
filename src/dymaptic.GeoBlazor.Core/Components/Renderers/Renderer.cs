namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     Abstract base class, renderers define how to visually represent each feature in one of the following layer types:
///     FeatureLayer, SceneLayer, MapImageLayer, CSVLayer, GeoJSONLayer, OGCFeatureLayer, StreamLayer, WFSLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-Renderer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(RendererConverter))]
public abstract class Renderer: MapComponent
{
    /// <summary>
    ///     The subclass Renderer type
    /// </summary>
    public abstract RendererType Type { get; }
    
    /// <summary>
    ///     Authoring metadata only included in renderers generated from one of the Smart Mapping creator methods, such as sizeRendererCreator.createContinuousRenderer() or colorRendererCreator.createContinuousRenderer(). This includes information from UI elements such as sliders and selected classification methods and themes. This allows the authoring clients to save specific overridable settings so that next time it is accessed via the UI, their selections can be remembered.
    /// </summary>
    [JsonInclude]
    public AuthoringInfo? AuthoringInfo { get; private init; }
}