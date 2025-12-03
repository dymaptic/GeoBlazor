namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The Types of FeatureReferenceIds
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FeatureReferenceIdType>))]
public enum FeatureReferenceIdType
{
#pragma warning disable CS1591
    GlobalId,
    ObjectId
#pragma warning restore CS1591
}