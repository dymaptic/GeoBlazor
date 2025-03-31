namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     Options to specify what is included in or excluded from the hitTest.
/// </summary>
public record HitTestOptions
{
    /// <summary>
    ///     A list of layers and/or graphics GeoBlazor Ids (Guid) to include in the hitTest. All layers and graphics will be
    ///     included if include is not specified.
    /// </summary>
    public IEnumerable<Guid>? IncludeByGeoBlazorId { get; set; }

    /// <summary>
    ///     A list of layer ArcGIS Ids (aka FIELDID or OBJECTID) to include in the hitTest. All layers and graphics will be
    ///     included if include is not specified.
    /// </summary>
    public IEnumerable<string>? IncludeLayersByArcGISId { get; set; }

    /// <summary>
    ///     A list of graphic ArcGIS OBJECTID attributes to include in the hitTest. All layers and graphics will be included if
    ///     include is not specified.
    /// </summary>
    public IEnumerable<string>? IncludeGraphicsByArcGISId { get; set; }

    /// <summary>
    ///     A list of layers and/or graphics GeoBlazor Ids (Guid) to exclude from the hitTest. No layers or graphics will be
    ///     excluded if exclude is not specified.
    /// </summary>
    public IEnumerable<Guid>? ExcludeByGeoBlazorId { get; set; }

    /// <summary>
    ///     A list of layer ArcGIS Ids (aka FIELDID or OBJECTID) to exclude in the hitTest. No layers and graphics will be
    ///     excluded if exclude is not specified.
    /// </summary>
    public IEnumerable<string>? ExcludeLayersByArcGISId { get; set; }

    /// <summary>
    ///     A list of graphic ArcGIS OBJECTID attributes to exclude in the hitTest. No layers and graphics will be excluded if
    ///     exclude is not specified.
    /// </summary>
    public IEnumerable<string>? ExcludeGraphicsByArcGISId { get; set; }
}