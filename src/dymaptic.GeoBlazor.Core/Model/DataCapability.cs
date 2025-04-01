namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Describes characteristics of the data in the layer.
/// </summary>
/// <param name="IsVersioned">
///     Indicates if the feature service is versioned.
/// </param>
/// <param name="SupportsAttachment">
///     Indicates if the attachment is enabled on the layer.
/// </param>
/// <param name="SupportsM">
///     Indicates if the features in the layer support m-values.
/// </param>
/// <param name="SupportsZ">
///     Indicates if the features in the layer support z-values. See elevationInfo for details regarding placement and rendering of features with z-values in 3D SceneViews.
/// </param>
public record DataCapability(bool IsVersioned, bool SupportsAttachment, bool SupportsM, bool SupportsZ);