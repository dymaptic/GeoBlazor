using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible types of joins for a <see cref="JoinTableDataSource"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DynamicJoinType>))]
public enum DynamicJoinType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    LeftOuterJoin,
    LeftInnerJoin
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}