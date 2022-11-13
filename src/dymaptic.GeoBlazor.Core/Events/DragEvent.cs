using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Result of the view.on('drag') event.
/// </summary>
/// <param name="Action">
///     The <see cref="DragAction"/> type of the event callback.
/// </param>
/// <param name="Origin">
///     The starting point of the drag event.
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
/// <param name="Radius">
///     The radius of the drag.
/// </param>
/// <param name="Angle">
///     The angle of the drag.
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
///     The event type.
/// </param>
public record DragEvent(string Type, int? EventId, bool? Cancelable, DragAction Action, double X, double Y, 
    Point Origin, int Button, int Buttons, double Radius, double Angle, double Timestamp, DomPointerEvent Native,
    PointerType? PointerType)
    : JsEvent(Type, EventId, Cancelable, Timestamp, Native, PointerType);