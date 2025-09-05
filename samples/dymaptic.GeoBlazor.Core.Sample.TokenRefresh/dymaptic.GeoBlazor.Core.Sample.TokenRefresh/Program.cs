using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Components;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Services;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Apis;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient<ArcGisAuthService>();
builder.Services.AddHttpClient<ArcGisAuthServiceWasm>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApplicationBaseUrl"] ?? "https://localhost:7143");
});

builder.Services.AddGeoBlazor(builder.Configuration);
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapAuthenticationApis();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client._Imports).Assembly);

app.Run();
