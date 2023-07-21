using dymaptic.GeoBlazor.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using dymaptic.GeoBlazor.Core.Test.Blazor.Wasm;
using Microsoft.Extensions.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IHostApplicationLifetime, WasmApplicationLifetime>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddGeoBlazor();

await builder.Build().RunAsync();
