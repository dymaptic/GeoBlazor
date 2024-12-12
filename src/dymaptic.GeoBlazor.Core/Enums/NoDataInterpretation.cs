using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The interpretation of no data values in the raster dataset.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<NoDataInterpretation>))]
public enum NoDataInterpretation
{
#pragma warning disable  CS1591
    Any,
    All
#pragma warning restore  CS1591
}