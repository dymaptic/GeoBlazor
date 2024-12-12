using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible unit values for the <see cref="ScaleBarWidget" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ScaleUnit>))]
public enum ScaleUnit
{
#pragma warning disable CS1591
    [Obsolete("Use Imperial Instead")]
    NonMetric,
    Metric,
    Dual,
    Imperial
#pragma warning restore CS1591
}