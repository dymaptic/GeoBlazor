namespace dymaptic.GeoBlazor.Core.Components;

public partial class FieldInfoFormat : MapComponent
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
}

[ProtoContract(Name = "FieldInfoFormat")]
internal record FieldInfoFormatSerializationRecord : MapComponentSerializationRecord
{
    public FieldInfoFormatSerializationRecord()
    {
    }
    
    public FieldInfoFormatSerializationRecord(string Id,
        int? Places,
        bool? DigitSeparator,
        string? DateFormat)
    {
        this.Id = Id;
        this.Places = Places;
        this.DigitSeparator = DigitSeparator;
        this.DateFormat = DateFormat;
    }

    public FieldInfoFormat FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guidId))
        {
            id = guidId;
        }
        DateFormat? df = DateFormat switch
        {
            "short-date" => Enums.DateFormat.ShortDate,
            "short-date-short-time.cs" => Enums.DateFormat.ShortDateShortTime,
            "short-date-short-time-24" => Enums.DateFormat.ShortDateShortTime24,
            "short-date-long-time" => Enums.DateFormat.ShortDateLongTime,
            "short-date-long-time-24" => Enums.DateFormat.ShortDateLongTime24,
            "short-date-le" => Enums.DateFormat.ShortDateLe,
            "short-date-le-short-time" => Enums.DateFormat.ShortDateLeShortTime,
            "short-date-le-short-time-24" => Enums.DateFormat.ShortDateLeShortTime24,
            "short-date-le-long-time" => Enums.DateFormat.ShortDateLeLongTime,
            "short-date-le-long-time-24" => Enums.DateFormat.ShortDateLeLongTime24,
            "long-month-day-year" => Enums.DateFormat.LongMonthDayYear,
            "long-month-day-year-short-time" => Enums.DateFormat.LongMonthDayYearShortTime,
            "long-month-day-year-short-time-24" => Enums.DateFormat.LongMonthDayYearShortTime24,
            "long-month-day-year-long-time" => Enums.DateFormat.LongMonthDayYearLongTime,
            "long-month-day-year-long-time-24" => Enums.DateFormat.LongMonthDayYearLongTime24,
            "day-short-month-year" => Enums.DateFormat.DayShortMonthYear,
            "day-short-month-year-short-time" => Enums.DateFormat.DayShortMonthYearShortTime,
            "day-short-month-year-short-time-24" => Enums.DateFormat.DayShortMonthYearShortTime24,
            "day-short-month-year-long-time" => Enums.DateFormat.DayShortMonthYearLongTime,
            "day-short-month-year-long-time-24" => Enums.DateFormat.DayShortMonthYearLongTime24,
            "long-date" => Enums.DateFormat.LongDate,
            "long-date-short-time" => Enums.DateFormat.LongDateShortTime,
            "long-date-short-time-24" => Enums.DateFormat.LongDateShortTime24,
            "long-date-long-time" => Enums.DateFormat.LongDateLongTime,
            "long-date-long-time-24" => Enums.DateFormat.LongDateLongTime24,
            "long-month-year" => Enums.DateFormat.LongMonthYear,
            "short-month-year" => Enums.DateFormat.ShortMonthYear,
            "year" => Enums.DateFormat.Year,
            _ => null
        };
        return new FieldInfoFormat(Places, DigitSeparator, df) { Id = id };
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public int? Places { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public bool? DigitSeparator { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? DateFormat { get; init; }
    
    [ProtoMember(4)]
    public string? Id { get; init; }
}