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
var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var tempConfig = new Dictionary<string, string?>();

try
{
    var cfg = await http.GetFromJsonAsync<ClientConfigResponse>("/api/config");
    if (cfg is not null)
    {
        void Add(string k, string? v) { if (!string.IsNullOrWhiteSpace(v)) tempConfig[k] = v; }

        Add("GeoBlazor:RegistrationKey", cfg.GeoBlazorLicenseKey);
        Add("ArcGISApiKey", cfg.ArcGISApiKey);
        Add("ArcGISPortalUrl", cfg.ArcGISPortalUrl);
        Add("ArcGISAppId", cfg.ArcGISAppId);
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