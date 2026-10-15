namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The state of the SketchWidget.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SketchWidgetState>))]
public enum SketchWidgetState
{
#pragma warning disable CS1591
    Ready,
    Disabled,
    Active
#pragma warning restore CS1591
}