namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class RelationshipPopupContent : PopupContent
{


    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Relationship;

    /// <summary>
    ///     Describes the relationship's content in detail.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     A numeric value indicating the maximum number of related features to display in the list of related records. The maximum number of related records to display in the list of related records is 10. If no value is specified, the Show all button will be available to display all related records.
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
    ///     An array of RelatedRecordsInfoFieldOrder indicating the display order for the related records, and whether they should be sorted in ascending asc or descending desc order.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<RelatedRecordsInfoFieldOrder>? OrderByFields { get; set; }

    /// <summary>
    ///     The numeric id value for the defined relationship. This value can be found on the service itself or on the service's relationships resource if supportsRelationshipResource is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? RelationshipId { get; set; }

    /// <summary>
    ///     A heading indicating what the relationship's content represents.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type.ToString().ToKebabCase())
        {
            Description = Description,
            DisplayCount = DisplayCount,
            DisplayType = DisplayType,
            OrderByFields = OrderByFields?.Select(r => r.ToSerializationRecord()).ToArray(),
            RelationshipId = RelationshipId,
            Title = Title
        };
    }
}

