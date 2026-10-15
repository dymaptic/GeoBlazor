namespace dymaptic.GeoBlazor.Pro.Model;


/// <summary>
///     Models the JSON response from an ArcGIS Feature Service query endpoint (<c>.../FeatureServer/{layerId}/query</c>).
/// </summary>
public partial record FeatureQueryResponse
{
    /// <summary>
    ///     The object ID field name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ObjectIdFieldName { get; init; }

    /// <summary>
    ///     The global ID field name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GlobalIdFieldName { get; init; }

    /// <summary>
    ///     The geometry type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GeometryType? GeometryType { get; init; }

    /// <summary>
    ///     The spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; init; }

    /// <summary>
    ///     Whether the response includes Z values.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasZ { get; init; }

    /// <summary>
    ///     Whether the response includes M values.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasM { get; init; }

    /// <summary>
    ///     Whether the service exceeded the transfer limit.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ExceededTransferLimit { get; init; }

    /// <summary>
    ///     The fields returned with the query response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<LayerMetadataField>? Fields { get; init; }

    /// <summary>
    ///     The features returned by the query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<QueryFeature>? Features { get; init; }

    /// <summary>
    ///     The quantization transform applied to the query geometry.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QueryTransform? Transform { get; init; }
}


/// <summary>
///     Single feature row in a Feature Service query response. Geometry shape varies by layer geometryType.
/// </summary>
public partial record QueryFeature(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyDictionary<string, object?>? Attributes = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    object? Geometry = null);


/// <summary>
///     Quantization transform (origin/scale/translate) used when a Feature Service query returns coordinate-quantized geometry.
/// </summary>
public partial record QueryTransform(
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? OriginPosition = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<double>? Scale = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<double>? Translate = null);
