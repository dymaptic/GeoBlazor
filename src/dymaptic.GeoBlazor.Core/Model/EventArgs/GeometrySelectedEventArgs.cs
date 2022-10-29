using dymaptic.GeoBlazor.Core.Components.Geometries;

namespace dymaptic.GeoBlazor.Core.Model.EventArgs;

/// <summary>
/// Event argumets that are delivered to method when
/// </summary>
public class GeometrySelectedEventArgs<T_TypeOfGeometry> : System.EventArgs
    where T_TypeOfGeometry : Geometry
{
    /// <summary>
    /// Boolean to represent if geometry was selected. This will be false if a click was performed outside of geometry
    /// </summary>
    public bool GeometryWasSelected { get; init; }

    /// <summary>
    /// Geometry that was selected. Will be null if geometry wasn't selected 
    /// </summary>
    public T_TypeOfGeometry? Geometry { get; init; } = null;

    /// <summary>
    /// Dictionary of feature attributes that are associated with this geometry if any. Will be null if click was performet outside of this geometry.
    /// </summary>
    public Dictionary<string, object>? Attributes { get; init; }
}