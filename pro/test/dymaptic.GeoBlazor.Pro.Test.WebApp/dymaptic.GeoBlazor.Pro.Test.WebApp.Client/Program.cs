using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;
using dymaptic.GeoBlazor.Pro;
using dymaptic.GeoBlazor.Pro.Test.WebApp.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddGeoBlazorPro(builder.Configuration);
builder.Services.AddScoped<IHostApplicationLifetime, WasmApplicationLifetime>();
builder.Services.AddHttpClient<WasmApplicationLifetime>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped<ITestLogger, ClientTestLogger>();
builder.Services.AddHttpClient<ClientTestLogger>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();