namespace dymaptic.GeoBlazor.Core.Components;

[CodeGenerationIgnore]
public class RelatedRecordsInfoFieldOrder : MapComponent
{
    [ActivatorUtilitiesConstructor]
    public RelatedRecordsInfoFieldOrder()
    {
    }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="RelatedRecordsInfoFieldOrder"/> class.
    /// </summary>
    /// <param name="field">
    ///     The attribute value of the field selected that will drive the sorting of related records.
    /// </param>
    /// <param name="order">
    ///     Set the ascending or descending sort order of the returned related records.
    /// </param>
    public RelatedRecordsInfoFieldOrder(string? field, OrderBy? order)
    {
        Field = field;
        Order = order;
    }
    
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

[ProtoContract(Name = "RelatedRecordsInfoFieldOrder")]
internal record RelatedRecordsInfoFieldOrderSerializationRecord(
    [property: ProtoMember(1)] string? Field, 
    [property: ProtoMember(2)] OrderBy? Order)
{
    public RelatedRecordsInfoFieldOrder FromSerializationRecord()
    {
        return new(Field, Order);
    }
}