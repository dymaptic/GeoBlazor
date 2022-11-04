using dymaptic.GeoBlazor.Core.Components.Views;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Fires when browser focus is moved away from the view.
/// </summary>
/// <param name="Target">
///     The view that the browser focus is currently on.
/// </param>
/// <param name="Native">
///     A standard DOM Pointer Event
/// </param>
public record BlurEvent(MapView Target, DomPointerEvent Native);