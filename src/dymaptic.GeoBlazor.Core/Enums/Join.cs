namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Join enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<Join>))]
public enum Join
{
#pragma warning disable CS1591
    Miter,
    Round,
    Bevel
#pragma warning restore CS1591
}