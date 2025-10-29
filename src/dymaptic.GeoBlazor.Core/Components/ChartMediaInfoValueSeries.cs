namespace dymaptic.GeoBlazor.Core.Components;

public partial class ChartMediaInfoValueSeries : MapComponent, IProtobufSerializable
{
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
        return new ChartMediaInfoValueSeriesSerializationRecord(Id.ToString(), FieldName, Tooltip, Value);
    }
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
    }
}