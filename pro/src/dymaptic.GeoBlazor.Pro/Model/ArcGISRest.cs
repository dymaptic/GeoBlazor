namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     Provides access to the ArcGIS REST API via JavaScript. This class is a work in progress, only QueryDemographicData is currently implemented.
/// </summary>
[CodeGenerationIgnore]
public class ArcGISRest : ProLogicComponent
{
    /// <summary>
    ///     Public constructor for Dependency Injection
    /// </summary>
    public ArcGISRest(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, 
        IAppValidator appValidator, IJSRuntime jsRuntime) : 
        base(authenticationManager, jsModuleManager, appValidator, jsRuntime)
    {
    }

    /// <inheritdoc />
    protected override string ComponentName => "ArcGisRest";
    
    /// <inheritdoc />
    protected override string Library => "Pro";

    /// <summary>
    ///     Queries demographic data for the given point, and returns a list of features at that point.
    /// </summary>
    /// <param name="mapPoint">
    ///     The point to query.
    /// </param>
    public async Task<Graphic[]> QueryDemographicData(Point mapPoint)
    {
        return await InvokeAsync<Graphic[]>("queryDemographicData", mapPoint);
    }

    /// <summary>
    ///     Retrieves data from a remote server or uploads a file from a user's computer. If the request returns an Error, the error object will include the details specified in EsriErrorDetails.
    /// </summary>
    /// <param name="url">
    ///     The URL to request data from.
    /// </param>
    /// <param name="options">
    ///     The options specified by the user in the data request. See <see cref="RequestOptions"/> for available properties.
    /// </param>
    public async Task<RequestResponse<Dictionary<string, object?>>> Request(string url, RequestOptions options)
    {
        return await InvokeAsync<RequestResponse<Dictionary<string, object?>>>("request", url, options);
    }
    
    /// <summary>
    ///    Retrieves data from a remote server or uploads a file from a user's computer. If the request returns an Error, the error object will include the details specified in EsriErrorDetails.
    /// </summary>
    /// <param name="url">
    ///     The URL to request data from.
    /// </param>
    /// <param name="options">
    ///     The options specified by the user in the data request. See <see cref="RequestOptions"/> for available properties.
    /// </param>
    /// <typeparam name="T">
    ///     The type of expected Response Data to deserialize.
    /// </typeparam>
    public async Task<RequestResponse<T>> Request<T>(string url, RequestOptions options)
    {
        return await InvokeAsync<RequestResponse<T>>("request", url, options);
    }
}