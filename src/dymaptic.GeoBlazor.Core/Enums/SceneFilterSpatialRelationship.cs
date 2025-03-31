namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The type of masking to perform.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SceneFilterSpatialRelationship>))]
public enum SceneFilterSpatialRelationship
{
#pragma warning disable CS1591
    Disjoint,
    Contains
#pragma warning restore CS1591
}