namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Image format of the cached tiles.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<TileInfoFormat>))]
public enum TileInfoFormat
{
#pragma warning disable CS1591
    Png,
    Png8,
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
    Lerc2d,
    Pbf,
    Raw
#pragma warning restore CS1591
}