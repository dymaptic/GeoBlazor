using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     A RelationshipContent popup element represents a relationship element associated with a feature. This can only be
///     configured if the related layer or table is added to the map.
///     RelationshipContent provides a way to browse related records of the current selected feature within its popup, as
///     shown in the images below. The Origin Feature image shows a popup template configured with RelationshipContent.
///     When selecting one of the related features in the list, the popup template for the chosen related destination
///     feature displays. The Related Destination Feature image shows the destination popup template content with
///     FieldsContent and RelationshipContent configured. When exploring a related feature's RelationshipContent, one could
///     navigate into that feature's related records or exit the origin feature's related record exploration with the arrow
///     button.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-RelationshipContent.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class RelationshipPopupContent : PopupContent
{
    /// <inheritdoc />
    public override string Type => "relationship";

    /// <summary>
    ///     Describes the relationship's content in detail.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     A numeric value indicating the maximum number of related features to display in the list of related records. The
    ///     maximum number of related records to display in the list of related records is 10. If no value is specified, the
    ///     Show all button will be available to display all related records.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DisplayCount { get; set; }

    /// <summary>
    ///     A string value indicating how to display related records within the relationship content.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayType { get; set; }

    /// <summary>
    ///     An array of RelatedRecordsInfoFieldOrder indicating the display order for the related records, and whether they
    ///     should be sorted in ascending asc or descending desc order.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<RelatedRecordsInfoFieldOrder> OrderByFields { get; set; } = new();

    /// <summary>
    ///     The numeric id value for the defined relationship. This value can be found on the service itself or on the
    ///     service's relationships resource if supportsRelationshipResource is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RelationshipId { get; set; }

    /// <summary>
    ///     A heading indicating what the relationship's content represents.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type)
        {
            Description = Description,
            DisplayCount = DisplayCount,
            DisplayType = DisplayType,
            OrderByFields = OrderByFields.Select(r => r.ToSerializationRecord()).ToArray(),
            RelationshipId = RelationshipId,
            Title = Title
        };
    }
}

/// <summary>
///     The RelatedRecordsInfoFieldOrder class indicates the field display order for the related records in a layer's
///     PopupTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-support-RelatedRecordsInfoFieldOrder.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class RelatedRecordsInfoFieldOrder : MapComponent
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

internal record RelatedRecordsInfoFieldOrderSerializationRecord(string? Field, OrderBy? Order);