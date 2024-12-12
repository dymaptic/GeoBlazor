using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Specifies how to apply the data value when mapping real-world sizes.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VisualValueUnit>))]
public enum VisualValueUnit
{
#pragma warning disable CS1591
    Unknown,
    Inches,
    Feet,
    Yards,
    Miles,
    NauticalMiles,
    Millimeters,
    Centimeters,
    Decimeters,
    Meters,
    Kilometers,
    DecimalDegrees
#pragma warning restore CS1591
}