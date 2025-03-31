namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Indicates if the layer's query operation supports querying features or records related to features in the layer.
/// </summary>
/// <param name="SupportsCacheHint">
///     Indicates if the relationship query operation supports a cache hint. This is valid only for hosted feature services.
/// </param>
/// <param name="SupportsCount">
///     Indicates if the layer's query response includes the number of features or records related to features in the layer.
/// </param>
/// <param name="SupportsOrderBy">
///     Indicates if the related features or records returned in the query response can be ordered by one or more fields.
/// </param>
/// <param name="SupportsPagination">
///     Indicates if the query response supports pagination for related features or records.
/// </param>
public record QueryRelatedCapability(bool SupportsCacheHint, bool SupportsCount, bool SupportsOrderBy,
    bool SupportsPagination);