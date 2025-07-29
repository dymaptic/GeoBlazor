using System.Text.Json.Serialization;

using System.Text.Json;
namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Components;

/// <summary>
///     Service for managing ArcGIS authentication tokens.
/// </summary>
public class ArcGisAuthService(HttpClient httpClient, IConfiguration config)
{
    /// <summary>
    ///     Requests a new ArcGIS token or retrieves a cached one if available and not expired.
    /// </summary>
    public async Task<TokenResponse> GetTokenAsync(bool forceRefresh)
    {
        if (!forceRefresh)
        {
            TokenResponse? cachedToken = await GetCachedTokenAsync();
            if (cachedToken != null)
            {
                return cachedToken;
            }
        }

        return await RequestTokenAsync();
    }

    /// <summary>
    ///     Retrieves a cached ArcGIS token if it exists and is not expired.
    /// </summary>
    private async Task<TokenResponse?> GetCachedTokenAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            string? cacheFilePath = config["ArcGISAppTokenCacheFile"];
            if (!File.Exists(cacheFilePath))
            {
                return null;
            }

            string json = await File.ReadAllTextAsync(cacheFilePath);
            TokenResponse? token = JsonSerializer.Deserialize<TokenResponse>(json);

            if (token is null || token.Expires <= DateTimeOffset.UtcNow)
            {
                return null;
            }

            return token;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <summary>
    ///     Caches the provided ArcGIS token to a file.
    /// </summary>
    private async Task CacheTokenAsync(TokenResponse token)
    {
        string json = JsonSerializer.Serialize(token);

        await _semaphore.WaitAsync();
        try
        {
            await File.WriteAllTextAsync(config["ArcGISAppTokenCacheFile"]!, json);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <summary>
    ///     Requests a new ArcGIS token using client credentials.
    /// </summary>
    private async Task<TokenResponse> RequestTokenAsync()
    {
        var tokenUrl = "https://arcgis.dymaptic.com/portal/sharing/rest/oauth2/token";

        var parameters = new Dictionary<string, string>
        {
            { "f", "json" },
            { "client_id", config["ArcGISAppId"] ?? "" },
            { "client_secret", config["ArcGISClientSecret"] ?? "" },
            { "grant_type", "client_credentials" },
            { "expiration", config["ArcGISTokenExpirationMinutes"] ?? "1440" }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl)
        {
            Content = new FormUrlEncodedContent(parameters)
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
            return new TokenResponse(false, null, null, "Access token is null in response");
        }

        TokenResponse tokenResponse = new TokenResponse(true, token.AccessToken,
            DateTimeOffset.UtcNow.AddSeconds(token.ExpiresIn));
        await CacheTokenAsync(tokenResponse);
        return tokenResponse;
    }

    private static readonly SemaphoreSlim _semaphore = new(1, 1);
}

/// <summary>
///     The response from the request for an ArcGIS token, including success notification and error messages.
/// </summary>
public record TokenResponse(bool Success, string? AccessToken, DateTimeOffset? Expires, string? ErrorMessage = null);

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