namespace dymaptic.GeoBlazor.Core.Components;

public partial class RelatedRecordsInfoFieldOrder : MapComponent
{


    /// <summary>
    ///     The attribute value of the field selected that will drive the sorting of related records.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Field { get; set; }

    /// <summary>
    ///     Set the ascending or descending sort order of the returned related records.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OrderBy? Order { get; set; }

    internal RelatedRecordsInfoFieldOrderSerializationRecord ToSerializationRecord()
    {
        return new RelatedRecordsInfoFieldOrderSerializationRecord(Field, Order);
    }
}

internal record RelatedRecordsInfoFieldOrderSerializationRecord([property: ProtoMember(1)] string? Field, [property: ProtoMember(2)] OrderBy? Order)
{
    public RelatedRecordsInfoFieldOrder FromSerializationRecord()
    {
        return new(Field, Order);
    }
}