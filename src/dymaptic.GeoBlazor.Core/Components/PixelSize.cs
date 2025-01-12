namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Raster pixel size.
/// </summary>
/// <param name="X">
///     Pixel size along the X axis.
/// </param>
/// <param name="Y">
///     Pixel size along the Y axis.
/// </param>
public partial class PixelSize: MapComponent
{
    /// <summary>
    ///     Pixel size along the X axis.
    /// </summary>
    public double X { get; set; }
    /// <summary>
    ///     Pixel size along the Y axis.
    /// </summary>
    public double Y { get; set; }
}