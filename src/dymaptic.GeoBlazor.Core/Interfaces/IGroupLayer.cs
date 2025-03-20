namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///   For reading GroupLayer layers from GeoBlazor Pro.
/// </summary>
public interface IGroupLayer
{
    IReadOnlyList<Layer>? Layers { get; set; }
}