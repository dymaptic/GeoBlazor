namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnThumbClick"/> event.
/// </summary>
/// <param name="Index">
///     The 0-based index of the thumb.
/// </param>
/// <param name="Value">
///     The value of the thumb when the event is emitted.
/// </param>
public record SliderThumbClickEvent(int Index, double Value);

