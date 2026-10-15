namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     Options for the directional layout of the <see cref="SketchWidget"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SketchWidgetLayout>))]
public enum SketchWidgetLayout
{
#pragma warning disable CS1591
    Vertical,
    Horizontal
#pragma warning restore CS1591
}