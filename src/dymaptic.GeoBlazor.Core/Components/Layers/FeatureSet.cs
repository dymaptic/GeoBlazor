using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A collection of features returned from ArcGIS Server or used as input to methods. Each feature in the FeatureSet
///     may contain geometry, attributes, and symbology. If the FeatureSet does not contain geometry, and only contains
///     attributes, the FeatureSet can be treated as a table where each feature is a row object. Methods that return
///     FeatureSet include query.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record FeatureSet
{
    /// <summary>
    ///     The name of the layer's primary display field. The value of this property matches the name of one of the fields of
    ///     the feature. This is only applicable when the FeatureSet is returned from a task. It is ignored when the FeatureSet
    ///     is used as input to a geoprocessing task.
    /// </summary>
    public string? DisplayFieldName { get; set; }
    /// <summary>
    ///     Typically, a layer has a limit on the number of features (i.e., records) returned by the query operation. If
    ///     maxRecordCount is configured for a layer, exceededTransferLimit will be true if a query matches more than the
    ///     maxRecordCount features. It will be false otherwise. Supported by ArcGIS Server version 10.1 and later.
    /// </summary>
    public bool? ExceededTransferLimit { get; set; }
    /// <summary>
    ///     The array of graphics returned from a task.
    /// </summary>
    public Graphic[]? Features { get; set; }
    
    /// <summary>
    ///     Information about each field.
    /// </summary>
    public Field[]? Fields { get; set; }
    
    /// <summary>
    ///     The geometry type of features in the FeatureSet. All features's geometry must be of the same type.
    /// </summary>
    public GeometryType? GeometryType { get; set; }
    
    /// <summary>
    ///     The geometry used to query the features. It is useful for getting the buffer geometry generated when querying
    ///     features by distance or getting the query geometry projected in the outSpatialReference of the query. The query
    ///     geometry is returned only for client-side queries and hosted feature services. The query's returnQueryGeometry must
    ///     be set to true and the layer's capabilities.query.supportsQueryGeometry has to be true for the query to return
    ///     query geometry.
    /// </summary>
    public Geometry? QueryGeometry { get; set; }
    
    /// <summary>
    ///     When a FeatureSet is used as input to Geoprocessor, the spatial reference is set to the map's spatial reference by
    ///     default. This value can be changed. When a FeatureSet is returned from a task, the value is the result as returned
    ///     from the server.
    /// </summary>
    public SpatialReference? SpatialReference { get; set; }
}