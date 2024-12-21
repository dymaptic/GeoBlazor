namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Fires after a keyboard key is released.
/// </summary>
/// <param name="Type">
///     The event type.
/// </param>
/// <param name="Key">
///     The key value that was pressed, according to the
///     <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values">
///         MDN
///         full list of key values
///     </a>
///     .
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
public record KeyUpEvent(string Type, int? EventId, bool? Cancelable, string Key, double Timestamp,
        DomPointerEvent Native, PointerType? PointerType)
    : JsEvent(Type, EventId, Cancelable, Timestamp, Native, PointerType);