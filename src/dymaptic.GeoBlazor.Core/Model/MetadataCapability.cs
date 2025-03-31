namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes the metadata contained on features in the layer.
/// </summary>
/// <param name="SupportsAdvancedFieldProperties">
///     Indicates whether to provide a user-defined field description. See Describe attribute fields for additional information.
/// </param>
public record MetadataCapability(bool SupportsAdvancedFieldProperties);