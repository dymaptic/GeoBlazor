using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Location types for the <see cref="LocationService" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LocationType>))]
public enum LocationType
{
#pragma warning disable CS1591
    Street,
    Rooftop
#pragma warning restore CS1591
}