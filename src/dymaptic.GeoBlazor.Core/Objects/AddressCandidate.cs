using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
public class AddressCandidate
{
    public string? Address { get; set; }
    public Dictionary<string, string> Attributes { get; set; } = new();
    public Extent? Extent { get; set; }
    public Point? Location { get; set; }
    public double? Score { get; set; }
}