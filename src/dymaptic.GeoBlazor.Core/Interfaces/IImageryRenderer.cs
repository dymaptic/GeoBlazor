namespace dymaptic.GeoBlazor.Core.Interfaces;

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