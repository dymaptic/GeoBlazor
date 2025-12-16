namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ChartMediaInfoValueSeries : MapComponent, 
    IProtobufSerializable<ChartMediaInfoValueSeriesSerializationRecord>
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
    
    /// <inheritdoc />
    public ChartMediaInfoValueSeriesSerializationRecord ToProtobuf()
    {
        return new ChartMediaInfoValueSeriesSerializationRecord(Id.ToString(), FieldName, Tooltip, Value);
    }
}