#if (IndividualLocalAuth)
using GeoBlazorMauiAndWeb.Web.Client;
using Microsoft.AspNetCore.Components.Authorization;
#endif
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GeoBlazorMauiAndWeb.Shared.Services;
using GeoBlazorMauiAndWeb.Web.Client.Services;
#if UsePro
using dymaptic.GeoBlazor.Pro;
#else
using dymaptic.GeoBlazor.Core;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the GeoBlazorMauiAndWeb.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

#if (IndividualLocalAuth)
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

#endif
#if (UsePro)
builder.Services.AddGeoBlazorPro(builder.Configuration);
#else
builder.Services.AddGeoBlazor(builder.Configuration);

#endif
await builder.Build().RunAsync();
