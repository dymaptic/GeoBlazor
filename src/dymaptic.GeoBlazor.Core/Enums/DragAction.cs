using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     JavaScript Drag actions
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DragAction>))]
public enum DragAction
{
#pragma warning disable CS1591
    Start,
    Added,
    Update,
    Removed,
    End
#pragma warning restore CS1591
}