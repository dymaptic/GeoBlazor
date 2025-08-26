using System.Net.Http.Json;
using System.Text.Json;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;
using dymaptic.GeoBlazor.Core.Model;

namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;

public class ArcGisAuthServiceWasm
{
    private readonly HttpClient _httpClient;
    
    public ArcGisAuthServiceWasm(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<TokenResponse> GetTokenFromServer(bool forceRefresh = false)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/token", forceRefresh);
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return tokenResponse ?? new TokenResponse(false, null, null, "Failed to deserialize token response");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new TokenResponse(false, null, null, $"API Error: {response.StatusCode} - {errorContent}");
            }
        }
        catch (Exception ex)
        {
            return new TokenResponse(false, null, null, $"Request failed: {ex.Message}");
        }
    }

    public async Task<(string success, string error)> GetNewArcGISToken(AuthenticationManager authManager)
    {
        try
        {
            TokenResponse tokenResponse = await GetTokenFromServer(true);
            if (tokenResponse.Success && tokenResponse.AccessToken != null)
            {
                var result = $"✅ ArcGisAuthService Success!\nToken (first 20 chars): {tokenResponse.AccessToken[..Math.Min(20, tokenResponse.AccessToken.Length)]}...\nExpires: {tokenResponse.Expires}";
                
                await authManager.RegisterToken(tokenResponse.AccessToken, (DateTimeOffset)tokenResponse.Expires!);
                
                string? authManagerToken = await authManager.GetCurrentToken();
                result += !string.IsNullOrEmpty(authManagerToken) 
                    ? "\n✅ AuthenticationManager token retrieved successfully!"
                    : "\n⚠️ AuthenticationManager returned null token";
                
                return (result, "");
            }
            else
            {
                return ("", $"❌ Token request failed: {tokenResponse.ErrorMessage}");
            }
        }
        catch (Exception ex)
        {
            return ("", $"❌ Exception occurred: {ex.Message}");
        }
    }

    public async Task<(string success, string error)> CheckAuthStatusAsync(AuthenticationManager authManager)
    {
        try
        {
            bool isLoggedIn = await authManager.IsLoggedIn();
            var result = $"Auth Status: {(isLoggedIn ? "✅ Logged In" : "❌ Not Logged In")}";
            
            result += isLoggedIn 
                ? "\n📋 Authentication Manager indicates user is authenticated\n🔗 Ready for ArcGIS API calls and map operations"
                : "\n⚠️ No valid authentication found\n💡 Try running 'Get Token' first to authenticate";
            
            return (result, "");
        }
        catch (Exception ex)
        {
            return ("", $"❌ Error checking auth status: {ex.Message}");
        }
    }

    public async Task<(string success, string error)> GetTokenExpiresAsync(AuthenticationManager authManager)
    {
        try
        {
            DateTime? expires = await authManager.GetTokenExpirationDateTime();
            if (expires.HasValue)
            {
                var timeRemaining = expires.Value - DateTime.UtcNow;
                var result = $"Token Expires: {expires.Value:yyyy-MM-dd HH:mm:ss} UTC";
                
                if (timeRemaining.TotalMinutes > 0)
                {
                    result += $"\nTime Remaining: {timeRemaining.Days}d {timeRemaining.Hours}h {timeRemaining.Minutes}m\n✅ Token is still valid";
                }
                else
                {
                    result += $"\n❌ Token has expired ({Math.Abs(timeRemaining.TotalMinutes):F0} minutes ago)\n💡 Run 'Get Token' to refresh";
                }
                
                return (result, "");
            }
            else
            {
                return ("Token expiration not available (possibly using API key)", "");
            }
        }
        catch (Exception ex)
        {
            return ("", $"❌ Error getting token expiration: {ex.Message}");
        }
    }
}