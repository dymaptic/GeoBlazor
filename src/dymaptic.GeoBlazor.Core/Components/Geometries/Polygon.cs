using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public class Polygon : Geometry
{
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

    public override string Type => "polygon";

    private MapPath[] _rings = Array.Empty<MapPath>();
}