namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The RelatedRecordsInfoFieldOrder class indicates the field display order for the related records in a layer's
///     PopupTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-support-RelatedRecordsInfoFieldOrder.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class RelatedRecordsInfoFieldOrder : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public RelatedRecordsInfoFieldOrder()
    {
    }

    /// <summary>
    ///     Constructor for creating a new RelatedRecordsInfoFieldOrder in code with parameters
    /// </summary>
    /// <param name="field">
    ///     The attribute value of the field selected that will drive the sorting of related records.
    /// </param>
    /// <param name="order">
    ///     Set the ascending or descending sort order of the returned related records.
    /// </param>
    public RelatedRecordsInfoFieldOrder(string? field = null, OrderBy? order = null)
    {
#pragma warning disable BL0005
        Field = field;
        Order = order;
#pragma warning restore BL0005
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

internal record RelatedRecordsInfoFieldOrderSerializationRecord([property: ProtoMember(1)] string? Field, [property: ProtoMember(2)] OrderBy? Order)
{
    public RelatedRecordsInfoFieldOrder FromSerializationRecord()
    {
        return new(Field, Order);
    }
}