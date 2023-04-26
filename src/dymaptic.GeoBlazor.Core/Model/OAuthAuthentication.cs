using dymaptic.GeoBlazor.Core.Exceptions;
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
    }

    /// <inheritdoc />
    protected override string ComponentName => nameof(OAuthAuthentication);
    private string? AppId => _config["ArcGISAppId"];
    

    /// <summary>
    ///     Tests to see if the user is logged in. True if yes, false if otherwise.
    /// </summary>
    /// <returns>
    ///     Returns a boolean value indicating whether or not the user is logged in.
    /// </returns>
    public async Task<bool> IsLoggedIn()
    {
        return await InvokeAsync<bool>("isLoggedIn");
    }

    /// <summary>
    ///     Logs the user in.
    /// </summary>
    public async Task Login()
    {
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
        return await InvokeAsync<string>("getToken");
    }

    /// <inheritdoc />
    public override async Task Initialize()
    {
        if (Component is null)
        {
            IJSObjectReference module = await GetArcGisJsInterop();

            Component = await module.InvokeAsync<IJSObjectReference>($"get{ComponentName}Wrapper",
                CancellationTokenSource.Token, DotNetObjectReference, AppId);
        }
        
        if (string.IsNullOrEmpty(AppId))
        {
            throw new MissingAppIdException();
        } 
        if (_initializedAppId.Equals(AppId))
        {
            return;
        }
        
        _initializedAppId = AppId;
        Console.WriteLine("Initialized OAuth");
    }

    private readonly IConfiguration _config;
    private string _initializedAppId = string.Empty;
}