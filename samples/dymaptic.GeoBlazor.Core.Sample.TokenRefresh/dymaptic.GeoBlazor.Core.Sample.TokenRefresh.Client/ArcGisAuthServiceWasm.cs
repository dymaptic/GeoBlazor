using System.Net.Http.Json;
using System.Text.Json;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;

namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;

public class ArcGisAuthServiceWasm
{
    private readonly HttpClient _httpClient;
    
    public ArcGisAuthServiceWasm(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<TokenResponse> GetTokenAsync(bool forceRefresh = false)
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
}