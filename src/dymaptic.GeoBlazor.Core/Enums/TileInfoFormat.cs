namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Image format of the cached tiles.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TileInfoFormat>))]
public enum TileInfoFormat
{
#pragma warning disable CS1591
    Png,
    Png24,
    Png32,
    Jpg,
    Dib,
    Tiff,
    Emf,
    Ps,
    Pdf,
    Gif,
    Svg,
    Svgz,
    Mixed,
    Lerc,
    Pbf
#pragma warning restore CS1591
}