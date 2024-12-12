using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Specify ASC (ascending) or DESC (descending) to control the order of the data. For example, in a data set of 10
///     values from 1 to 10, the percentile value for 0.9 with orderBy set to ascending (ASC) is 9, but when orderBy is set
///     to descending (DESC) the result is 2. The default is ASC.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<OrderBy>))]
public enum OrderBy
{
#pragma warning disable CS1591
    Asc,
    Desc
#pragma warning restore CS1591
}