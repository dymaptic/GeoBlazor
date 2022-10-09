using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A polyline contains an array of paths and spatialReference. Each path is represented as an array of points. A polyline also has boolean-valued hasM and hasZ properties.
///     <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">ArcGIS JS API</a>
/// </summary>
public class PolyLine : Geometry
{
    /// <summary>
    ///     An array of <see cref="MapPath"/> paths, or line segments, that make up the polyline.
    /// </summary>
    [Parameter]
    public MapPath[] Paths
    {
        get => _paths;
        set
        {
            if (!_paths.SequenceEqual(value, MapPathEqualityComparer.Instance))
            {
                _paths = value.Select(p => p.DeepCopy()).ToArray();
                Task.Run(UpdateComponent);
            }
        }
    }

    /// <inheritdoc />
    public override string Type => "polyline";
    private MapPath[] _paths = Array.Empty<MapPath>();
}