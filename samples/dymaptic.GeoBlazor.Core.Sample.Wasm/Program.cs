using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddGeoBlazor(builder.Configuration);
builder.Configuration.AddInMemoryCollection();
builder.Services.AddScoped<HttpClient>();

await builder.Build().RunAsync();