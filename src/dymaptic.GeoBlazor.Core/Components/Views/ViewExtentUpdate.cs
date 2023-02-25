using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Components.Views;

/// <summary>
///     A class to represent all the parameters that make up the extent of the map view.
/// </summary>
/// <param name="Extent">
///     The <see cref="Extent" /> of the view.
/// </param>
/// <param name="Center">
///     The <see cref="Point" /> that represents the center of the view.
/// </param>
/// <param name="Scale">
///     The scale of the view.
/// </param>
/// <param name="Zoom">
///     The zoom level of the view.
/// </param>
/// <param name="Rotation">
///     The rotation of the view.
/// </param>
/// <param name="Tilt">
///     The tilt of the 3d view camera.
/// </param>
public record ViewExtentUpdate(Extent Extent, Point? Center, double Scale, double Zoom,
    double? Rotation = null, double? Tilt = null);