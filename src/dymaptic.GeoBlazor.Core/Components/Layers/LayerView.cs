namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Represents the view for a single layer after it has been added to either a MapView or a SceneView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">ArcGIS JS API</a>
/// </summary>
/// <param name="Layer">
///     The layer being viewed.
/// </param>
/// <param name="SpatialReferenceSupported">
///     Indicates if the spatialReference of the MapView is supported by the layer view.
/// </param>
/// <param name="Suspended">
///     Value is true if the layer is suspended (i.e., layer will not redraw or update itself when the extent changes).
/// </param>
/// <param name="Updating">
///     Value is true when the layer is updating; for example, if it is in the process of fetching data.
/// </param>
/// <param name="Visible">
///     Value is true when the layer is updating; for example, if it is in the process of fetching data.
/// </param>
public record LayerView(Layer Layer, bool SpatialReferenceSupported, bool Suspended, bool Updating, bool Visible);