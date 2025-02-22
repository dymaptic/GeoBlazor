namespace dymaptic.GeoBlazor.Core.Interfaces;

public partial interface IFeatureLayerBase
{


    /// <summary>
    ///     Applies edits to features in a layer. New features can be created and existing features can be updated or deleted. Feature geometries and/or attributes may be modified. Only applicable to layers in a feature service and client-side features set through the FeatureLayer's source property. Attachments can also be added, updated or deleted.
    ///     If client-side features are added, removed or updated at runtime using applyEdits() then use FeatureLayer's queryFeatures() method to return updated features.
    /// </summary>
    [CodeGenerationIgnore]
    Task<FeatureEditsResult> ApplyEdits(FeatureEdits edits, FeatureEditOptions? options = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the Field instance for a field name (case-insensitive).
    /// </summary>
    /// <param name="fieldName">the field name (case-insensitive).</param>
    [ArcGISMethod]
    Task<Field?> GetField(string fieldName);

    /// <summary>
    /// Returns the Domain associated with the given field name. The domain can be either a CodedValueDomain or RangeDomain.
    /// </summary>
    [CodeGenerationIgnore]
    Task<Domain?> GetFieldDomain(string fieldName, Graphic? feature = null);

    /// <summary>
    ///     Executes a RelationshipQuery against the feature service and returns FeatureSets grouped by source layer or table
    ///     objectIds.
    /// </summary>
    /// <param name="query">
    ///     Specifies relationship parameters for querying related features or records from a layer or a table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    Task<RelatedFeaturesQueryResult?> QueryRelatedFeatures(RelationshipQuery query,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Executes a RelationshipQuery against the feature service and when resolved, it returns an object containing key
    ///     value pairs. Key in this case is the objectId of the feature and value is the number of related features associated
    ///     with the feature.
    /// </summary>
    /// <param name="query">
    ///     Specifies relationship parameters for querying related features or records from a layer or a table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    Task<RelatedFeaturesCountQueryResult?> QueryRelatedFeaturesCount(RelationshipQuery query,
        CancellationToken cancellationToken = default);
}