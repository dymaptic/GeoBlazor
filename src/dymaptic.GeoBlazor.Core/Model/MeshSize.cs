namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     An object containing individual values width, height and depth. The unit of the size values is derived from the spatial reference of the provided location, unless a specific unit is specified. The default unit for a GCS is always meters.
/// </summary>
/// <param name="Width">
///     The width of the created mesh.
/// </param>
/// <param name="Height">
///     The height of the created mesh.
/// </param>
/// <param name="Depth">
///     The depth of the created mesh.
/// </param>
public record MeshSize(double Width, double Height, double Depth);