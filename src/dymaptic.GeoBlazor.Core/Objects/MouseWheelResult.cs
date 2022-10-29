namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Result of the view.on('mouse-wheel') event
/// </summary>
public record MouseWheelResult(double X, double Y, double DeltaY);