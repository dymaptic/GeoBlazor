namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
/// The format of the data sent by the server.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ImageFormat>))]
public enum ImageFormat
{
#pragma warning disable CS1591
    Png,
    Png8,
    Png24,
    Png32,
    Jpg,
    Bmp,
    Gif,
    Jpgpng,
    Lerc,
    Tiff,
    Bip,
    Bsq
#pragma warning restore CS1591
}

