namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The possible types of the <see cref="SketchEvent"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SketchEventType>))]
public enum SketchEventType
{
#pragma warning disable CS1591
    Create,
    Update,
    Undo,
    Redo,
    Delete
#pragma warning restore CS1591
}