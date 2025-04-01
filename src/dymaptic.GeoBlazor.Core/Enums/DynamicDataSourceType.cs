namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible types of <see cref="DynamicDataSource"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DynamicDataSourceType>))]
public enum DynamicDataSourceType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    JoinTable,
    QueryTable,
    Raster,
    Table
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}