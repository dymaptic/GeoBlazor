using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;
using Microsoft.JSInterop;
using System.Collections.Concurrent;
using System.Text.Json;

namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Services;

/// <summary>
/// Service for managing authentication tokens for multiple ArcGIS portals simultaneously.
/// </summary>
public class MultiPortalService
{
    public MultiPortalService(HttpClient httpClient, IConfiguration configuration,
        AuthenticationManager authenticationManager)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _authenticationManager = authenticationManager;
    }

    /// <summary>
    /// Register mappings of portal items to their respective portals.
    /// </summary>
    public void RegisterPortalItemMappings(Dictionary<string, string> mappings)
    {
        foreach (var mapping in mappings)
        {
            _portalItemMappings[mapping.Key] = NormalizePortalUrl(mapping.Value);
        }
    }

    /// <summary>
    /// Get or request a token for a specific portal.
    /// </summary>
    public async Task<TokenResponse> GetTokenForPortalAsync(string portalUrl)
    {
        await _semaphore.WaitAsync();
        try
        {
            portalUrl = NormalizePortalUrl(portalUrl);

            // Check cached token
            if (_portalTokens.TryGetValue(portalUrl, out var cachedToken))
            {
                if (cachedToken.Expires > DateTimeOffset.UtcNow.AddMinutes(5))
                {
                    return cachedToken;
                }
            }

            // Request new token
            var token = await RequestPortalTokenAsync(portalUrl);
            if (token.Success)
            {
                _portalTokens[portalUrl] = token;

                // Register with JavaScript IdentityManager
                await RegisterTokenWithIdentityManager(token.AccessToken!,
                    token.Expires!.Value, portalUrl);
            }

            return token;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private async Task<TokenResponse> RequestPortalTokenAsync(string portalUrl)
    {
        try
        {
            // Determine which credentials to use
            bool isAGOL = portalUrl.Contains("arcgis.com");
            string clientId = isAGOL
                ? _configuration["ArcGISAppId"] ?? ""
                : _configuration["EnterpriseAppId"] ?? "";
            string clientSecret = isAGOL
                ? _configuration["ArcGISClientSecret"] ?? ""
                : _configuration["EnterpriseClientSecret"] ?? "";

            var tokenUrl = $"{portalUrl}/sharing/rest/oauth2/token";
            var parameters = new Dictionary<string, string>
              {
                  { "f", "json" },
                  { "client_id", clientId },
                  { "client_secret", clientSecret },
                  { "grant_type", "client_credentials" },
                  { "expiration", "1440" }
              };

            var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl)
            {
                Content = new FormUrlEncodedContent(parameters)
            };

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new TokenResponse(false, null, null,
                    $"Request failed for {portalUrl}: {response.StatusCode}");
            }

            var tokenResponse = JsonSerializer.Deserialize<ArcGISTokenResponse>(content);
            if (tokenResponse?.AccessToken == null)
            {
                return new TokenResponse(false, null, null,
                    $"Invalid response from {portalUrl}");
            }

            return new TokenResponse(true, tokenResponse.AccessToken,
                DateTimeOffset.UtcNow.AddSeconds(tokenResponse.ExpiresIn));
        }
        catch (Exception ex)
        {
            return new TokenResponse(false, null, null,
                $"Exception for {portalUrl}: {ex.Message}");
        }
    }

    private async Task RegisterTokenWithIdentityManager(string token,
        DateTimeOffset expires, string portalUrl)
    {
        var jsInterop = await _authenticationManager.GetArcGisJsInterop();
        await jsInterop.InvokeVoidAsync("registerPortalToken", token, expires.ToUnixTimeMilliseconds(), portalUrl);

    }

    private string NormalizePortalUrl(string url)
    {
        url = url.Trim().TrimEnd('/');

        if (url.Contains("arcgis.com") && url.EndsWith("/portal"))
        {
            url = url.Substring(0, url.Length - 7);
        }
        else if (!url.Contains("arcgis.com") && !url.EndsWith("/portal"))
        {
            url += "/portal";
        }

        return url;
    }


    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly AuthenticationManager _authenticationManager;
    private readonly ConcurrentDictionary<string, TokenResponse> _portalTokens = new();
    private readonly Dictionary<string, string> _portalItemMappings = new();
    private readonly SemaphoreSlim _semaphore = new(1, 1);
}
