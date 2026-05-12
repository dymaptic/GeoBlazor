// ReSharper disable MethodOverloadWithOptionalParameter
namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.LocationService.html">GeoBlazor Docs</a>
///     A convenience module for importing <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-locator.html">locator</a> functions when developing with
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/get-started/#typescript">TypeScript</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-locator.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class LocationService: LogicComponent
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    /// <param name="authenticationManager">
    ///     Injected Identity Manager reference
    /// </param>
    public LocationService(AuthenticationManager authenticationManager) : base(authenticationManager)
    {
    }

    /// <inheritdoc/>
    protected override string ComponentName => nameof(LocationService);

    private const string ESRIGeolocationUrl = "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer";
#region AddressesToLocationsWithAddress
    /// <summary>
    ///     Find address candidates for multiple input addresses.
    ///     Uses the default ESRI geolocation service.
    ///     Note: If using as API token: the token must have "Geocode (Stored)" enabled to get results
    /// </summary>
    /// <param name = "addresses">The input addresses in the format supported by the geocode service. </param>
    /// <param name = "countryCode">
    ///     Limits the results to only search in the country provided. For example US for United States or SE for Sweden. Only
    ///     applies to the World Geocode Service. See the World Geocoding Service documentation for more information.
    /// </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<List<AddressCandidate>> AddressesToLocations(List<Address> addresses, string? countryCode = null, List<string>? categories = null, LocationType? locationType = null, SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return await AddressesToLocations(ESRIGeolocationUrl, addresses, countryCode, categories, locationType, outSpatialReference, requestOptions, cancellationToken);
    }

    /// <summary>
    ///     Find address candidates for multiple input addresses.
    ///     Note: If using as API token: the token must have "Geocode (Stored)" enabled to get results
    /// </summary>
    /// <param name = "url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name = "addresses">The input addresses in the format supported by the geocode service. </param>
    /// <param name = "countryCode">
    ///     Limits the results to only search in the country provided. For example US for United States or SE for Sweden. Only
    ///     applies to the World Geocode Service. See the World Geocoding Service documentation for more information.
    /// </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [SerializedMethod]
    [CodeGenerationIgnore]
        public async Task<List<AddressCandidate>> AddressesToLocations(string url, List<Address> addresses, string? countryCode = null, List<string>? categories = null, LocationType? locationType = null, SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<List<AddressCandidate>>(nameof(AddressesToLocations).ToLowerFirstChar(), cancellationToken, url, addresses, countryCode, categories, locationType, outSpatialReference, requestOptions);
    }

#endregion
#region AddressesToLocationsWithString
    /// <summary>
    ///     Find address candidates for multiple input addresses.
    ///     Uses the default ESRI geolocation service.
    ///     Note: If using as API token: the token must have "Geocode (Stored)" enabled to get results
    /// </summary>
    /// <param name = "addresses">The input addresses in the format supported by the geocode service. </param>
    /// <param name = "countryCode">
    ///     Limits the results to only search in the country provided. For example US for United States or SE for Sweden. Only
    ///     applies to the World Geocode Service. See the World Geocoding Service documentation for more information.
    /// </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "addressSearchStringParameterName">
    ///     The name of the single line address field for the ArcGIS Locator Service (for ArcGIS 10+), defaults to 'address'.
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<List<AddressCandidate>> AddressesToLocations(List<string> addresses, string? countryCode = null, List<string>? categories = null, LocationType? locationType = null, SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null, string? addressSearchStringParameterName = null, CancellationToken cancellationToken = default)
    {
        return await AddressesToLocations(ESRIGeolocationUrl, addresses, countryCode, categories, locationType, outSpatialReference, requestOptions, addressSearchStringParameterName, cancellationToken);
    }

    /// <summary>
    ///     Find address candidates for multiple input addresses.
    ///     Note: If using as API token: the token must have "Geocode (Stored)" enabled to get results
    /// </summary>
    /// <param name = "url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name = "addresses">The input addresses in the format supported by the geocode service. </param>
    /// <param name = "countryCode">
    ///     Limits the results to only search in the country provided. For example US for United States or SE for Sweden. Only
    ///     applies to the World Geocode Service. See the World Geocoding Service documentation for more information.
    /// </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "addressSearchStringParameterName">
    ///     The name of the single line address field for the ArcGIS Locator Service (for ArcGIS 10+), defaults to 'address'.
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [SerializedMethod]
    [CodeGenerationIgnore]
        public async Task<List<AddressCandidate>> AddressesToLocations(string url, List<string> addresses, string? countryCode = null, List<string>? categories = null, LocationType? locationType = null, SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null, string? addressSearchStringParameterName = null, CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<List<AddressCandidate>>(nameof(AddressesToLocations).ToLowerFirstChar(), cancellationToken, url, addresses, countryCode, categories, locationType, outSpatialReference, requestOptions, addressSearchStringParameterName);
    }

#endregion
#region AddressToLocationsWithAddress
    /// <summary>
    ///     Sends a request to the ArcGIS REST geocode resource to find candidates for a single address specified in the
    ///     address parameter.
    ///     Uses the default ESRI geolocation service.
    /// </summary>
    /// <param name = "address">the various address fields accepted by the corresponding geocode service. </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "countryCode">
    ///     Limit result to a specific country. For example, "US" for United States or "SE" for Sweden.
    ///     Only applies to the World Geocode Service. See Geocode coverage (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "forStorage">Allows the results of single geocode transactions to be persisted.</param>
    /// <param name = "location">Used to weight returned results for a specified area.</param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "magicKey">A suggestLocations result ID (magicKey). Used to query for a specific results information.</param>
    /// <param name = "maxLocations">Maximum results to return from the query.</param>
    /// <param name = "outFields">
    ///     The list of fields included in the returned result set. This list is a comma delimited list of field names. If you
    ///     specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify
    ///     the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection
    ///     candidate fields.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "searchExtent">
    ///     Defines the extent within which the geocode server will search. Requires ArcGIS Server version 10.1 or greater.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<List<AddressCandidate>> AddressToLocations(Address address, List<string>? categories = null, string? countryCode = null, bool? forStorage = null, Point? location = null, LocationType? locationType = null, string? magicKey = null, int? maxLocations = null, List<string>? outFields = null, SpatialReference? outSpatialReference = null, Extent? searchExtent = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return await AddressToLocations(ESRIGeolocationUrl, address, categories, countryCode, forStorage, location, locationType, magicKey, maxLocations, outFields, outSpatialReference, searchExtent, requestOptions, cancellationToken);
    }

    /// <summary>
    ///     Sends a request to the ArcGIS REST geocode resource to find candidates for a single address specified in the
    ///     address parameter.
    /// </summary>
    /// <param name = "url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name = "address">the various address fields accepted by the corresponding geocode service. </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "countryCode">
    ///     Limit result to a specific country. For example, "US" for United States or "SE" for Sweden.
    ///     Only applies to the World Geocode Service. See Geocode coverage (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "forStorage">Allows the results of single geocode transactions to be persisted.</param>
    /// <param name = "location">Used to weight returned results for a specified area.</param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "magicKey">A suggestLocations result ID (magicKey). Used to query for a specific results information.</param>
    /// <param name = "maxLocations">Maximum results to return from the query.</param>
    /// <param name = "outFields">
    ///     The list of fields included in the returned result set. This list is a comma delimited list of field names. If you
    ///     specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify
    ///     the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection
    ///     candidate fields.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "searchExtent">
    ///     Defines the extent within which the geocode server will search. Requires ArcGIS Server version 10.1 or greater.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [SerializedMethod]
    [CodeGenerationIgnore]
        public async Task<List<AddressCandidate>> AddressToLocations(string url, Address address, List<string>? categories = null, string? countryCode = null, bool? forStorage = null, Point? location = null, LocationType? locationType = null, string? magicKey = null, int? maxLocations = null, List<string>? outFields = null, SpatialReference? outSpatialReference = null, Extent? searchExtent = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<List<AddressCandidate>>(nameof(AddressToLocations).ToLowerFirstChar(), cancellationToken, url, address, categories, countryCode, forStorage, location, locationType, magicKey, maxLocations, outFields, outSpatialReference, searchExtent, requestOptions);
    }

#endregion
#region AddressToLocationsWithString
    /// <summary>
    ///     Sends a request to the ArcGIS REST geocode resource to find candidates for a single address specified in the
    ///     address parameter.
    ///     Uses the default ESRI geolocation service.
    /// </summary>
    /// <param name = "address">the various address fields accepted by the corresponding geocode service. </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "countryCode">
    ///     Limit result to a specific country. For example, "US" for United States or "SE" for Sweden.
    ///     Only applies to the World Geocode Service. See Geocode coverage (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "forStorage">Allows the results of single geocode transactions to be persisted.</param>
    /// <param name = "location">Used to weight returned results for a specified area.</param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "magicKey">A suggestLocations result ID (magicKey). Used to query for a specific results information.</param>
    /// <param name = "maxLocations">Maximum results to return from the query.</param>
    /// <param name = "outFields">
    ///     The list of fields included in the returned result set. This list is a comma delimited list of field names. If you
    ///     specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify
    ///     the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection
    ///     candidate fields.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "searchExtent">
    ///     Defines the extent within which the geocode server will search. Requires ArcGIS Server version 10.1 or greater.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "addressSearchStringParameterName">
    ///     The name of the single line address field for the ArcGIS Locator Service (for ArcGIS 10+), defaults to 'address'.
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<List<AddressCandidate>> AddressToLocations(string address, List<string>? categories = null, string? countryCode = null, bool? forStorage = null, Point? location = null, LocationType? locationType = null, string? magicKey = null, int? maxLocations = null, List<string>? outFields = null, SpatialReference? outSpatialReference = null, Extent? searchExtent = null, RequestOptions? requestOptions = null, string? addressSearchStringParameterName = null, CancellationToken cancellationToken = default)
    {
        return await AddressToLocations(ESRIGeolocationUrl, address, categories, countryCode, forStorage, location, locationType, magicKey, maxLocations, outFields, outSpatialReference, searchExtent, requestOptions, addressSearchStringParameterName, cancellationToken);
    }

    /// <summary>
    ///     Sends a request to the ArcGIS REST geocode resource to find candidates for a single address specified in the
    ///     address parameter.
    /// </summary>
    /// <param name = "url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name = "address">the various address fields accepted by the corresponding geocode service. </param>
    /// <param name = "categories">
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food".
    ///     Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "countryCode">
    ///     Limit result to a specific country. For example, "US" for United States or "SE" for Sweden.
    ///     Only applies to the World Geocode Service. See Geocode coverage (World Geocoding Service) for more information.
    /// </param>
    /// <param name = "forStorage">Allows the results of single geocode transactions to be persisted.</param>
    /// <param name = "location">Used to weight returned results for a specified area.</param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "magicKey">A suggestLocations result ID (magicKey). Used to query for a specific results information.</param>
    /// <param name = "maxLocations">Maximum results to return from the query.</param>
    /// <param name = "outFields">
    ///     The list of fields included in the returned result set. This list is a comma delimited list of field names. If you
    ///     specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify
    ///     the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection
    ///     candidate fields.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "searchExtent">
    ///     Defines the extent within which the geocode server will search. Requires ArcGIS Server version 10.1 or greater.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "addressSearchStringParameterName">
    ///     The name of the single line address field for the ArcGIS Locator Service (for ArcGIS 10+), defaults to 'address'.
    /// </param>
    /// <param name = "cancellationToken">
    ///     The cancellation token to use for the asynchronous operation.
    /// </param>
    [SerializedMethod]
    [CodeGenerationIgnore]
        public async Task<List<AddressCandidate>> AddressToLocations(string url, string address, List<string>? categories = null, string? countryCode = null, bool? forStorage = null, Point? location = null, LocationType? locationType = null, string? magicKey = null, int? maxLocations = null, List<string>? outFields = null, SpatialReference? outSpatialReference = null, Extent? searchExtent = null, RequestOptions? requestOptions = null, string? addressSearchStringParameterName = null, CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<List<AddressCandidate>>(nameof(AddressToLocations).ToLowerFirstChar(), cancellationToken, url, address, categories, countryCode, forStorage, location, locationType, magicKey, maxLocations, outFields, outSpatialReference, searchExtent, requestOptions, addressSearchStringParameterName);
    }

#endregion
#region LocationToAddress
    /// <summary>
    ///     Locates an address based on a given point.
    ///     Uses the default ESRI geolocation service.
    /// </summary>
    /// <param name = "location">
    ///     The point at which to search for the closest address. The location should be in the same spatial reference as that
    ///     of the geocode service.
    /// </param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">The cancellation token to use for the operation.</param>
    [CodeGenerationIgnore]
    public Task<AddressCandidate> LocationToAddress(Point location, LocationType? locationType = null, SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return LocationToAddress(ESRIGeolocationUrl, location, locationType, outSpatialReference, requestOptions, cancellationToken);
    }

    /// <summary>
    ///     Locates an address based on a given point.
    /// </summary>
    /// <param name = "url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name = "location">
    ///     The point at which to search for the closest address. The location should be in the same spatial reference as that
    ///     of the geocode service.
    /// </param>
    /// <param name = "locationType">
    ///     Define the type of location, either "street" or "rooftop", of the point returned from the World Geocoding Service.
    /// </param>
    /// <param name = "outSpatialReference">
    ///     The spatial reference of the output geometries. If not specified, the output geometries are in the spatial
    ///     reference of the input geometries when performing a reverse geocode and in the default spatial reference returned
    ///     by the service if finding locations by address.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">The cancellation token to use for the operation.</param>
    [SerializedMethod]
    [CodeGenerationIgnore]
        public async Task<AddressCandidate> LocationToAddress(string url, Point location, LocationType? locationType = null, SpatialReference? outSpatialReference = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<AddressCandidate>(nameof(LocationToAddress).ToLowerFirstChar(), cancellationToken, url, location, locationType, outSpatialReference, requestOptions);
    }

#endregion
#region SuggestLocations
    /// <summary>
    ///     Get character by character auto complete suggestions.
    ///     Uses the default ESRI geolocation service.
    /// </summary>
    /// <param name = "location">
    ///     Defines a normalized location point that is used to sort geocoding candidates based upon their proximity to the
    ///     given location.
    /// </param>
    /// <param name = "text">
    ///     The input text entered by a user which is used by the suggest operation to generate a list of possible matches.
    /// </param>
    /// <param name = "categories">
    ///     A place or address type which can be used to filter suggest results. The parameter supports input of single
    ///     category values or multiple comma-separated values.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">The cancellation token.</param>
    [CodeGenerationIgnore]
    public Task<List<SuggestionResult>> SuggestLocations(Point location, string text, List<string>? categories = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return SuggestLocations(ESRIGeolocationUrl, location, text, categories, requestOptions, cancellationToken);
    }

    /// <summary>
    ///     Get character by character auto complete suggestions.
    /// </summary>
    /// <param name = "url">URL to the ArcGIS Server REST resource that represents a locator service.</param>
    /// <param name = "location">
    ///     Defines a normalized location point that is used to sort geocoding candidates based upon their proximity to the
    ///     given location.
    /// </param>
    /// <param name = "text">
    ///     The input text entered by a user which is used by the suggest operation to generate a list of possible matches.
    /// </param>
    /// <param name = "categories">
    ///     A place or address type which can be used to filter suggest results. The parameter supports input of single
    ///     category values or multiple comma-separated values.
    /// </param>
    /// <param name = "requestOptions">
    ///     Additional options to be used for the data request
    /// </param>
    /// <param name = "cancellationToken">The cancellation token.</param>
    [SerializedMethod]
    [CodeGenerationIgnore]
        public async Task<List<SuggestionResult>> SuggestLocations(string url, Point location, string text, List<string>? categories = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<List<SuggestionResult>>(nameof(SuggestLocations).ToLowerFirstChar(), cancellationToken, url, location, text, categories, requestOptions);
    }
#endregion
}