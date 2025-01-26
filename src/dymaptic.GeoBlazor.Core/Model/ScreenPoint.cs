namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The screen coordinates (or native mouse event) of the click on the view.
/// </summary>
/// <param name = "X">
///     The X coordinate.
/// </param>
/// <param name = "Y">
///     The Y coordinate.
/// </param>
public record ScreenPoint(double X, double Y);
