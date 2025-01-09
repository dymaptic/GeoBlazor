namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Defines the type of statistic.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StatisticType>))]
public enum StatisticType
{
#pragma warning disable CS1591
    Count,
    Sum,
    Min,
    Max,
    Avg,
    Stddev,
    Var,
    PercentileContinuous,
    PercentileDiscrete,
    EnvelopeAggregate,
    CentroidAggregate,
    ConvexHullAggregate
#pragma warning restore CS1591
}