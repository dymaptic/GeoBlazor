using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;
using System.Net.Http.Json;


namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Services;

/// <summary>
///     Passes token requests to the server API in a Blazor WebAssembly application.
///     It would be a good idea to also implement user authentication around this service.
/// </summary>
public class WasmAuthService(HttpClient httpClient): IAuthService
{
    public async Task<TokenResponse> GetTokenAsync(bool forceRefresh)
    {
        try
        {
            using HttpResponseMessage response = 
                await httpClient.PostAsJsonAsync("api/auth/token", new ClientTokenRequest(forceRefresh));

            if (response.IsSuccessStatusCode)
            {
                TokenResponse? tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();

                return tokenResponse ?? new TokenResponse(false, null, null, "No token response");
            }

            return new TokenResponse(false, null, null,
                $"Error response: {await response.Content.ReadAsStringAsync()}");
        }
        catch (Exception ex)
        {
            return new TokenResponse(false, null, null, ex.Message);
        }
    }
}