using dymaptic.GeoBlazor.Core.Components.Geometries;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Specifies constraints to scale, zoom, and rotation that may be applied to the MapView. The constraints.lods should
///     be set in the MapView constructor, if the map does not have a basemap or when the basemap does not have tileInfo.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#constraints">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Constraints : MapComponent
{
    /// <summary>
    ///     An array of LODs. If not specified, this value is read from the Map.
    /// </summary>
    public List<LOD>? Lods { get; set; }

    /// <summary>
    ///     The area in which the user is allowed to navigate laterally. Only Extent and Polygon geometry types are supported.
    ///     Z-values are ignored.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }

    /// <summary>
    ///     The minimum scale the user is allowed to zoom to within the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     The maximum scale the user is allowed to zoom to within the view. Setting this value to 0 allows the user to
    ///     overzoom layer tiles.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     The minimum zoom level the user is allowed to zoom to within the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinZoom { get; set; }

    /// <summary>
    ///     The maximum zoom level the user is allowed to zoom to within the view. Setting this value to 0 allows the user to
    ///     over-zoom layer tiles.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxZoom { get; set; }

    /// <summary>
    ///     When true, the view snaps to the next LOD when zooming in or out. When false, the zoom is continuous. This does not
    ///     apply when zooming in/out using two finger pinch in/out.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SnapToZoom { get; set; }

    /// <summary>
    ///     Indicates whether the user can rotate the map. If not set, defaults to true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RotationEnabled { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LOD lod:
                Lods ??= new List<LOD>();

                if (!Lods.Contains(lod))
                {
                    Lods.Add(lod);
                }

                break;
            case Geometry geometry:
                if (!geometry.Equals(Geometry))
                {
                    Geometry = geometry;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LOD lod:
                Lods?.Remove(lod);

                if (Lods is not null && !Lods.Any())
                {
                    Lods = null;
                }

                break;
            case Geometry _:
                Geometry = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Geometry?.ValidateRequiredChildren();

        if (Lods is not null)
        {
            foreach (LOD lod in Lods)
            {
                lod.ValidateRequiredChildren();
            }
        }
    }
}