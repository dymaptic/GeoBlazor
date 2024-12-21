﻿namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     The FieldInfoFormat class is used with numerical or date fields to provide more detail about how the value should
///     be displayed in a popup. Use this class in place of the legacy formatting functions: DateString, DateFormat, and/or
///     NumberFormat.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-support-FieldInfoFormat.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FieldInfoFormat : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public FieldInfoFormat()
    {
    }

    /// <summary>
    ///     Constructor for creating a new FieldInfoFormat in code with parameters
    /// </summary>
    /// <param name="places">
    ///     Used only with Number fields to specify the number of supported decimal places that should appear in popups.
    /// </param>
    /// <param name="digitSeparator">
    ///     Used only with Number fields.
    /// </param>
    /// <param name="dateFormat">
    ///     Used only with Date fields.
    /// </param>
    public FieldInfoFormat(int? places = null, bool? digitSeparator = null, DateFormat? dateFormat = null)
    {
#pragma warning disable BL0005
        Places = places;
        DigitSeparator = digitSeparator;
        DateFormat = dateFormat;
#pragma warning restore BL0005
    }

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
        return new FieldInfoFormatSerializationRecord(Places, DigitSeparator, DateFormat?.ToString().ToKebabCase());
    }
}

[ProtoContract(Name = "FieldInfoFormat")]
internal record FieldInfoFormatSerializationRecord : MapComponentSerializationRecord
{
    public FieldInfoFormatSerializationRecord()
    {
    }
    
    public FieldInfoFormatSerializationRecord(int? Places,
        bool? DigitSeparator,
        string? DateFormat)
    {
        this.Places = Places;
        this.DigitSeparator = DigitSeparator;
        this.DateFormat = DateFormat;
    }

    public FieldInfoFormat FromSerializationRecord()
    {
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
        return new FieldInfoFormat(Places, DigitSeparator, df);
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
}