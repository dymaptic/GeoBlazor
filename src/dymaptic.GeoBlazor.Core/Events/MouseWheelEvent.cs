using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Events;

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
/// <param name="PointerType">
///     Indicates the pointer type.
/// </param>
/// <param name="Cancelable">
///     Whether the event can be cancelled once begun.
/// </param>
/// <param name="EventId">
///     The unique Id of the event.
/// </param>
/// <param name="Type">
///     Indicates the type of the event.
/// </param>
public record MouseWheelEvent(string Type, int? EventId, bool? Cancelable, double X, double Y, double DeltaY,
        double Timestamp, DomPointerEvent Native, PointerType? PointerType)
    : JsEvent(Type, EventId, Cancelable, Timestamp, Native, PointerType);