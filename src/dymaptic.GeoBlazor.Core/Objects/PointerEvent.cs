namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     This event type returns for all pointer events (down, up, enter, leave, move, etc.).
/// </summary>
/// <param name="Type">
///     The event type.
/// </param>
/// <param name="PointerId">
///     Uniquely identifies a pointer between multiple down, move, and up events. Ids might get reused after a pointer-up event.
/// </param>
/// <param name="PointerType">
///     Indicates the pointer type.
/// </param>
/// <param name="X">
///     The horizontal screen coordinate of the pointer on the view.
/// </param>
/// <param name="Y">
///     The vertical screen coordinate of the pointer on the view.
/// </param>
/// <param name="Button">
///     Indicates which mouse button was clicked.
/// </param>
/// <param name="Buttons">
///     Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.
/// </param>
/// <param name="Timestamp">
///     Time stamp (in milliseconds) at which the event was emitted.
/// </param>
/// <param name="Native">
///     A standard DOM Pointer Event
/// </param>
public record PointerEvent(string Type, long PointerId, PointerType PointerType, double X, double Y,
    bool Button, bool Buttons, long Timestamp, DomPointerEvent Native): JsEvent(Type);