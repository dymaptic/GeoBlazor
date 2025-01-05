namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnThumbChange"/> event.
/// </summary>
/// <param name = "Index">
///     The 0-based index of the updated thumb.
/// </param>
/// <param name = "OldValue">
///     The former value of the thumb before the change was made.
/// </param>
/// <param name = "Value">
///     The value of the thumb when the event is emitted.
/// </param>
public record SliderThumbChangeEvent(int Index, double OldValue, double Value);

