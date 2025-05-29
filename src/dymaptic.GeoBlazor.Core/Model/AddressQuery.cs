namespace dymaptic.GeoBlazor.Core.Model;


/// <summary>
///     A collection of parameters to pass to locator.addressToLocations
/// </summary>
public record AddressQuery
{
    /// <summary>
    ///     URL to the ArcGIS Server REST resource that represents a locator service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LocatorUrl { get; set; }

    /// <summary>
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food". Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<string>? Categories { get; set; }

    /// <summary>
    ///     The address argument is data object that contains properties representing the various address fields accepted by the corresponding geocode service. These fields are listed in the addressFields property of the associated geocode service resource.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Address? Address { get; set; }

    /// <summary>
    ///     Maximum results to return from the query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxLocations { get; set; }

    /// <summary>
    ///     The list of fields included in the returned result set. This list is a comma delimited list of field names. If you specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection candidate fields.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<string>? OutFields { get; set; }
}