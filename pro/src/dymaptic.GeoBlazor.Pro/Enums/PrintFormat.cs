namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The output format for a printed map.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PrintFormat>))]
public enum PrintFormat
{
#pragma warning disable CS1591
    Jpg,
    Png8,
    Png32,
    Pdf,
    Gif,
    Tiff,
    Aix,
    Eps,
    Svg,
    Svgz,
    All
#pragma warning restore CS1591
}