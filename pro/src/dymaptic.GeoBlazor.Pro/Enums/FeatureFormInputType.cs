namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The type of an <see cref="InputBase"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FeatureFormInputType>))]
public enum FeatureFormInputType
{
#pragma warning disable CS1591
    Field,
    Relationship,
    Group,
    TextElement,
    UtilityNetworkAssociation
#pragma warning restore CS1591
}