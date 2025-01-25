namespace dymaptic.GeoBlazor.Core.Components.Renderers;

[JsonConverter(typeof(RendererConverter))]
public abstract partial class Renderer: MapComponent
{
    /// <summary>
    ///     The subclass Renderer type
    /// </summary>
    public abstract RendererType Type { get; }

}