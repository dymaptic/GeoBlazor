

using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
/// Contains information about the tiling scheme for WMTSSublayer.
/// </summary>

public class TileMatrixSet
{
    /// <summary>
    ///     Constructor for use as a razor component
    /// </summary>
    public TileMatrixSet()
    {
    }

    /// <summary>
    ///     The full extent of the TileMatrixSet. 
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? FullExtent { get; set; }

    /// <summary>
    ///     The unique id of TileMatrixSet.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    ///     The tiling scheme information for the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TileInfo? TileInfo { get; set; }
}
