namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The possible states of the <see cref="SketchEvent"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SketchEventState>))]
public enum SketchEventState
{
#pragma warning disable CS1591
    Start,
    Active,
    Complete,
    Cancel
#pragma warning restore CS1591
}