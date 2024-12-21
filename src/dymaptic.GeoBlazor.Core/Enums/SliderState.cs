namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The state of the <see cref="SliderWidget"/>.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SliderState>))]
public enum SliderState
{
#pragma warning disable 1591
    Ready,
    Disabled,
    Editing,
    Dragging
#pragma warning restore 1591
}