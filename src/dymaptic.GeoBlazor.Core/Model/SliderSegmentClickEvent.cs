namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Event arguments for the <see cref = "SliderWidget.OnSegmentClick"/> event.
/// </summary>
/// <param name = "Index">
///     The 1-based index of the segment on the slider.
/// </param>
/// <param name = "ThumbIndices">
///     The indices of the thumbs on each end of the segment.
/// </param>
/// <param name = "Value">
///     The approximate value of the slider at the location of the click event.
/// </param>
public record SliderSegmentClickEvent(int Index, int[] ThumbIndices, double Value);

