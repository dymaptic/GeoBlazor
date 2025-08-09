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
    /// <param name="jsModuleManager">
    ///     Injected JavaScript Module Manager reference
    /// </param>
    /// <param name="configuration">
    ///     Injected configuration object
    /// </param>
    public AuthenticationManager(IJSRuntime jsRuntime, JsModuleManager jsModuleManager, IConfiguration configuration)
    {
        _jsRuntime = jsRuntime;
        _jsModuleManager = jsModuleManager;
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
            _trustedServers ??= _configuration.GetSection("ArcGISTrustedServers").Get<List<string>>();

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
    ///     Get or set the ArcGIS Fonts URL. This would only be used in disconnected scenarios where you want to point to a local ArcGIS Portal.
    /// </summary>
    public string? FontsUrl
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_fontsUrl))
            {
                _fontsUrl = _configuration["ArcGISFontsUrl"];
            }

            return _fontsUrl;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _fontsUrl = value;
            }
        }
    }
    
    /// <summary>
    ///     The expiration date and time of the current token. This is used to determine when the token should be refreshed or removed. If the token is an API Key, this will be null.
    /// </summary>
    public DateTime? TokenExpirationDateTime { get; set; }

    /// <summary>
    ///     Initializes authentication based on either an OAuth App ID or an API Key. This is called automatically by <see cref="MapView" /> on first render, but can also be called manually for other actions such as rest calls.
    /// </summary>
    public async Task<bool> Initialize()
    {
        if (_module is null)
        {
            IJSObjectReference arcGisJsInterop = await GetArcGisJsInterop();

            _module = await arcGisJsInterop.InvokeAsync<IJSObjectReference>("getAuthenticationManager",
                _cancellationTokenSource.Token, DotNetObjectReference.Create(this), ApiKey, AppId, PortalUrl, 
                TrustedServers, FontsUrl);
        }

        // since we have to remove the ApiKey for some public WebMaps, this re-adds it for each new map view.
        if (ApiKey is not null)
        {
            await _module.InvokeVoidAsync("setApiKey", _cancellationTokenSource.Token, ApiKey);
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
    ///     Logs the user out of the current session, clearing any stored tokens or keys, and reloads the page to reflect the changes.
    /// </summary>
    public async Task Logout()
    {
        if (await IsLoggedIn() != true)
        {
            return;
        }

        await _module!.InvokeVoidAsync("doLogout");
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
        IJSObjectReference? arcGisPro = await _jsModuleManager.GetArcGisJsPro(_jsRuntime, CancellationToken.None);
        IJSObjectReference arcGisJsInterop = await _jsModuleManager.GetArcGisJsCore(_jsRuntime, arcGisPro, CancellationToken.None);
        
        return arcGisJsInterop;
    }

    /// <summary>
    ///     Registers the given OAuth 2.0 access token or ArcGIS Server token with the AuthenticationManager. The RegisterToken method is an advanced workflow for pre-registering long-term tokens for when you don't want users to sign in. See <a target="_blank" href="https://docs.geoblazor.com/pages/authentication.html#app-authentication">App Authentication</a> for more information.
    /// </summary>
    /// <param name="token">
    ///     The access token.
    /// </param>
    /// <param name="expires">
    ///     The expiration date and time of the token. This is used to determine when the token should be refreshed or removed.
    /// </param>
    public async Task RegisterToken(string token, DateTimeOffset expires)
    {
        await Initialize();
        TokenExpirationDateTime = expires.DateTime;
        await _module!.InvokeVoidAsync("registerToken", token, expires.ToUnixTimeMilliseconds());
    }
    
    /// <summary>
    ///     Retrieves the expiration date and time of the current token. This is used to determine when the token should be refreshed or removed. If the token is an API Key, this will always return null.
    /// </summary>
    public async Task<DateTime?> GetTokenExpirationDateTime()
    {
        if (TokenExpirationDateTime is not null)
        {
            return TokenExpirationDateTime;
        }
        await Initialize();
        long? expiresInMilliseconds = await _module!.InvokeAsync<long?>("getTokenExpires");
        if (expiresInMilliseconds is not null)
        {
            TokenExpirationDateTime = DateTimeOffset.FromUnixTimeMilliseconds(expiresInMilliseconds.Value).UtcDateTime;
        }
        
        return TokenExpirationDateTime;
    }

    /// <summary>
    ///     Removes the current global API Key from the AuthenticationManager. This is useful for the bug where some public WebMaps require the API Key to be removed before they can be displayed.
    /// </summary>
    internal async Task RemoveApiKey()
    {
        await _module!.InvokeVoidAsync("removeApiKey");    
    }

    private readonly IJSRuntime _jsRuntime;
    private readonly JsModuleManager _jsModuleManager;
    private readonly IConfiguration _configuration;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private string? _appId;
    private string? _apiKey;
    private List<string>? _trustedServers;
    private string? _portalUrl;
    private IJSObjectReference? _module;
    private string? _fontsUrl;
}