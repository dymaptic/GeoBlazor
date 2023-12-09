using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Template.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);
builder.Services.AddGeoBlazor(builder.Configuration);

await builder.Build().RunAsync();
