using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.Shared;
using dymaptic.GeoBlazor.Core.Sample.Shared.Shared;
using dymaptic.GeoBlazor.Core.Sample.WebApp.Client;
using dymaptic.GeoBlazor.Core.Sample.WebApp.Components;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<SharedFileProvider>();
builder.Services.AddGeoBlazor(builder.Configuration);
builder.Configuration.AddInMemoryCollection();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MainLayout).Assembly, typeof(Routes).Assembly);

app.Run();