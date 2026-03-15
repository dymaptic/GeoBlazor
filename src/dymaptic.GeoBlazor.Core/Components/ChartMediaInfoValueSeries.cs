namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ChartMediaInfoValueSeries : MapComponent,
    IProtobufSerializable<ChartMediaInfoValueSeriesSerializationRecord>
{
    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    [CodeGenerationIgnore]
    public ChartMediaInfoValueSeries(string? fieldName = null, string? tooltip = null, double? value = null)
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
    
    /// <inheritdoc />
    public ChartMediaInfoValueSeriesSerializationRecord ToProtobuf()
    {
        return new ChartMediaInfoValueSeriesSerializationRecord(Id.ToString(), FieldName, Tooltip, Value);
    }
}