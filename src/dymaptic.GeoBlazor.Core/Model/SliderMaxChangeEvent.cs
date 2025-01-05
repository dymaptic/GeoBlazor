namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnMaxChange"/> event.
/// </summary>
/// <param name="OldValue">
///     The former max value (or bound) of the slider.
/// </param>
/// <param name="Value">
///     The max value (or bound) of the slider when the event is emitted.
/// </param>
public record SliderMaxChangeEvent(double OldValue, double Value);

