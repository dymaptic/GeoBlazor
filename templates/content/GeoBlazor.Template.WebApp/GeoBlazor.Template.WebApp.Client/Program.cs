using dymaptic.GeoBlazor.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);
builder.Services.AddGeoBlazor(builder.Configuration);

await builder.Build().RunAsync();
