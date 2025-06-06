// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Events.SliderSegmentClickEvent.html">GeoBlazor Docs</a>
///     Event result type for the SliderWidget.OnSegmentClick event.
/// </summary>
/// <param name="Index">
/// </param>
/// <param name="ThumbIndices">
/// </param>
/// <param name="Value">
/// </param>
public partial record SliderSegmentClickEvent(
    int Index,
    IReadOnlyCollection<double> ThumbIndices,
    double Value);
