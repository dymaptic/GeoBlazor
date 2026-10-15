using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
#if (UsePro)
using dymaptic.GeoBlazor.Pro;
#else
using dymaptic.GeoBlazor.Core;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);

#if (IndividualLocalAuth)
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

#endif
#if (UsePro)
builder.Services.AddGeoBlazorPro(builder.Configuration);
#else
builder.Services.AddGeoBlazor(builder.Configuration);

#endif
await builder.Build().RunAsync();
