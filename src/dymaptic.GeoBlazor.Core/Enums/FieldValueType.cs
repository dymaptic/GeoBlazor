using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The types of values that can be assigned to a field.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FieldValueType>))]
public enum FieldValueType
{
#pragma warning disable CS1591
    Binary,
    Coordinate,
    CountOrAmount,
    DateAndTime,
    Description,
    LocationOrPlaceName,
    Measurement,
    NameOrTitle,
    None,
    OrderedOrRanked,
    PercentageOrRatio,
    TypeOrCategory,
    UniqueIdentifier
#pragma warning restore CS1591
}