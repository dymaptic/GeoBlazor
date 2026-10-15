using Microsoft.AspNetCore.StaticFiles;
using GeoBlazorMauiAndWeb.Web.Components;
using GeoBlazorMauiAndWeb.Shared.Services;
using GeoBlazorMauiAndWeb.Web.Services;
#if UsePro
using dymaptic.GeoBlazor.Pro;
#else
using dymaptic.GeoBlazor.Core;
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    #if (UseServer && UseWebAssembly)
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
    #elif (UseServer)
    .AddInteractiveServerComponents();
    #elif (UseWebAssembly)
    .AddInteractiveWebAssemblyComponents();
    #endif

// Add device-specific services used by the GeoBlazorMauiAndWeb.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

#if (UsePro)
builder.Services.AddGeoBlazorPro(builder.Configuration);
#else
builder.Services.AddGeoBlazor(builder.Configuration);

#endif
var app = builder.Build();

// Configure the HTTP request pipeline.
#if (UseWebAssembly || IndividualLocalAuth)
if (app.Environment.IsDevelopment())
{
#if (UseWebAssembly)
    app.UseWebAssemblyDebugging();
#endif
#if (IndividualLocalAuth)
    app.UseMigrationsEndPoint();
#endif
}
else
#else
if (!app.Environment.IsDevelopment())
#endif
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
#if (HasHttpsProfile)
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
#endif
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
#if (HasHttpsProfile)
app.UseHttpsRedirection();

#endif

app.MapStaticAssets();

app.UseAntiforgery();

#if (UseServer && UseWebAssembly)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(GeoBlazorMauiAndWeb.Shared._Imports).Assembly,
        typeof(GeoBlazorMauiAndWeb.Web.Client._Imports).Assembly);
#elif (UseServer)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(GeoBlazorMauiAndWeb.Shared._Imports).Assembly);
#else (UseWebAssembly)
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(GeoBlazorMauiAndWeb.Shared._Imports).Assembly,
        typeof(GeoBlazorMauiAndWeb.Web.Client._Imports).Assembly);
#endif
app.Run();
