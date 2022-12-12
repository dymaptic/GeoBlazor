using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Events;

public record HitTestResult(ViewHit[] Results, ScreenPoint ScreenPoint);

public record ViewHit(string Type, Point MapPoint);

public record GraphicHit(Graphic Graphic, Layer Layer, Point MapPoint) : ViewHit("graphic", MapPoint);

public record ScreenPoint(double X, double Y);