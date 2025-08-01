using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;
using System.Text.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// STEP 1: Retrieve client configuration from server API
// This approach separates concerns by keeping sensitive credentials (client secrets) on the server
// while allowing the WebAssembly client to access necessary configuration for GeoBlazor initialization.
var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var tempConfig = new Dictionary<string, string?>();

try
{
    // Make API call to get static configuration
    var response = await httpClient.GetAsync("/api/config");
    if (response.IsSuccessStatusCode)
    {
        var configResponse = await response.Content.ReadFromJsonAsync<ClientConfigResponse>();
        if (configResponse != null)
        {
            if (!string.IsNullOrEmpty(configResponse.GeoBlazorLicenseKey))
            {
                tempConfig["GeoBlazor:RegistrationKey"] = configResponse.GeoBlazorLicenseKey;
                Console.WriteLine("✅ Successfully retrieved GeoBlazor license from server");
            }
            
            if (!string.IsNullOrEmpty(configResponse.ArcGISApiKey))
            {
                tempConfig["ArcGISApiKey"] = configResponse.ArcGISApiKey;
                Console.WriteLine("✅ Successfully retrieved ArcGIS API Key from server");
            }
            
            if (!string.IsNullOrEmpty(configResponse.ArcGISPortalUrl))
            {
                tempConfig["ArcGISPortalUrl"] = configResponse.ArcGISPortalUrl;
                Console.WriteLine("✅ Successfully retrieved ArcGIS Portal URL from server");
            }
            
            if (!string.IsNullOrEmpty(configResponse.ArcGISAppId))
            {
                tempConfig["ArcGISAppId"] = configResponse.ArcGISAppId;
                Console.WriteLine("✅ Successfully retrieved ArcGIS App ID from server");
            }
        }
        else
        {
            Console.WriteLine("❌ server returned no config information");
        }
    }
    else
    {
        Console.WriteLine($"❌ Failed to get config from server: {response.StatusCode}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error getting configuration: {ex.Message}");
}

// STEP 2: Configure GeoBlazor with retrieved configuration
// The configuration retrieved from the server is added to the client's configuration provider
// and used to initialize GeoBlazor with the proper license key and API settings.
builder.Configuration.AddInMemoryCollection(tempConfig);
builder.Services.AddGeoBlazor(builder.Configuration);

// STEP 3: Register application services
// ArcGisAuthServiceWasm handles token requests to the server API endpoints
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ArcGisAuthServiceWasm>();

await builder.Build().RunAsync();