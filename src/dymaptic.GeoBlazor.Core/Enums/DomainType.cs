namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Types of <see cref="Domain" />s.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DomainType>))]
public enum DomainType
{
#pragma warning disable CS1591
    Inherited,
    CodedValue,
    Range
}