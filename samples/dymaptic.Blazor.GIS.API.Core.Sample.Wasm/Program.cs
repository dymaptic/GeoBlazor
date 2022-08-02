using dymaptic.Blazor.GIS.API.Core.Sample.Shared;
using dymaptic.Blazor.GIS.API.Core.Sample.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.FileProviders;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Configuration.AddInMemoryCollection();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<SharedFileProvider>();
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);
builder.Services.AddScoped<HttpClient>();

await builder.Build().RunAsync();