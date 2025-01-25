namespace dymaptic.GeoBlazor.Core.Results;

public partial record EditedFeatureResult;

/// <summary>
///     The edited features of an <see cref="EditedFeatureResult"/>
/// </summary>
/// <param name="Adds">
///     Newly added features as a result of editing a feature that participates in a composite relationship.
/// </param>
/// <param name="Updates">
///     Object containing original and updated features as a result of editing a feature that participates in a composite relationship.
/// </param>
/// <param name="Deletes">
///     Deleted features as a result of editing a feature that participates in a composite relationship.
/// </param>
/// <param name="SpatialReference">
///     Edited features are returned in the spatial reference of the feature service.
/// </param>
public record EditedFeatures(Graphic[] Adds, EditedFeatureUpdate[] Updates, Graphic[] Deletes,
    SpatialReference SpatialReference);

/// <summary>
///     The update object of a <see cref="EditedFeatures"/>.
/// </summary>
/// <param name="Original">
///     Original feature before the update took place.
/// </param>
/// <param name="Current">
///     Updated feature as a result of editing a feature that participates in a composite relationship.
/// </param>
public record EditedFeatureUpdate(Graphic[] Original, Graphic[] Current);
