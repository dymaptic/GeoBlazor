using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The state of the drag in a <see cref="SliderThumbDragEvent"/>.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SliderThumbDragState>))]
public enum SliderThumbDragState
{
#pragma warning disable 1591
    Drag,
    Start,
    Stop
#pragma warning restore 1591
}