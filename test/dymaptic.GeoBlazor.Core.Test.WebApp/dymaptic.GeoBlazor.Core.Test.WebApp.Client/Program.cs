using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;
using dymaptic.GeoBlazor.Core.Test.WebApp.Client;
using Microsoft.Extensions.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddGeoBlazor(builder.Configuration);
builder.Services.AddScoped<IHostApplicationLifetime, WasmApplicationLifetime>();
builder.Services.AddScoped<ITestLogger, ClientTestLogger>();
builder.Services.AddHttpClient<ClientTestLogger>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
