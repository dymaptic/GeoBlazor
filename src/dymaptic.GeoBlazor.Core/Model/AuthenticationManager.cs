using dymaptic.GeoBlazor.Core.Components.Views;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Manager for all authentication-related tasks, tokens, and keys
/// </summary>
public class AuthenticationManager
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    /// <param name="jsRuntime">
    ///     Injected JavaScript Runtime reference
    /// </param>
    /// <param name="configuration">
    ///     Injected configuration object
    /// </param>
    public AuthenticationManager(IJSRuntime jsRuntime, IConfiguration configuration)
    {
        _jsRuntime = jsRuntime;
        _configuration = configuration;
    }

    /// <summary>
    ///     Get or set the OAuth App ID.
    /// </summary>
    public string? AppId
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_appId))
            {
                _appId = _configuration["ArcGISAppId"];
            }

            return _appId;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _appId = value;
            }
        }
    }

    /// <summary>
    ///     The ArcGIS Enterprise Portal URL, only required if using Enterprise authentication.
    /// </summary>
    public string? PortalUrl
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_portalUrl))
            {
                _portalUrl = _configuration["ArcGISPortalUrl"];
            }

            return _portalUrl;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _portalUrl = value;
            }
        }
    }

    /// <summary>
    ///     Get or set the ArcGIS Application Api Key.
    /// </summary>
    public string? ApiKey
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                _apiKey = _configuration["ArcGISApiKey"];
            }

            return _apiKey;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _apiKey = value;
            }
        }
    }

    /// <summary>
    ///     Get or set the ArcGIS Application Trusted Servers.
    /// </summary>
    public List<string>? TrustedServers
    {
        get
        {
            _trustedServers ??= _configuration.GetSection("TrustedServers").Get<List<string>>();

            return _trustedServers;
        }
        set
        {
            if (value is not null)
            {
                _trustedServers = value;
            }
        }
    }

    /// <summary>
    ///     Initializes authentication based on either an OAuth App ID or an API Key. This is called automatically by <see cref="MapView" /> on first render, but can also be called manually for other actions such as rest calls.
    /// </summary>
    public async Task<bool> Initialize()
    {
        if (_module is null)
        {
            IJSObjectReference arcGisJsInterop = await GetArcGisJsInterop();

            _module = await arcGisJsInterop.InvokeAsync<IJSObjectReference>("getAuthenticationManager",
                _cancellationTokenSource.Token, DotNetObjectReference.Create(this), ApiKey, AppId, PortalUrl, TrustedServers);
        }

        return true;
    }

    /// <summary>
    ///     Initiates an OAuth login flow
    /// </summary>
    public async Task Login()
    {
        await Initialize();
        await _module!.InvokeVoidAsync("doLogin");
    }

    /// <summary>
    ///     Provides an implementation-agnostic way to fetch the current authentication token, whether it's an OAuth token or an API Key
    /// </summary>
    public async Task<string?> GetCurrentToken()
    {
        if (!string.IsNullOrWhiteSpace(ApiKey))
        {
            return ApiKey;
        }

        await Initialize();

        return await _module!.InvokeAsync<string?>("getToken");
    }

    /// <summary>
    ///     Tests to see if the user is logged in. True if yes, false if otherwise.
    /// </summary>
    /// <returns>
    ///     Returns a boolean value indicating whether or not the user is logged in.
    /// </returns>
    public async Task<bool> IsLoggedIn()
    {
        if (!string.IsNullOrWhiteSpace(ApiKey)) return true;

        await Initialize();

        return await _module!.InvokeAsync<bool>("isLoggedIn");
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
    ///     Retrieves the correct copy of the ArcGisJsInterop based on the nuget package
    /// </summary>
    public async Task<IJSObjectReference> GetArcGisJsInterop()
    {
        LicenseType licenseType = Licensing.GetLicenseType();

        var token = new CancellationToken();
        IJSObjectReference? arcGisPro = await JsModuleManager.GetArcGisJsPro(_jsRuntime, token);
        IJSObjectReference arcGisJsInterop = await JsModuleManager.GetArcGisJsCore(_jsRuntime, arcGisPro, token);
        
        return arcGisJsInterop;
    }

    private readonly IJSRuntime _jsRuntime;
    private readonly IConfiguration _configuration;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private string? _appId;
    private string? _apiKey;
    private List<string>? _trustedServers;
    private string? _portalUrl;
    private IJSObjectReference? _module;
}