using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Event object for all click (single, double, immediate) and hold events.
/// </summary>
/// <param name="Type">
///     The event type.
/// </param>
/// <param name="MapPoint">
///     The point location of the click on the view in the spatial reference of the map.
/// </param>
/// <param name="X">
///     The horizontal screen coordinate of the click on the view.
/// </param>
/// <param name="Y">
///     The vertical screen coordinate of the click on the view.
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
/// <param name="PointerType">
///     Indicates the pointer type.
/// </param>
/// <param name="Cancelable">
///     Whether the event can be cancelled once begun.
/// </param>
/// <param name="EventId">
///     The unique Id of the event.
/// </param>
public record ClickEvent(string Type, int? EventId, bool? Cancelable, Point MapPoint, double X, double Y, int Button,
        int Buttons, double Timestamp, DomPointerEvent Native, PointerType? PointerType)
    : JsEvent(Type, EventId, Cancelable, Timestamp, Native, PointerType);
