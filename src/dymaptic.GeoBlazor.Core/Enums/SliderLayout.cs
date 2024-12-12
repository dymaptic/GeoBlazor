using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible layouts of the <see cref="SliderWidget"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SliderLayout>))]
public enum SliderLayout
{
#pragma warning disable 1591
    Horizontal,
    HorizontalReversed,
    Vertical,
    VerticalReversed
#pragma warning restore 1591
}