namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes top features query operations that can be performed on features in the layer.
/// </summary>
/// <param name="SupportsCacheHint">
///     Indicates if the top query operation supports a cache hint. This is valid only for hosted feature services.
/// </param>
public record QueryTopFeaturesCapability(bool SupportsCacheHint);