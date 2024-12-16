namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Represents a pixel in a colormap.
/// </summary>
/// <param name="Value">
///     The value of the pixel.
/// </param>
/// <param name="Red">
///     The red value of the pixel.
/// </param>
/// <param name="Green">
///     The green value of the pixel.
/// </param>
/// <param name="Blue">
///     The blue value of the pixel.
/// </param>
public record ColormapPixel(double Value, double Red, double Green, double Blue);