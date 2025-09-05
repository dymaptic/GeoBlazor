using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

Uri baseAddress = new Uri(builder.HostEnvironment.BaseAddress);
using HttpClient bootstrapHttp = new HttpClient { BaseAddress = baseAddress };
Dictionary<string, string?> tempConfig = new Dictionary<string, string?>();

try
{
    ClientConfigResponse? cfg = await bootstrapHttp.GetFromJsonAsync<ClientConfigResponse>("/api/config");
    if (cfg is null) throw new InvalidOperationException("Config endpoint returned null.");

    tempConfig["GeoBlazor:LicenseKey"] = cfg.GeoBlazorLicenseKey;
    tempConfig["ArcGISApiKey"] = cfg.ArcGISApiKey;
    tempConfig["ArcGISPortalUrl"] = cfg.ArcGISPortalUrl;
    tempConfig["ArcGISAppId"] = cfg.ArcGISAppId;
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error getting configuration: {ex.Message}");
}

builder.Configuration.AddInMemoryCollection(tempConfig);
builder.Services.AddGeoBlazor(builder.Configuration);

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = baseAddress });
builder.Services.AddScoped<ArcGisAuthServiceWasm>();

await builder.Build().RunAsync();