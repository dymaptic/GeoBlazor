using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

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
            AuthenticationManager.ExcludeApiKey = false;
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
            AuthenticationManager.ExcludeApiKey = false;
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

        using HttpClient httpClient = new();
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

    /// <summary>
    ///     Client configuration response containing static keys.
    /// </summary>
    public record ClientConfigResponse(string? GeoBlazorLicenseKey, string? ArcGISApiKey, string? ArcGISPortalUrl, string? ArcGISAppId);
}