namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnSegmentDrag"/> event.
/// </summary>
/// <param name="Index">
///     The 1-based index of the segment on the slider.
/// </param>
/// <param name="State">
///     The state of the drag.
/// </param>
/// <param name="ThumbIndices">
///     The indices of the thumbs on each end of the segment.
/// </param>
public record SliderSegmentDragEvent(int Index, SliderDragState State, int[] ThumbIndices);

