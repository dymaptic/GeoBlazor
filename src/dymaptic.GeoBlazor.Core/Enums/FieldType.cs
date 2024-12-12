using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Potential types of Fields in a FeatureLayer
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FieldType>))]
public enum FieldType
{
#pragma warning disable CS1591
    SmallInteger,
    Integer,
    Single,
    Double,
    Long,
    String,
    Date,
    Oid,
    Geometry,
    Blob,
    Raster,
    Guid,
    GlobalId,
    Xml,
    BigInteger,
    DateOnly,
    TimeOnly,
    TimestampOffset
#pragma warning restore CS1591
}