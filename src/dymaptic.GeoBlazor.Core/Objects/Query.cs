using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Components.Geometries;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     This class defines parameters for executing queries for features from a layer or layer view. Once a Query object's properties are defined, it can then be passed into an executable function, which will return the features in a FeatureSet.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">ArcGIS JS API</a>
/// </summary>
public class Query
{
    /// <summary>
    ///     A where clause for the query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
    
    /// <summary>
    ///     For spatial queries, this parameter defines the spatial relationship to query features in the layer or layer view against the input geometry.
    /// </summary>
    public SpatialRelationship? SpatialRelationship { get; set; }
    
    /// <summary>
    ///     The geometry to apply to the spatial filter.
    /// </summary>
    public Geometry? Geometry { get; set; }
    
    /// <summary>
    ///     Attribute fields to include in the FeatureSet.
    /// </summary>
    public HashSet<string> OutFields { get; set; } = new();
    
    /// <summary>
    ///     If true, each feature in the returned FeatureSet includes the geometry.
    /// </summary>
    public bool ReturnGeometry { get; set; }
    
    /// <summary>
    ///     Determines whether to use the view's extent as the query geometry
    /// </summary>
    public bool UseViewExtent { get; set; }
}

/// <summary>
///     A collection of parameters to pass to locator.addressToLocations
/// </summary>
public class AddressQuery
{
    /// <summary>
    ///     URL to the ArcGIS Server REST resource that represents a locator service.
    /// </summary>
    public string? LocatorUrl { get; set; }
    
    /// <summary>
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food". Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </summary>
    public HashSet<string> Categories { get; set; } = new();
    
    /// <summary>
    ///     The address argument is data object that contains properties representing the various address fields accepted by the corresponding geocode service. These fields are listed in the addressFields property of the associated geocode service resource.
    /// </summary>
    public Address? Address { get; set; }
    
    /// <summary>
    ///     Maximum results to return from the query.
    /// </summary>
    public int? MaxLocations { get; set; }
    
    /// <summary>
    ///     The list of fields included in the returned result set. This list is a comma delimited list of field names. If you specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection candidate fields.
    /// </summary>
    public HashSet<string> OutFields { get; set; } = new();
}

/// <summary>
///     A complete street address for use in an <see cref="AddressQuery"/>
/// </summary>
public record Address(string Street, string City, string State, string Zone);