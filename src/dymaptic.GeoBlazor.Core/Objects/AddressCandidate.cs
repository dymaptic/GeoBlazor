using dymaptic.GeoBlazor.Core.Components.Geometries;


namespace dymaptic.GeoBlazor.Core.Objects;

public class AddressCandidate
{
    public string? Address { get; set; }
    public Dictionary<string, string> Attributes { get; set; } = new();
    public Extent? Extent { get; set; }
    public Point? Location { get; set; }
    public double? Score { get; set; }
}