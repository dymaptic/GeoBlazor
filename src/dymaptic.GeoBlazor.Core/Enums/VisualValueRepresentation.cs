using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Specifies how to apply the data value when mapping real-world sizes.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VisualValueRepresentation>))]
public enum VisualValueRepresentation
{
#pragma warning disable CS1591
    Radius,
    Diameter,
    Area,
    Width,
    Distance
#pragma warning restore CS1591
}