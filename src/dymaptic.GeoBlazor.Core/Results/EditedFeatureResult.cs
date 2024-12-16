using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Results returned from the applyEdits method if the returnServiceEditsOption parameter is set to original-and-current-features. It contains features that were added, deleted or updated in different feature layers of a feature service as a result of editing a single feature that participates in a composite relationship in a database. The results are organized by each layer affected by the edit. For example, if a feature is deleted and it is the origin in a composite relationship, the edited features as a result of this deletion are returned.
///     The editedFeatures object returns full features including newly added features, the original features prior to delete, the original and current features for updates.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditedFeatureResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="LayerId">
///     The layerId of the feature layer where features were edited.
/// </param>
/// <param name="EditedFeatures">
///     Object containing all edited features belonging to the specified layer.
/// </param>
public record EditedFeatureResult(long? LayerId, EditedFeatures? EditedFeatures);

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
