using dymaptic.GeoBlazor.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddGeoBlazor(builder.Configuration);
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);

await builder.Build().RunAsync();