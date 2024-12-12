using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The algorithms used to generate the colors between the fromColor and toColor. Each algorithm uses different methods for generating the intervening colors.
///     Read more in the link above.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<Algorithm>))]
public enum Algorithm
{
#pragma warning disable CS1591
    CieLab,
    LabLch,
    Hsv
#pragma warning restore CS1591
}