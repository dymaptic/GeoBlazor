namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     Represents a GeoJSON FeatureCollection
/// </summary>
/// <param name="Features">
///     The list of features in the collection.
/// </param>
/// <param name="Style">
///     Optional style properties for the full collection.
/// </param>
public record GeoJSONFeatureCollection(List<GeoJSONFeature> Features, GeoJSONStyle? Style = null);

/// <summary>
///     Represents a GeoJSON Feature
/// </summary>
/// <param name="Geometry">
///     The geometry object for the feature.
/// </param>
/// <param name="Properties">
///     Optional properties associated with the feature.
/// </param>
/// <param name="Style">
///     Optional style properties for the feature.
/// </param>
public record GeoJSONFeature(GeoJSONGeometry? Geometry = null, 
    Dictionary<string, object?>? Properties = null, 
    GeoJSONStyle? Style = null);

/// <summary>
///     Represents a GeoJSON Geometry
/// </summary>
/// <param name="Type">
///     The type of geometry (e.g., Point, LineString, Polygon).
/// </param>
/// <param name="Coordinates">
///     The coordinates of the geometry, as a JSON element.
/// </param>
public record GeoJSONGeometry(string Type, JsonElement Coordinates);
