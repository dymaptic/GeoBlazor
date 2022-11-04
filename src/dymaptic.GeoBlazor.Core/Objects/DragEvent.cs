using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Result of the view.on('drag') event.
/// </summary>
/// <param name="Action">
///     The <see cref="DragAction"/> type of the event callback.
/// </param>
/// <param name="Origin">
///     The starting point of the drag event.
/// </param>
public record DragEvent(string Type, DragAction Action, double X, double Y, Point Origin, int Button, int Buttons, 
    double Radius, double Angle, long Timestamp, DomPointerEvent Native): JsEvent(Type);