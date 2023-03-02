using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A simple class for handling OAuth authentication.
/// </summary>
public class OAuthAuthentication : LogicComponent
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    /// <param name="jsRuntime">
    ///     Injected JavaScript Runtime reference
    /// </param>
    /// <param name="config">
    ///     Injected configuration object
    /// </param>
    public OAuthAuthentication(IJSRuntime jsRuntime, IConfiguration config) : base(jsRuntime, config)
    {
        _config = config;
#pragma warning disable CS4014
        if (!string.IsNullOrEmpty(AppId))
        {
            Initialize();
        }
#pragma warning restore CS4014
    }

    /// <inheritdoc />
    protected override string ComponentName => nameof(OAuthAuthentication);
    private string AppId => _config["ArcGISAppId"];

    /// <summary>
    ///     Initializes the OAuth Authentication component with the ArcGIS App ID.
    /// </summary>
    /// <returns></returns>
    public async Task Initialize()
    {
        if (_initializedAppId.Equals(AppId))
        {
            return;
        }

        await InvokeVoidAsync("initialize", AppId);
        _initializedAppId = AppId;
    }

    /// <summary>
    ///     Tests to see if the user is logged in. True if yes, false if otherwise.
    /// </summary>
    /// <returns>
    ///     Returns a boolean value indicating whether or not the user is logged in.
    /// </returns>
    public async Task<bool> IsLoggedIn()
    {
        await Initialize();

        return await InvokeAsync<bool>("isLoggedIn");
    }

    /// <summary>
    ///     Logs the user in.
    /// </summary>
    public async Task Login()
    {
        await Initialize();
        await InvokeVoidAsync("doLogin");
    }

    /// <summary>
    ///     Ensures that the user is logged in. If not, it will attempt to log them in.
    /// </summary>
    public async Task EnsureLoggedIn()
    {
        if (!await IsLoggedIn())
        {
            await Login();
        }
    }

    /// <summary>
    ///     Returns the current OAuth Token for use in requests.
    /// </summary>
    /// <returns>
    ///     A string containing the current OAuth Token.
    /// </returns>
    public async Task<string> GetCurrentToken()
    {
        await Initialize();

        return await InvokeAsync<string>("getToken");
    }

    private readonly IConfiguration _config;
    private string _initializedAppId = string.Empty;
}