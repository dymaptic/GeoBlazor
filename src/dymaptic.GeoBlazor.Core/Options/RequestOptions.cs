namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     An object with the following properties that describe the request.
///     <a target="_blank"
///        href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#RequestOptions">
///         ArcGIS JS
///         API
///     </a>
/// </summary>
public record RequestOptions
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