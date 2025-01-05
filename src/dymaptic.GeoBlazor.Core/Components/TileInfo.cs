namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     Contains information about the tiling scheme for TileLayers, ElevationLayers, ImageryTileLayers, VectorTileLayers,
///     and WebTileLayers.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TileInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class TileInfo : MapComponent
{
    /// <summary>
    ///     The dots per inch (DPI) of the tiling scheme.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Dpi { get; set; }

    /// <summary>
    ///     Image format of the cached tiles.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfoFormat? Format { get; set; }

    /// <summary>
    ///     Indicates if the tiling scheme supports wrap around.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsWrappable { get; set; }

    /// <summary>
    ///     An array of levels of detail that define the tiling scheme.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<LOD>? Lods { get; set; }

    /// <summary>
    ///     Size of tiles in pixels.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<double>? Size { get; set; }

    /// <summary>
    ///     The tiling scheme origin
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Point? Origin { get; set; }

    /// <summary>
    ///     The spatial reference of the tiling schema.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Point point:
                if (!point.Equals(Origin))
                {
                    Origin = point;
                }

                break;
            case SpatialReference spatialReference:
                if (!spatialReference.Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
                }

                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Point _:
                Origin = null;
                break;
            case SpatialReference _:
                SpatialReference = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    internal override void ValidateRequiredChildren()
    {
        Origin?.ValidateRequiredChildren();
        SpatialReference?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}