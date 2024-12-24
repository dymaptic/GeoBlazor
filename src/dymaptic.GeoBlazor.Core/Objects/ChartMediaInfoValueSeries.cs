namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The ChartMediaInfoValueSeries class is a read-only support class that represents information specific to how data
///     should be plotted in a chart. It helps provide a consistent API for plotting charts used by the Popup widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ChartMediaInfoValueSeries : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ChartMediaInfoValueSeries()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="ChartMediaInfoValueSeries" /> in code.
    /// </summary>
    /// <param name="fieldName">
    ///     String value indicating the field's name for a series.
    /// </param>
    /// <param name="tooltip">
    ///     String value indicating the tooltip for a series.
    /// </param>
    /// <param name="value">
    ///     Numerical value for the chart series.
    /// </param>
    public ChartMediaInfoValueSeries(string? fieldName = null, string? tooltip = null,
        double? value = null)
    {
#pragma warning disable BL0005
        FieldName = fieldName;
        Tooltip = tooltip;
        Value = value;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     String value indicating the field's name for a series.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FieldName { get; set; }

    /// <summary>
    ///     String value indicating the tooltip for a series.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Tooltip { get; set; }

    /// <summary>
    ///     Numerical value for the chart series.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }

    internal ChartMediaInfoValueSeriesSerializationRecord ToSerializationRecord()
    {
        return new ChartMediaInfoValueSeriesSerializationRecord(FieldName, Tooltip, Value);
    }
}

[ProtoContract(Name = "ChartMediaInfoValueSeries")]
internal record ChartMediaInfoValueSeriesSerializationRecord : MapComponentSerializationRecord
{
    public ChartMediaInfoValueSeriesSerializationRecord()
    {
    }
    
    public ChartMediaInfoValueSeriesSerializationRecord(string? FieldName,
        string? Tooltip,
        double? Value)
    {
        this.FieldName = FieldName;
        this.Tooltip = Tooltip;
        this.Value = Value;
    }

    public ChartMediaInfoValueSeries FromSerializationRecord()
    {
        return new ChartMediaInfoValueSeries(FieldName, Tooltip, Value);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? FieldName { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Tooltip { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public double? Value { get; init; }
}