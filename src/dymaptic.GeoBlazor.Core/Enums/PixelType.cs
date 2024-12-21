namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Types of pixels for raster data sources
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PixelType>))]
public enum PixelType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Unknown,
    S8,
    S16,
    S32,
    U8,
    U16,
    U32,
    F32,
    F64
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}