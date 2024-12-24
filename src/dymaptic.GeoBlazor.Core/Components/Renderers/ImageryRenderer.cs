namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     The IImageryRenderer is an interface for a group of renderers used for Imagery Layers
/// </summary>
[JsonConverter(typeof(ImageryRendererConverter))]
public interface IImageryRenderer
{
    /// <summary>
    ///     The type of renderer.
    /// </summary>
    public ImageryRendererType Type { get; }
}