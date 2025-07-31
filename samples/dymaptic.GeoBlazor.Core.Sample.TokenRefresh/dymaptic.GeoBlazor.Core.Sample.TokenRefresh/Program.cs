using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Pages;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Components;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<ArcGisAuthService>();
builder.Services.AddScoped<HttpClient>();

builder.Services.AddGeoBlazor(builder.Configuration);
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

#if (ENABLE_COMPRESSION)
app.MapStaticAssets();
#else
FileExtensionContentTypeProvider provider = new() { Mappings = { [".wsv"] = "application/octet-stream" } };
app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });
#endif

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client._Imports).Assembly);

app.Run();
