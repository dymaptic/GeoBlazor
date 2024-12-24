﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

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
    [ActivatorUtilitiesConstructor]
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
    public FieldInfoFormat(int? places = null, bool? digitSeparator = null, string? dateFormat = null)
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
    public string? DateFormat { get; set; }

    internal FieldInfoFormatSerializationRecord ToSerializationRecord()
    {
        return new FieldInfoFormatSerializationRecord(Places, DigitSeparator, DateFormat);
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
        return new FieldInfoFormat(Places, DigitSeparator, DateFormat);
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