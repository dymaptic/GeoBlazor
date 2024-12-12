using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     DateFormat enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DateFormat>))]
public enum DateFormat
{
#pragma warning disable CS1591
    ShortDate,
    ShortDateShortTime,
    ShortDateShortTime24,
    ShortDateLongTime,
    ShortDateLongTime24,
    ShortDateLe,
    ShortDateLeShortTime,
    ShortDateLeShortTime24,
    ShortDateLeLongTime,
    ShortDateLeLongTime24,
    LongMonthDayYear,
    LongMonthDayYearShortTime,
    LongMonthDayYearShortTime24,
    LongMonthDayYearLongTime,
    LongMonthDayYearLongTime24,
    DayShortMonthYear,
    DayShortMonthYearShortTime,
    DayShortMonthYearShortTime24,
    DayShortMonthYearLongTime,
    DayShortMonthYearLongTime24,
    LongDate,
    LongDateShortTime,
    LongDateShortTime24,
    LongDateLongTime,
    LongDateLongTime24,
    LongMonthYear,
    ShortMonthYear,
    Year
#pragma warning restore CS1591
}
