using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public class PolyLine : Geometry
{
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

    public override string Type => "polyline";
    private MapPath[] _paths = Array.Empty<MapPath>();
}