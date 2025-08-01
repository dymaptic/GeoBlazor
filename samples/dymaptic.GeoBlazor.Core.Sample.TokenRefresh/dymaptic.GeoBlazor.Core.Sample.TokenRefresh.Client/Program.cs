using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddGeoBlazor(builder.Configuration);

builder.Services.AddScoped<ArcGisAuthService>();
builder.Services.AddScoped<HttpClient>(sp => 
{
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    return httpClient;
});

await builder.Build().RunAsync();