namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnThumbDrag"/> event.
/// </summary>
/// <param name="Index">
///     The 0-based index of the updated thumb.
/// </param>
/// <param name="State">
///     The state of the drag.
/// </param>
/// <param name="Value">
///     The value of the thumb when the event is emitted.
/// </param>
public record SliderThumbDragEvent(int Index, SliderThumbDragState State, double Value);

