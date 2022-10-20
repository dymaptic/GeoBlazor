using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Sample.Shared;
using dymaptic.GeoBlazor.Core.Sample.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Configuration.AddInMemoryCollection();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<SharedFileProvider>();
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<Projection>();

await builder.Build().RunAsync();