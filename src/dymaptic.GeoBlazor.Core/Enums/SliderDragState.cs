using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The state of the drag in a <see cref="SliderSegmentDragEvent"/>.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SliderDragState>))]
public enum SliderDragState
{
#pragma warning disable 1591
    Start,
    Drag
#pragma warning restore 1591
}