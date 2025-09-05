using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

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
                var fromConfig = _configuration["ArcGISPortalUrl"];
                _portalUrl = NormalizePortalUrl(fromConfig);
            }
            return _portalUrl;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _portalUrl = NormalizePortalUrl(value);
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
            string? apiKey = ExcludeApiKey ? null : ApiKey;
            await _module.InvokeVoidAsync("setApiKey", _cancellationTokenSource.Token, apiKey);
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
        if (!string.IsNullOrWhiteSpace(ApiKey) && !ExcludeApiKey)
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
        // TODO: In V5, we should remove this line and always throw the exception below, but that would be a breaking change. It is safe to throw below this because the JavaScript is throwing an exception anyways without the AppId being set.
        if (!string.IsNullOrWhiteSpace(ApiKey)) return true;

        if (string.IsNullOrWhiteSpace(AppId))
        {
            // If no AppId is provided, we cannot check if the user is logged in using Esri's logic.
            throw new InvalidOperationException("AuthenticationManager.IsLoggedIn() is for use with the ArcGISAppId and OAuth flows.");
        }

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
    /// Normalizes an ArcGIS portal base URL for use with the Sharing REST API.
    /// </summary>
    /// <param name="input">
    /// Portal host, e.g. "https://www.arcgis.com" or "https://your-host[/portal]".
    /// </param>
    /// <returns>
    /// For ArcGIS Online (hosts ending in arcgis.com): removes any trailing "/portal".
    /// For ArcGIS Enterprise: ensures exactly one trailing "/portal".
    /// If null/blank, defaults to "https://www.arcgis.com".
    /// </returns>
    /// <remarks>
    /// Esri references:
    /// <see href="https://developers.arcgis.com/rest/users-groups-and-items/">Sharing REST</see>,
    /// <see href="https://developers.arcgis.com/rest/users-groups-and-items/generate-token/">Generate Token</see>.
    /// Result is intended to be combined with "/sharing" or "/sharing/rest".
    /// </remarks>
    /// <example>
    /// NormalizePortalUrl("https://www.arcgis.com/portal") → "https://www.arcgis.com"
    /// NormalizePortalUrl("https://arcgis.example.com")     → "https://arcgis.example.com/portal"
    /// </example>
    private static string? NormalizePortalUrl(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "https://www.arcgis.com";

        // normalize whitespace and trailing slashes
        var trimmed = input.Trim().TrimEnd('/');

        // Try to parse the URI so we can reliably detect Online vs Enterprise
        if (Uri.TryCreate(trimmed, UriKind.Absolute, out var uri))
        {
            bool isArcGisOnline = uri.Host.EndsWith("arcgis.com", StringComparison.OrdinalIgnoreCase);
            var noTrailing = trimmed;

            if (isArcGisOnline)
            {
                // AGOL: ensure NO trailing "/portal"
                return Regex.Replace(noTrailing, @"/portal$", "", RegexOptions.IgnoreCase);
            }

            // Enterprise: ensure exactly one trailing "/portal"
            return Regex.IsMatch(noTrailing, @"/portal$", RegexOptions.IgnoreCase)
                ? noTrailing
                : noTrailing + "/portal";
        }

        // Fallback if not a valid absolute URI (keep same rules heuristically)
        bool looksOnline = trimmed.IndexOf("arcgis.com", StringComparison.OrdinalIgnoreCase) >= 0;
        if (looksOnline)
        {
            return Regex.Replace(trimmed, @"/portal$", "", RegexOptions.IgnoreCase);
        }
        return Regex.IsMatch(trimmed, @"/portal$", RegexOptions.IgnoreCase)
            ? trimmed
            : trimmed + "/portal";
    }

    /// <summary>
    ///     Allows the user to prevent the ApiKey from being used in the authentication process for the current MapView.
    ///     This value is copied from MapView.ExcludeApiKey, and will be reset (default to false) when a new MapView is created.
    ///     Part of the workaround for https://my.esri.com/#/support/bugs/bugs?bugNumber=BUG-000174423 
    /// </summary>
    public bool ExcludeApiKey { get; set; }

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