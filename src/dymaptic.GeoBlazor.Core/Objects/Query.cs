using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Components.Geometries;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
public class Query
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
    public SpatialRelationship? SpatialRelationship { get; set; }
    public Geometry? Geometry { get; set; }
    public HashSet<string> OutFields { get; set; } = new();
    public bool ReturnGeometry { get; set; }
    public bool UseViewExtent { get; set; }
}

public class AddressQuery
{
    public string? LocatorUrl { get; set; }
    public HashSet<string> Categories { get; set; } = new();
    public Address? Address { get; set; }
    public int? MaxLocations { get; set; }
    public HashSet<string> OutFields { get; set; } = new();
}

public record Address(string Street, string City, string State, string Zone);