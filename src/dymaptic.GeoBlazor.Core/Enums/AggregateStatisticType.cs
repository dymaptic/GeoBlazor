namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Defines the type of statistic used to aggregate data returned from <see cref="AggregateField.OnStatisticField" />
///     or <see cref="AggregateField.OnStatisticExpression" />.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AggregateStatisticType>))]
public enum AggregateStatisticType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Avg,
    Count,
    Max,
    Min,
    Mode,
    Sum
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}