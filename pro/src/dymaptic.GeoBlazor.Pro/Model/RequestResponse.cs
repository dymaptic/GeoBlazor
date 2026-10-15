namespace dymaptic.GeoBlazor.Pro.Model;


/// <summary>
///     Models the response from a request to an ArcGIS REST API endpoint. The data type will depend on the endpoint and the specified responseType in the request options. Possible types are: json, text, array-buffer, blob, image, native, document, and xml.
/// </summary>
public partial record RequestResponse;

// Empty stub consumed by RequestResponse.gb.cs; CodeGen rule will replace with FeatureLayerMetadata in a follow-up.
/// <summary>
///     Models the data returned from a request to an ArcGIS REST API endpoint. The data type will depend on the endpoint and the specified responseType in the request options. Possible types are: json, text, array-buffer, blob, image, native, document, and xml.
/// </summary>
public partial record RequestResponseData;

/// <summary>
///     Returns a promise that resolves to an object with the following specification. If the request returns an Error, the error object will include the details specified in EsriErrorDetails.
/// </summary>
/// <param name="Data">
///     The requested data. Should match the responseType with the data return type. Possible types are: json, text, array-buffer, blob, image, native, document, and xml.
/// </param>
/// <param name="HttpStatus">
///     The status code of the http response.
/// </param>
/// <param name="RequestOptions">
///     The options specified by the user in the data request. See <see cref="RequestOptions"/> for available properties.
/// </param>
/// <param name="Ssl">
///     Indicates if the request required https.
/// </param>
/// <param name="Url">
///     The URL used to request the data.
/// </param>
/// <typeparam name="T">
///     The type of expected Response Data to deserialize.
/// </typeparam>
public record RequestResponse<T>(T? Data, int? HttpStatus, RequestOptions? RequestOptions, bool? Ssl, string? Url);
