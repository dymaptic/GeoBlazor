﻿using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Represents a geocode service resource exposed by the ArcGIS Server REST API. It is used to generate candidates for
///     an address. It is also used to generate batch results for a set of addresses.
///     Set the URL to the ArcGIS Server REST resource that represents a Locator service, for example:
///     https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-locator.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class Locator : LogicComponent
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    /// <param name="jsRuntime">
    ///     Injected JavaScript Runtime reference
    /// </param>
    /// <param name="authenticationManager">
    ///     Injected Identity Manager reference
    /// </param>
    public Locator(IJSRuntime jsRuntime, AuthenticationManager authenticationManager) : base(jsRuntime,
        authenticationManager)
    {
    }

    /// <inheritdoc />
    protected override string ComponentName => nameof(Locator);

    /// <summary>
    ///     Find address candidates for multiple input addresses.
    ///     Uses the default ESRI geolocation service.
    ///     Note: If using as API token: the token must have "Geocode (Stored)" enabled to get results
    /// </summary>
    /// <param name="addresses">The input addresses in the format supported by the geocode service. </param>
    /// <param name="countryCode">
    ///     Limits the results to only search in the country provided. For example US for United States
    ///     or SE for Sweden. Only applies to the World Geocode Service. See the World Geocoding Service documentation for more
    ///     information.
    /// </param>
    /// <param name="categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name="locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the
    ///     World Geocoding Service.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output
    ///     geometries are in the spatial reference of the input geometries when performing a reverse geocode and in the
    ///     default spatial reference returned by the service if finding locations by address.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    public async Task<List<AddressCandidate>> AddressesToLocations(List<Address> addresses, string? countryCode = null,
        List<string>? categories = null, LocationType? locationType = null,
        SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null)
    {
        return await AddressesToLocations(ESRIGeoLocationUrl, addresses, countryCode, categories, locationType,
            outSpatialReference, requestOptions);
    }

    /// <summary>
    ///     Find address candidates for multiple input addresses.
    ///     Note: If using as API token: the token must have "Geocode (Stored)" enabled to get results
    /// </summary>
    /// <param name="url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name="addresses">The input addresses in the format supported by the geocode service. </param>
    /// <param name="countryCode">
    ///     Limits the results to only search in the country provided. For example US for United States
    ///     or SE for Sweden. Only applies to the World Geocode Service. See the World Geocoding Service documentation for more
    ///     information.
    /// </param>
    /// <param name="categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name="locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the
    ///     World Geocoding Service.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output
    ///     geometries are in the spatial reference of the input geometries when performing a reverse geocode and in the
    ///     default spatial reference returned by the service if finding locations by address.
    /// </param>
    /// <returns></returns>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    public async Task<List<AddressCandidate>> AddressesToLocations(string url, List<Address> addresses,
        string? countryCode = null, List<string>? categories = null, LocationType? locationType = null,
        SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null)
    {
        return await InvokeAsync<List<AddressCandidate>>("addressesToLocations", url, addresses, countryCode,
            categories, locationType, outSpatialReference, requestOptions);
    }

    /// <summary>
    ///     Sends a request to the ArcGIS REST geocode resource to find candidates for a single address specified in the
    ///     address parameter.
    ///     Uses the default ESRI geolocation service.
    /// </summary>
    /// <param name="address">the various address fields accepted by the corresponding geocode service. </param>
    /// <param name="categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name="countryCode">
    ///     Limit result to a specific country. For example, "US" for United States or "SE" for Sweden.
    ///     Only applies to the World Geocode Service. See Geocode coverage (World Geocoding Service) for more information.
    /// </param>
    /// <param name="forStorage">Allows the results of single geocode transactions to be persisted.</param>
    /// <param name="location">Used to weight returned results for a specified area.</param>
    /// <param name="locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the
    ///     World Geocoding Service.
    /// </param>
    /// <param name="magicKey">A suggestLocations result ID (magicKey). Used to query for a specific results information.</param>
    /// <param name="maxLocations">Maximum results to return from the query.</param>
    /// <param name="outFields">
    ///     The list of fields included in the returned result set. This list is a comma delimited list of
    ///     field names. If you specify the shape field in the list of return fields, it is ignored. For non-intersection
    ///     addresses you can specify the candidate fields as defined in the geocode service. For intersection addresses you
    ///     can specify the intersection candidate fields.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output
    ///     geometries are in the spatial reference of the input geometries when performing a reverse geocode and in the
    ///     default spatial reference returned by the service if finding locations by address.
    /// </param>
    /// <param name="searchExtent">
    ///     Defines the extent within which the geocode server will search. Requires ArcGIS Server
    ///     version 10.1 or greater.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request 
    /// </param>
    public async Task<List<AddressCandidate>> AddressToLocations(Address address, List<string>? categories = null,
        string? countryCode = null, bool? forStorage = null, Point? location = null, LocationType? locationType = null,
        string? magicKey = null, int? maxLocations = null, List<string>? outFields = null,
        SpatialReference? outSpatialReference = null, Extent? searchExtent = null, RequestOptions? requestOptions = null)
    {
        return await AddressToLocations(ESRIGeoLocationUrl, address, categories, countryCode, forStorage, location,
            locationType, magicKey, maxLocations, outFields, outSpatialReference, searchExtent, requestOptions);
    }

    /// <summary>
    ///     Sends a request to the ArcGIS REST geocode resource to find candidates for a single address specified in the
    ///     address parameter.
    /// </summary>
    /// <param name="url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name="address">the various address fields accepted by the corresponding geocode service. </param>
    /// <param name="categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name="countryCode">
    ///     Limit result to a specific country. For example, "US" for United States or "SE" for Sweden.
    ///     Only applies to the World Geocode Service. See Geocode coverage (World Geocoding Service) for more information.
    /// </param>
    /// <param name="forStorage">Allows the results of single geocode transactions to be persisted.</param>
    /// <param name="location">Used to weight returned results for a specified area.</param>
    /// <param name="locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the
    ///     World Geocoding Service.
    /// </param>
    /// <param name="magicKey">A suggestLocations result ID (magicKey). Used to query for a specific results information.</param>
    /// <param name="maxLocations">Maximum results to return from the query.</param>
    /// <param name="outFields">
    ///     The list of fields included in the returned result set. This list is a comma delimited list of
    ///     field names. If you specify the shape field in the list of return fields, it is ignored. For non-intersection
    ///     addresses you can specify the candidate fields as defined in the geocode service. For intersection addresses you
    ///     can specify the intersection candidate fields.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output
    ///     geometries are in the spatial reference of the input geometries when performing a reverse geocode and in the
    ///     default spatial reference returned by the service if finding locations by address.
    /// </param>
    /// <param name="searchExtent">
    ///     Defines the extent within which the geocode server will search. Requires ArcGIS Server
    ///     version 10.1 or greater.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request 
    /// </param>
    public async Task<List<AddressCandidate>> AddressToLocations(string url, Address address,
        List<string>? categories = null, string? countryCode = null, bool? forStorage = null, Point? location = null,
        LocationType? locationType = null, string? magicKey = null, int? maxLocations = null,
        List<string>? outFields = null, SpatialReference? outSpatialReference = null, Extent? searchExtent = null,
        RequestOptions? requestOptions = null)
    {
        return await InvokeAsync<List<AddressCandidate>>("addressToLocations", url, address, categories, countryCode,
            forStorage, location, locationType, magicKey, maxLocations, outFields, outSpatialReference, searchExtent,
            requestOptions);
    }

    /// <summary>
    ///     Locates an address based on a given point.
    ///     Uses the default ESRI geolocation service.
    /// </summary>
    /// <param name="location">
    ///     The point at which to search for the closest address. The location should be in the same spatial
    ///     reference as that of the geocode service.
    /// </param>
    /// <param name="locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the
    ///     World Geocoding Service.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output
    ///     geometries are in the spatial reference of the input geometries when performing a reverse geocode and in the
    ///     default spatial reference returned by the service if finding locations by address.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request 
    /// </param>
    public async Task<AddressCandidate> LocationToAddress(Point location, LocationType? locationType = null,
        SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null)
    {
        return await LocationToAddress(ESRIGeoLocationUrl, location, locationType, outSpatialReference, requestOptions);
    }

    /// <summary>
    ///     Locates an address based on a given point.
    /// </summary>
    /// <param name="url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name="location">
    ///     The point at which to search for the closest address. The location should be in the same spatial
    ///     reference as that of the geocode service.
    /// </param>
    /// <param name="locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the
    ///     World Geocoding Service.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a
    ///     reverse geocode and in the default spatial reference returned by the service if finding locations by address.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request 
    /// </param>
    public async Task<AddressCandidate> LocationToAddress(string url, Point location, LocationType? locationType = null,
        SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null)
    {
        return await InvokeAsync<AddressCandidate>("locationToAddress", url, location, locationType,
            outSpatialReference, requestOptions);
    }

    /// <summary>
    ///     Get character by character auto complete suggestions.
    ///     Uses the default ESRI geolocation service.
    /// </summary>
    /// <param name="location">
    ///     Defines a normalized location point that is used to sort geocoding candidates based upon their
    ///     proximity to the given location.
    /// </param>
    /// <param name="text">
    ///     The input text entered by a user which is used by the suggest operation to generate a list of
    ///     possible matches.
    /// </param>
    /// <param name="categories">
    ///     A place or address type which can be used to filter suggest results. The parameter supports
    ///     input of single category values or multiple comma-separated values.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request 
    /// </param>
    public async Task<List<SuggestionResult>> SuggestLocations(Point location, string text,
        List<string>? categories = null, RequestOptions? requestOptions = null)
    {
        return await SuggestLocations(ESRIGeoLocationUrl, location, text, categories, requestOptions);
    }

    /// <summary>
    ///     Get character by character auto complete suggestions.
    /// </summary>
    /// <param name="url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name="location">
    ///     Defines a normalized location point that is used to sort geocoding candidates based upon their
    ///     proximity to the given location.
    /// </param>
    /// <param name="text">
    ///     The input text entered by a user which is used by the suggest operation to generate a list of
    ///     possible matches.
    /// </param>
    /// <param name="categories">
    ///     A place or address type which can be used to filter suggest results. The parameter supports
    ///     input of single category values or multiple comma-separated values.
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request 
    /// </param>
    public async Task<List<SuggestionResult>> SuggestLocations(string url, Point location, string text,
        List<string>? categories = null, RequestOptions? requestOptions = null)
    {
        return await InvokeAsync<List<SuggestionResult>>("suggestLocations", url, location, text,
            categories, requestOptions);
    }

    private static readonly string ESRIGeoLocationUrl =
        "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer";
}

/// <summary>
///     Describes the object representing the result of the Locator.SuggestLocations() method.
/// </summary>
/// <param name="IsCollection">
///     Indicates if the result is a Collection.
/// </param>
/// <param name="MagicKey">
///     ID used in combination with the text property to uniquely identify a suggestion.
/// </param>
/// <param name="Text">
///     The string name of the suggested location to geocode.
/// </param>
public record SuggestionResult(bool IsCollection, string MagicKey, string Text);

/// <summary>
///     Location types for the <see cref="Locator" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LocationType>))]
public enum LocationType
{
#pragma warning disable CS1591
    Street,
    Rooftop
#pragma warning restore CS1591
}

/// <summary>
///     An object with the following properties that describe the request.
///     <a target="_blank"
///        href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#RequestOptions">
///         ArcGIS JS
///         API
///     </a>
/// </summary>
public class RequestOptions
{
    /// <summary>
    ///     Indicates if and how requests to ArcGIS Services are authenticated. Only applicable when
    ///     esriConfig.request.useIdentity = true.
    ///     Default Value: auto
    /// </summary>
    public AuthMode? AuthMode { get; set; }

    /// <summary>
    ///     If uploading a file, specify the form data or element used to submit the file here. If specified, the parameters of
    ///     the query will be added to the URL.
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    ///     If true, the browser will send a request to the server instead of using the browser's local cache. If false, the
    ///     browser's default cache handling will be used.
    ///     Default value: false
    /// </summary>
    public bool? CacheBust { get; set; }

    /// <summary>
    ///     Headers to use for the request. This is an object whose property names are header names.
    /// </summary>
    public object? Headers { get; set; }

    /// <summary>
    ///     Indicates if the request should be made using the HTTP DELETE, HEAD, POST, or PUT method. By default, HTTP POST
    ///     will be used for auto if the request size is longer than the maxUrlLength property set in config.request.
    ///     Default Value: auto
    /// </summary>
    public RequestMethod? Method { get; set; }

    /// <summary>
    ///     Query parameters for the request. The query parameters will be added to the URL if a GET request is used, or if the
    ///     body property is set. If the body property is not set, the query parameters will be added to the request body when
    ///     a DELETE, POST, or PUT request is used.
    /// </summary>
    public Dictionary<string, object?>? Query { get; set; }

    /// <summary>
    ///     Response format. Default Value: json.
    /// </summary>
    public ResponseType? ResponseType { get; set; }

    /// <summary>
    ///     Indicates the amount of time in milliseconds to wait for a response from the server. Set to 0 to wait for the
    ///     response indefinitely.
    ///     Default Value: 60000
    /// </summary>
    public long? Timeout { get; set; }

    /// <summary>
    ///     Indicates the request should use the proxy. By default, this is determined automatically based on the domain of the
    ///     request URL.
    ///     Default Value: false
    /// </summary>
    public bool? UseProxy { get; set; }

    /// <summary>
    ///     Indicates the request should use the proxy. By default, this is determined automatically based on the domain of the
    ///     request URL.
    ///     Default Value: false
    /// </summary>
    public bool? WithCredentials { get; set; }
}

/// <summary>
///     Authentication modes for the <see cref="RequestOptions" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AuthMode>))]
public enum AuthMode
{
#pragma warning disable CS1591
    Auto,
    Anonymous,
    Immediate,
    NoPrompt
#pragma warning restore CS1591
}

/// <summary>
///     Request methods for the <see cref="RequestOptions" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RequestMethod>))]
public enum RequestMethod
{
#pragma warning disable CS1591
    Auto,
    Delete,
    Head,
    Post,
    Put
#pragma warning restore CS1591
}

/// <summary>
///     Response types for the <see cref="RequestOptions" /> class.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ResponseType>))]
public enum ResponseType
{
#pragma warning disable CS1591
    Json,
    Text,
    ArrayBuffer,
    Blob,
    Image,
    Native,
    Document,
    Xml
#pragma warning restore CS1591
}