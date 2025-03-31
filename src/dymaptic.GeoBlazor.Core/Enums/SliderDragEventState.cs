namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Enumeration for the state of a slider drag event.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SliderDragEventState>))]
public enum SliderDragEventState
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Start,
    Drag
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}