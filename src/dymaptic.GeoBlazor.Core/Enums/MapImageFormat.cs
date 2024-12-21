namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The output image type of the MapImageLayer.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<MapImageFormat>))]
public enum MapImageFormat
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Png,
    Png8,
    Png24,
    Png32,
    Jpg,
    Pdf,
    Bmp,
    Gif,
    Svg,
    Pngjpg
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}