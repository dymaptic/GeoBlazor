using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<SharedFileProvider>();
builder.Services.AddGeoBlazor(builder.Configuration);
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);

await builder.Build().RunAsync();