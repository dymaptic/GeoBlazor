using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Geometry coordinates are optimized for viewing and displaying of data.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<QuantizationMode>))]
public enum QuantizationMode
{
#pragma warning disable CS1591
    View,
    Edit
#pragma warning restore CS1591
}