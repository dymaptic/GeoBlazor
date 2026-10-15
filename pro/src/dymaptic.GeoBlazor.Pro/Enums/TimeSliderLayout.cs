namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
/// Determines the layout used by the TimeSlider widget.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TimeSliderLayout>))]
public enum TimeSliderLayout
{
#pragma warning disable CS1591
    Auto,
    Compact,
    Wide
#pragma warning restore CS1591
}