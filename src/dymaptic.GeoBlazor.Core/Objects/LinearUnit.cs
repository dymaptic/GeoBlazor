using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     A collection of units for measuring Linear distances.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LinearUnit>))]
public enum LinearUnit
{
#pragma warning disable CS1591
    Meters,
    Feet,
    Kilometers,
    Miles,
    NauticalMiles,
    Yards
#pragma warning restore CS1591
}