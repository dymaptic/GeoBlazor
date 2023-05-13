using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.WasmOAuth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddGeoBlazor();

var app = builder.Build();
await app.RunAsync();
