using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Defines how to interpolate pixel values.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PixelInterpolation>))]
public enum PixelInterpolation
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Nearest,
    Bilinear,
    Cubic,
    Majority
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}