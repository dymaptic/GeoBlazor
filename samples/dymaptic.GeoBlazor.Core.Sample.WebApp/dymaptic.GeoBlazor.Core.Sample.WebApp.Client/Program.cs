using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ArcGisAuthService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddGeoBlazor(builder.Configuration);
builder.Services.AddScoped<IConfiguration>(_ => builder.Configuration);

await builder.Build().RunAsync();