using dymaptic.GeoBlazor.Core.Components.Views;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Fires when browser focus is on the view.
/// </summary>
/// <param name="Target">
///     The view that the browser focus is currently on.
/// </param>
/// <param name="Timestamp">
///     Time stamp (in milliseconds) at which the event was emitted.
/// </param>
/// <param name="Native">
///     A standard DOM Pointer Event
/// </param>
/// <param name="Cancelable">
///     Whether the event can be cancelled once begun.
/// </param>
/// <param name="Type">
///     The event type.
/// </param>
public record FocusEvent(MapView Target, DomPointerEvent Native, string Type, double Timestamp, bool? Cancelable)
    :JsEvent(Type, null, Cancelable, Timestamp, Native, null);