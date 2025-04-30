namespace dymaptic.GeoBlazor.Core.Components;

public partial class ChartMediaInfoValue : MapComponent
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


    internal ChartMediaInfoValueSerializationRecord ToSerializationRecord()
    {
        return new ChartMediaInfoValueSerializationRecord(Id.ToString(), Fields, NormalizeField, TooltipField, 
            Series?.Select(s => s.ToSerializationRecord()));
    }
}

[ProtoContract(Name = "ChartMediaInfoValue")]
internal record ChartMediaInfoValueSerializationRecord : MapComponentSerializationRecord
{
    public ChartMediaInfoValueSerializationRecord()
    {
    }

    public ChartMediaInfoValueSerializationRecord(string Id, IEnumerable<string>? Fields = null, 
        string? NormalizeField = null, string? TooltipField = null, 
        IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series = null, string? LinkURL = null, 
        string? SourceURL = null)
    {
        this.Fields = Fields;
        this.NormalizeField = NormalizeField;
        this.TooltipField = TooltipField;
        this.Series = Series;
        this.LinkURL = LinkURL;
        this.SourceURL = SourceURL;
    }

    public object FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        
        if (LinkURL is not null || SourceURL is not null)
        {
            return new ImageMediaInfoValue(LinkURL, SourceURL) { Id = id };
        }

        return new ChartMediaInfoValue(Fields?.ToArray(), NormalizeField, TooltipField, 
            Series?.Select(s => s.FromSerializationRecord()).ToArray())
        {
            Id = id
        };
    }

    [ProtoMember(1)]
    public IEnumerable<string>? Fields { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? NormalizeField { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? TooltipField { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public string? LinkURL { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public string? SourceURL { get; init; }
    
    [ProtoMember(7)]
    public string? Id { get; init; }
}