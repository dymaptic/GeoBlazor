// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    Describes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">layer's</a> relationship with another layer or table.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Cardinality">
///     The cardinality which specifies the number of objects in the origin <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">FeatureLayer</a> related to the number of objects in the destination <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">FeatureLayer</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#cardinality">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Composite">
///     Indicates whether the relationship is composite.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#composite">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="KeyField">
///     The field used to establish the relate within the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">FeatureLayer</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#keyField">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="KeyFieldInRelationshipTable">
///     The key field in an attributed relationship class table that matches the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#keyField">keyField</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#keyFieldInRelationshipTable">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Name">
///     The name of the relationship.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#name">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="RelatedTableId">
///     The unique ID of the related <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">FeatureLayer</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#relatedTableId">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="RelationshipId">
///     The unique ID for the relationship.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#id">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="RelationshipTableId">
///     The relationship table id.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#relationshipTableId">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Role">
///     Indicates whether the table participating in the relationship is the `origin` or `destination` table.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html#role">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record Relationship(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Cardinality? Cardinality = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? Composite = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? KeyField = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? KeyFieldInRelationshipTable = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Name = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? RelatedTableId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? RelationshipId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    long? RelationshipTableId = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Role? Role = null);

