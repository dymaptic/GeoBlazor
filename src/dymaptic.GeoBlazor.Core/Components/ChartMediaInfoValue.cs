namespace dymaptic.GeoBlazor.Core.Components;

public partial class ChartMediaInfoValue : MapComponent, IProtobufSerializable<ChartMediaInfoValueSerializationRecord>
{
    /// <summary>
    ///     A string containing the name of a field. The values of all fields in the chart will be normalized (divided) by the value of this field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NormalizeField { get; set; }

    /// <summary>
    ///     String value indicating the tooltip for a chart specified from another field. It is used for showing tooltips from another field in the same layer or related layer/table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TooltipField { get; set; }
    
    public ChartMediaInfoValueSerializationRecord ToProtobuf()
    {
        return new ChartMediaInfoValueSerializationRecord(Id.ToString(), Fields, NormalizeField, TooltipField, 
            Series?.Select(s => s.ToProtobuf()));
    }
}