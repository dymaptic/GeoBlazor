namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a query for counts of related features, grouped by the source layer or table objectIds. Value is the number of related features.
/// </summary>
public class RelatedFeaturesCountQueryResult: Dictionary<long, int>;