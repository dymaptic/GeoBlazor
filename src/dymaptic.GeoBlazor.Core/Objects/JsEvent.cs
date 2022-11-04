namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Base class for many events triggered in Javascript.
/// </summary>
/// <param name="Type">
///     The type of the event.
/// </param>
public record JsEvent(string Type);