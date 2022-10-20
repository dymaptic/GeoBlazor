using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A polygon contains an array of rings and a spatialReference. Each ring is represented as an array of points. The first and last points of a ring must be the same. A polygon also has boolean-valued hasM and hasZ fields.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">ArcGIS JS API</a>
/// </summary>
public class Polygon : Geometry
{
    /// <summary>
    ///     An array of <see cref="MapPath"/> rings.
    /// </summary>
    [Parameter]
    public MapPath[] Rings
    {
        get => _rings;
        set
        {
            if (!_rings.SequenceEqual(value, MapPathEqualityComparer.Instance))
            {
                _rings = value.Select(p => p.DeepCopy()).ToArray();
                Task.Run(UpdateComponent);
            }
        }
    }

    /// <inheritdoc />
    public override string Type => "polygon";

    private MapPath[] _rings = Array.Empty<MapPath>();
}