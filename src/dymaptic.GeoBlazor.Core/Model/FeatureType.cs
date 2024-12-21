namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     FeatureType is a subset of features defined in a FeatureLayer that share the same attributes.
///     They are used as a way to categorize your data. For example, the streets in a city streets feature layer
///     could be categorized into three feature types: local streets, collector streets, and arterial streets.
/// </summary>
public record FeatureType(string Id, string Name, FeatureTemplate[] Templates, Dictionary<string, Domain?> Domains);