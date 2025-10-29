namespace dymaptic.GeoBlazor.Core.Components;

public partial class FieldInfoFormat : MapComponent, IProtobufSerializable
{


    /// <summary>
    ///     Used only with Number fields to specify the number of supported decimal places that should appear in popups.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Places { get; set; }

    /// <summary>
    ///     Used only with Number fields.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DigitSeparator { get; set; }

    /// <summary>
    ///     Used only with Date fields.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateFormat? DateFormat { get; set; }

    internal FieldInfoFormatSerializationRecord ToSerializationRecord()
    {
        string? dateFormat = DateFormat switch
        {
            Enums.DateFormat.ShortDate => "short-date",
            Enums.DateFormat.ShortDateShortTime => "short-date-short-time",
            Enums.DateFormat.ShortDateShortTime24 => "short-date-short-time-24",
            Enums.DateFormat.ShortDateLongTime => "short-date-long-time",
            Enums.DateFormat.ShortDateLongTime24 => "short-date-long-time-24",
            Enums.DateFormat.ShortDateLe => "short-date-le",
            Enums.DateFormat.ShortDateLeShortTime => "short-date-le-short-time",
            Enums.DateFormat.ShortDateLeShortTime24 => "short-date-le-short-time-24",
            Enums.DateFormat.ShortDateLeLongTime => "short-date-le-long-time",
            Enums.DateFormat.ShortDateLeLongTime24 => "short-date-le-long-time-24",
            Enums.DateFormat.LongMonthDayYear => "long-month-day-year",
            Enums.DateFormat.LongMonthDayYearShortTime => "long-month-day-year-short-time",
            Enums.DateFormat.LongMonthDayYearShortTime24 => "long-month-day-year-short-time-24",
            Enums.DateFormat.LongMonthDayYearLongTime => "long-month-day-year-long-time",
            Enums.DateFormat.LongMonthDayYearLongTime24 => "long-month-day-year-long-time-24",
            Enums.DateFormat.DayShortMonthYear => "day-short-month-year",
            Enums.DateFormat.DayShortMonthYearShortTime => "day-short-month-year-short-time",
            Enums.DateFormat.DayShortMonthYearShortTime24 => "day-short-month-year-short-time-24",
            Enums.DateFormat.DayShortMonthYearLongTime => "day-short-month-year-long-time",
            Enums.DateFormat.DayShortMonthYearLongTime24 => "day-short-month-year-long-time-24",
            Enums.DateFormat.LongDate => "long-date",
            Enums.DateFormat.LongDateShortTime => "long-date-short-time",
            Enums.DateFormat.LongDateShortTime24 => "long-date-short-time-24",
            Enums.DateFormat.LongDateLongTime => "long-date-long-time",
            Enums.DateFormat.LongDateLongTime24 => "long-date-long-time-24",
            Enums.DateFormat.LongMonthYear => "long-month-year",
            Enums.DateFormat.ShortMonthYear => "short-month-year",
            Enums.DateFormat.Year => "year",
            _ => null
        };
        return new FieldInfoFormatSerializationRecord(Id.ToString(), Places, DigitSeparator, dateFormat);
    }
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
    }
}