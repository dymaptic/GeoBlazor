using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The mode of the <see cref="SliderTickConfig"/>.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TickConfigMode>))]
public enum TickConfigMode
{
    /// <summary>
    ///     Places a fixed number of ticks (provided in the values property) at equal distances from each other below the slider track.
    /// </summary>
    Count,
    /// <summary>
    ///     When set, and a single number is set on the values property, ticks will be placed at the specified percentage interval along the length of the slider. For example, when mode is percent and values is 5, then 20 ticks will be placed below the slider track (at 5-percent intervals from each other). If an array of values is provided, the values are interpreted as percentages along the slider. So if values is [10, 50, 90], then three ticks will be placed below the track; one at the midway point, and two 10 percent of the length from either end of the slider.
    /// </summary>
    Percent,
    /// <summary>
    ///     Indicates that ticks will only be placed at the values specified in the values property.
    /// </summary>
    Position
}