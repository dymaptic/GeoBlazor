namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnTrackClick"/> event.
/// </summary>
/// <param name = "Value">
///     The approximate value of the slider at the location of the click event.
/// </param>
public record SliderTrackClickEvent(double Value);