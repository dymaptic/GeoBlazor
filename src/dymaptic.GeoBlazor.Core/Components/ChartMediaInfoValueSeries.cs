namespace dymaptic.GeoBlazor.Core.Components;

public partial class ChartMediaInfoValueSeries : MapComponent
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
}

[ProtoContract(Name = "ChartMediaInfoValueSeries")]
internal record ChartMediaInfoValueSeriesSerializationRecord : MapComponentSerializationRecord
{
    public ChartMediaInfoValueSeriesSerializationRecord()
    {
    }

    public ChartMediaInfoValueSeriesSerializationRecord(string Id, string? FieldName, string? Tooltip, double? Value)
    {
        this.Id = Id;
        this.FieldName = FieldName;
        this.Tooltip = Tooltip;
        this.Value = Value;
    }

    public ChartMediaInfoValueSeries FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        return new ChartMediaInfoValueSeries(FieldName, Tooltip, Value) { Id = id };
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
    
    [ProtoMember(4)]
    public string? Id { get; init; }
}