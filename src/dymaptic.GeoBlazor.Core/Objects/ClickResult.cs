using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Objects;

public record ClickResult(Point MapPoint, Point ScreenPoint, string PointerType, int Button, int Buttons,
    double X, double Y, double Timestamp, int EventId, bool Cancelable);