namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The RelatedRecordsInfoFieldOrder class indicates the field display order for the related records in a layer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-PopupTemplate.html">PopupTemplate</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-support-RelatedRecordsInfoFieldOrder.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class RelatedRecordsInfoFieldOrder : MapComponent, 
    IProtobufSerializable<RelatedRecordsInfoFieldOrderSerializationRecord>
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
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

    /// <inheritdoc />
    public RelatedRecordsInfoFieldOrderSerializationRecord ToProtobuf()
    {
        return new RelatedRecordsInfoFieldOrderSerializationRecord(Field, Order?.ToString().ToKebabCase(), 
            Id.ToString());
    }
}