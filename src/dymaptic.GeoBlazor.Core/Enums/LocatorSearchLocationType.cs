namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Defines the type of location, either street or rooftop, of the point returned from the World Geocoding Service.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LocatorSearchLocationType>))]
public enum LocatorSearchLocationType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Rooftop,
    Street
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}