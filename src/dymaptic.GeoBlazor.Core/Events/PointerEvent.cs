namespace dymaptic.GeoBlazor.Core.Events;

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
/// <param name="Cancelable">
///     Whether the event can be cancelled once begun.
/// </param>
/// <param name="EventId">
///     The unique Id of the event.
/// </param>
public record PointerEvent(string Type, int? EventId, bool? Cancelable, long PointerId, PointerType? PointerType,
        double X, double Y, int Button, int Buttons, double Timestamp, DomPointerEvent Native)
    : JsEvent(Type, EventId, Cancelable, Timestamp, Native, PointerType);