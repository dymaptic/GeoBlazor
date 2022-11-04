namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Fires after a keyboard key is released.
/// </summary>
/// <param name="Type">
///     The event type.
/// </param>
/// <param name="Key">
///     The key value that was pressed, according to the <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values">MDN full list of key values</a>.
/// </param>
/// <param name="Timestamp">
///     Time stamp (in milliseconds) at which the event was emitted.
/// </param>
/// <param name="Native">
///     A standard DOM Pointer Event
/// </param>
public record KeyUpEvent(string Type, string Key, long Timestamp, DomPointerEvent Native) : JsEvent(Type);