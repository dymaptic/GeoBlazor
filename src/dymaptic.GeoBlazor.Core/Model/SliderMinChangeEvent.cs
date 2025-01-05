namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnMinChange"/> event.
/// </summary>
/// <param name = "OldValue">
///     The former min value (or bound) of the slider.
/// </param>
/// <param name = "Value">
///     The min value (or bound) of the slider when the event is emitted.
/// </param>
public record SliderMinChangeEvent(double OldValue, double Value);

