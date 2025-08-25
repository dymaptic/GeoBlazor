using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 1) Pull non-sensitive config from the server with a scoped/disposed client
var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);
using var bootstrapHttp = new HttpClient { BaseAddress = baseAddress };
var tempConfig = new Dictionary<string, string?>();

try
{
    var cfg = await bootstrapHttp.GetFromJsonAsync<ClientConfigResponse>("/api/config");
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

// 2) Configure GeoBlazor with what we got
builder.Configuration.AddInMemoryCollection(tempConfig);
builder.Services.AddGeoBlazor(builder.Configuration);

// 3) Register a DI-managed HttpClient for the rest of the app
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = baseAddress });
builder.Services.AddScoped<ArcGisAuthServiceWasm>();

await builder.Build().RunAsync();