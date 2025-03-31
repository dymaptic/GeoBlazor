namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes what analytics capabilities are enabled on the layer.
/// </summary>
/// <param name="SupportsCacheHint">
///     Indicates if the feature service supports cache hint.
/// </param>
public record AnalyticsCapability(bool SupportsCacheHint);