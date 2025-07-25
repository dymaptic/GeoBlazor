using dymaptic.GeoBlazor.Core.Test.WebApp.Components;
using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;
using dymaptic.GeoBlazor.Core.Test.WebApp.Client;
using Microsoft.AspNetCore.StaticFiles;
using System.Text.Json;


try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddGeoBlazor(builder.Configuration);

    WebApplication app = builder.Build();

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

    app.MapStaticAssets();

    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(Routes).Assembly,
            typeof(TestRunnerBase).Assembly);

    app.Run();

    return 0;

}
catch (Exception ex)
{
    if (ex is HostAbortedException)
    {
        Console.WriteLine($"{ex}, {JsonSerializer.Serialize(ex.Data)}");
    }

    Console.WriteLine($"Host terminated unexpectedly, {ex}");

    return 1;
}