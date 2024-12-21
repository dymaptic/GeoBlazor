namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Represents the result of a geocode service operation as a list of address candidates. This resource provides
///     information about candidates, including the address, location, and match score.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AddressCandidate.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record AddressCandidate
{
    /// <summary>
    ///     Address of the candidate.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    ///     Name value pairs of field name and field value as defined in outFields in locator.addressToLocations().
    /// </summary>
    public Dictionary<string, object> Attributes { get; set; } = new();

    /// <summary>
    ///     The minimum and maximum X and Y coordinates of a bounding box of the address candidate.
    /// </summary>
    public Extent? Extent { get; set; }

    /// <summary>
    ///     The Point object representing the location of the address.
    /// </summary>
    public Point? Location { get; set; }

    /// <summary>
    ///     Numeric score between 0 and 100 for geocode candidates.
    /// </summary>
    public double? Score { get; set; }
}