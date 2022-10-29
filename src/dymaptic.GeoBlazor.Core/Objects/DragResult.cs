using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Result of the view.on('drag') event
/// </summary>
public record DragResult(DragAction Action, Point OriginPoint, Point CurrentPoint);