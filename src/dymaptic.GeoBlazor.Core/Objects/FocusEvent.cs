using dymaptic.GeoBlazor.Core.Components.Views;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Fires when browser focus is on the view.
/// </summary>
/// <param name="Target">
///     The view that the browser focus is currently on.
/// </param>
/// <param name="Native">
///     A standard DOM Pointer Event
/// </param>
public record FocusEvent(MapView Target, DomPointerEvent Native);