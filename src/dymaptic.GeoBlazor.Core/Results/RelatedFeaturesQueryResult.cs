using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Represents the result of a query for related features, grouped by the source layer or table objectIds.
/// </summary>
public class RelatedFeaturesQueryResult: Dictionary<long, FeatureSet?>;