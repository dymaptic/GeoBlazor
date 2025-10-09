namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     Renamed to Polyline (lowercase 'l') to match the JavaScript API
/// </summary>
/// <exclude/>
[Obsolete("Renamed to Polyline (lowercase 'l') to match the JavaScript API")]
public class PolyLine : Polyline
{
    /// <summary>
    ///     Constructor for the PolyLine class.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PolyLine()
    {
    }

    /// <summary>
    ///     Constructor for the PolyLine class.
    /// </summary>
    public PolyLine(MapPath[] paths, SpatialReference? spatialReference = null,
        Extent? extent = null): base(paths, spatialReference)
    {
    }
}