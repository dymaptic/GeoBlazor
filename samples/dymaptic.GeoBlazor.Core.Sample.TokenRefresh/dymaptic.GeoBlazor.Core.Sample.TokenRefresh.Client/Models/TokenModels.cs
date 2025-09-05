using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;

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

/// <summary>
///     Client configuration response containing static keys.
/// </summary>
public record ClientConfigResponse(string? GeoBlazorLicenseKey, string? ArcGISApiKey, string? ArcGISPortalUrl, string? ArcGISAppId);