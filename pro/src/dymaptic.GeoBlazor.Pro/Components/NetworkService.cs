namespace dymaptic.GeoBlazor.Pro.Components;

public partial class NetworkService : ProLogicComponent
{
    /// <inheritdoc/>
    public NetworkService(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, IAppValidator appValidator, IJSRuntime jsRuntime) : base(authenticationManager, jsModuleManager, appValidator, jsRuntime)
    {
    }

    /// <summary>
    ///     Retrieve a description of the network service.
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a network analysis service.
    /// </param>
    /// <param name="apiKey">
    ///     An authorization string used to access a resource or service (see API keys).
    /// </param>
    /// <param name="requestOptions">
    ///     Additional options to be used for the data request.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<ServiceDescription> FetchServiceDescription(string url, string? apiKey = null, RequestOptions? requestOptions = null)
    {
        apiKey ??= AuthenticationManager.ApiKey;
        return await InvokeAsync<ServiceDescription>("fetchServiceDescription", url, apiKey, requestOptions);
    }

    /// <inheritdoc/>
    protected override string ComponentName => nameof(NetworkService);
    /// <inheritdoc/>
    protected override string Library => "Pro";
}