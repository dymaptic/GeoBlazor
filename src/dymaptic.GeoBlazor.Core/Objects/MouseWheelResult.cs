namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Result of the view.on('mouse-wheel') event
/// </summary>
/// <param name="X">
///     The horizontal screen coordinate of the click on the view.
/// </param>
/// <param name="Y">
///     The vertical screen coordinate of the click on the view.
/// </param>
/// <param name="DeltaY">
///     Number representing the vertical scroll amount.
/// </param>
public record MouseWheelResult(double X, double Y, double DeltaY);