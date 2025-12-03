namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     Represents the result of a geocode service operation as a list of address candidates. This resource provides information about candidates, including the address, location, and match score.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AddressCandidate.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public record AddressCandidate(
    string? Address = null,
    Dictionary<string, object>? Attributes = null,
    Extent? Extent = null,
    Point? Location = null,
    double? Score = null)
{
    public AddressCandidate(): this(null, null)
    {
    }
    
    /// <summary>
    ///     Address of the candidate.
    /// </summary>
    public string? Address { get; set; } = Address;
    /// <summary>
    ///     Name value pairs of field name and field value as defined in outFields in locator.addressToLocations().
    /// </summary>
    public Dictionary<string, object> Attributes { get; set; } = Attributes ?? [];
    /// <summary>
    ///     The minimum and maximum X and Y coordinates of a bounding box of the address candidate.
    /// </summary>
    public Extent? Extent { get; set; } = Extent;
    /// <summary>
    ///     The Point object representing the location of the address.
    /// </summary>
    public Point? Location { get; set; } = Location;
    /// <summary>
    ///     Numeric score between 0 and 100 for geocode candidates.
    /// </summary>
    public double? Score { get; set; } = Score;
}