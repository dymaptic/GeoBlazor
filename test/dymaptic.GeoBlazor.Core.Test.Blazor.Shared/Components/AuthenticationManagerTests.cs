using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

    /*
     * -------------------------------------------------------------------------
     *  CONFIGURATION SETUP (appsettings.json / user-secrets / CI env vars)
     * -------------------------------------------------------------------------
     * These tests read the following keys from IConfiguration:
     *
     *   TestPortalAppId          -> App ID registered in your Enterprise Portal
     *   TestPortalUrl            -> Your Portal base URL (either https://host OR https://host/portal)
     *   TestPortalClientSecret   -> Client secret for the Portal app registration
     *
     *   TestAGOAppId             -> App ID registered in ArcGIS Online
     *   TestAGOUrl               -> ArcGIS Online base URL (use https://www.arcgis.com)
     *   TestAGOClientSecret      -> Client secret for the AGOL app registration
     *
     *   TestApplicationBaseUrl   -> (Optional) Base address for local HTTP calls if needed
     *
     * NOTES:
     * - You need SEPARATE app registrations for AGOL and for Enterprise Portal if you test both.
     * - For AGOL, use TestAGOUrl = https://www.arcgis.com   (do NOT append /portal)
     * - For Enterprise, TestPortalUrl can be either https://yourserver OR https://yourserver/portal
     *   (AuthenticationManager will normalize it to the correct format internally.)
     *
     * Recommended: keep secrets out of source control using .NET user-secrets:
     *
     *   dotnet user-secrets init
     *   dotnet user-secrets set "TestPortalAppId" "<your-portal-app-id>"
     *   dotnet user-secrets set "TestPortalUrl" "https://yourserver/portal"
     *   dotnet user-secrets set "TestPortalClientSecret" "<your-portal-secret>"
     *
     *   dotnet user-secrets set "TestAGOAppId" "<your-agol-app-id>"
     *   dotnet user-secrets set "TestAGOUrl" "https://www.arcgis.com"
     *   dotnet user-secrets set "TestAGOClientSecret" "<your-agol-secret>"
     *
     * Example appsettings.Development.json (non-secret values only):
     * {
     *   "TestPortalUrl": "https://yourserver/portal",
     *   "TestAGOUrl": "https://www.arcgis.com",
     *   "TestApplicationBaseUrl": "https://localhost:7143"
     * }
     *
     * In CI, set these as environment variables instead:
     *   TestPortalAppId, TestPortalUrl, TestPortalClientSecret,
     *   TestAGOAppId, TestAGOUrl, TestAGOClientSecret, TestApplicationBaseUrl
     *
     * -------------------------------------------------------------------------
     */

public class AuthenticationManagerTests: TestRunnerBase
{
    [Inject]
    public required AuthenticationManager AuthenticationManager { get; set; }

    [Inject]
    public required IConfiguration Configuration { get; set; }

    [TestMethod]
    public async Task TestRegisterOAuthWithArcGISPortal()
    {
        AuthenticationManager.ExcludeApiKey = true;
        try
        {
            AuthenticationManager.AppId = Configuration["TestPortalAppId"];
            AuthenticationManager.PortalUrl = Configuration["TestPortalUrl"];

            TokenResponse tokenResponse = await RequestTokenAsync(Configuration["TestPortalClientSecret"]!);
            Assert.IsTrue(tokenResponse.Success, tokenResponse.ErrorMessage);

            await AuthenticationManager.RegisterToken(tokenResponse.AccessToken!, tokenResponse.Expires!.Value);

            string? retrievedToken = await AuthenticationManager.GetCurrentToken();
            Assert.AreEqual(tokenResponse.AccessToken, retrievedToken);

            AuthenticationManager.TokenExpirationDateTime = null;
            DateTime? expired = await AuthenticationManager.GetTokenExpirationDateTime();
            Assert.IsNotNull(expired);
            Assert.AreEqual(tokenResponse.Expires, expired);
        }
        finally
        {
            // reset all mutated state
            AuthenticationManager.ExcludeApiKey = false;
            AuthenticationManager.TokenExpirationDateTime = null;
            AuthenticationManager.AppId = null;
            AuthenticationManager.PortalUrl = null;
        }
    }

    [TestMethod]
    public async Task TestRegisterOAuthWithArcGISOnline()
    {
        AuthenticationManager.ExcludeApiKey = true;

        try
        {
            AuthenticationManager.AppId = Configuration["TestAGOAppId"];
            AuthenticationManager.PortalUrl = Configuration["TestAGOUrl"];

            TokenResponse tokenResponse = await RequestTokenAsync(Configuration["TestAGOClientSecret"]!);
            Assert.IsTrue(tokenResponse.Success, tokenResponse.ErrorMessage);

            await AuthenticationManager.RegisterToken(tokenResponse.AccessToken!, tokenResponse.Expires!.Value);

            string? retrievedToken = await AuthenticationManager.GetCurrentToken();
            Assert.AreEqual(tokenResponse.AccessToken, retrievedToken);

            AuthenticationManager.TokenExpirationDateTime = null;
            DateTime? expired = await AuthenticationManager.GetTokenExpirationDateTime();
            Assert.IsNotNull(expired);
            Assert.AreEqual(tokenResponse.Expires, expired);
        }
        finally
        {
            // reset all mutated state
            AuthenticationManager.ExcludeApiKey = false;
            AuthenticationManager.TokenExpirationDateTime = null;
            AuthenticationManager.AppId = null;
            AuthenticationManager.PortalUrl = null;
        }
    }

    /// <summary>
    ///     Requests a new ArcGIS token using client credentials.
    /// </summary>
    private async Task<TokenResponse> RequestTokenAsync(string clientSecret)
    {
        var tokenUrlBase = AuthenticationManager.PortalUrl;
        var tokenUrl = $"{tokenUrlBase}/sharing/rest/oauth2/token";

        var parameters = new Dictionary<string, string>
        {
            { "f", "json" },
            { "client_id", AuthenticationManager.AppId! },
            { "client_secret", clientSecret },
            { "grant_type", "client_credentials" },
            { "expiration", "1440" }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl)
        {
            Content = new FormUrlEncodedContent(parameters)
        };

        using HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(Configuration["TestApplicationBaseUrl"] ?? "https://localhost:7143")
        };

        HttpResponseMessage response = await httpClient.SendAsync(request);

        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return new TokenResponse(false, null, null,
                "Request failed with status code: " + response.StatusCode);
        }

        ArcGisError? errorCheck = JsonSerializer.Deserialize<ArcGisError>(content);
        if (errorCheck?.Error != null)
        {
            return new TokenResponse(false, null, null,
                $"Error {errorCheck.Error.Code}: {errorCheck.Error.Message}");
        }

        ArcGISTokenResponse? token = JsonSerializer.Deserialize<ArcGISTokenResponse>(content);
        if (token?.AccessToken == null)
        {
            return new TokenResponse(false, null, null, "Please verify your ArcGISAppId, ArcGISClientSecret, and ArcGISPortalUrl values.");
        }

        TokenResponse tokenResponse = new TokenResponse(true, token.AccessToken,
            DateTimeOffset.FromUnixTimeSeconds(token.ExpiresIn).UtcDateTime);
        return tokenResponse;
    }
    
    /// <summary>
    ///     The response from the request for an ArcGIS token, including success notification and error messages.
    /// </summary>
    public record TokenResponse(bool Success, string? AccessToken, DateTime? Expires, string? ErrorMessage = null);

    /// <summary>
    ///     JSON representation of the ArcGIS token response.
    /// </summary>
    public record ArcGISTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; init; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; init; }
    }

    /// <summary>
    ///     JSON representation of an error response from the ArcGIS API.
    /// </summary>
    public record ArcGisError(ErrorDetails? Error);

    public record ErrorDetails(int Code, string? Message);
}