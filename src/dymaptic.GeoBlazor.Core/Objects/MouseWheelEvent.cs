namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Fires when a wheel button of a pointing device (typically a mouse) is scrolled on the view.
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
/// <param name="Timestamp">
///     Time stamp (in milliseconds) at which the event was emitted.
/// </param>
/// <param name="Native">
///     A standard DOM Pointer Event
/// </param>
public record MouseWheelEvent(string Type, double X, double Y, double DeltaY, long Timestamp, DomPointerEvent Native)
    : JsEvent(Type);