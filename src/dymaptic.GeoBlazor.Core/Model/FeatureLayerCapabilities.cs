namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes the layer's supported capabilities.
/// </summary>
/// <param name="Analytics">
///     Describes what analytics capabilities are enabled on the layer.
/// </param>
/// <param name="Attachment">
///     Describes what attachment capabilities are enabled on the layer.
/// </param>
/// <param name="Data">
///     Describes characteristics of the data in the layer.
/// </param>
/// <param name="Editing">
///     Describes editing capabilities that can be performed on the features in the layer via ApplyEdits().
/// </param>
/// <param name="Metadata">
///     Describes the metadata contained on features in the layer.
/// </param>
/// <param name="Operations">
///     Describes operations that can be performed on features in the layer.
/// </param>
/// <param name="Query">
///     Describes query operations that can be performed on features in the layer.
/// </param>
/// <param name="QueryRelated">
///     Indicates if the layer's query operation supports querying features or records related to features in the layer.
/// </param>
/// <param name="QueryTopFeatures">
///     Describes top features query operations that can be performed on features in the layer.
/// </param>
public record FeatureLayerCapabilities(AnalyticsCapability Analytics, AttachmentCapability Attachment,
    DataCapability Data, EditingCapability Editing, MetadataCapability Metadata, OperationsCapability Operations,
    QueryCapability Query, QueryRelatedCapability QueryRelated, QueryTopFeaturesCapability QueryTopFeatures);