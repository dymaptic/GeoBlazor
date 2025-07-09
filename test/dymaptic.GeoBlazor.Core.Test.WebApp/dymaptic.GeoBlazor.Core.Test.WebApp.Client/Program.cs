using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Test.WebApp.Client;
using Microsoft.Extensions.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddGeoBlazor(builder.Configuration);
builder.Services.AddScoped<IHostApplicationLifetime, WasmApplicationLifetime>();

await builder.Build().RunAsync();
