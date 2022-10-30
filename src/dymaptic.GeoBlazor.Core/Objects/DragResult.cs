using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Result of the view.on('drag') event.
/// </summary>
/// <param name="Action">
///     The <see cref="DragAction"/> type of the event callback.
/// </param>
/// <param name="OriginPoint">
///     The starting point of the drag event.
/// </param>
/// <param name="CurrentPoint>
///     The current point of the drag event.
/// </param>
public record DragResult(DragAction Action, Point OriginPoint, Point CurrentPoint);