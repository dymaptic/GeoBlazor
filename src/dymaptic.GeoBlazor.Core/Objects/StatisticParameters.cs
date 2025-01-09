namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The parameters for percentile statistics. This property must be set when the statisticType is set to either
///     percentile-continuous or percentile-discrete.
/// </summary>
/// <param name="Value">
///     Percentile value. This should be a decimal value between 0 and 1.
/// </param>
public record StatisticParameters(double Value)
{
    /// <summary>
    ///     Specify ASC (ascending) or DESC (descending) to control the order of the data. For example, in a data set of 10
    ///     values from 1 to 10, the percentile value for 0.9 with orderBy set to ascending (ASC) is 9, but when orderBy is set
    ///     to descending (DESC) the result is 2. The default is ASC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OrderBy? OrderBy { get; init; }
}