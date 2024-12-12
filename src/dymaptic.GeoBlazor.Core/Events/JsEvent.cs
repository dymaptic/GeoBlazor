using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Base class for many events triggered in Javascript.
/// </summary>
/// <param name="Type">
///     The type of the event.
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
/// <param name="PointerType">
///     Indicates the pointer type. (optional)
/// </param>
public record JsEvent(string Type, int? EventId, bool? Cancelable, double Timestamp, DomPointerEvent Native,
    PointerType? PointerType);