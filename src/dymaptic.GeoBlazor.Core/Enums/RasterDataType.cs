using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible data types for Rasters
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RasterDataType>))]
public enum RasterDataType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Generic,
    Elevation,
    Thematic,
    Processed,
    Scientific,
    VectorUv,
    VectorU,
    VectorV,
    VectorMagdir,
    VectorMagnitude,
    VectorDirection,
    StandardTime
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}