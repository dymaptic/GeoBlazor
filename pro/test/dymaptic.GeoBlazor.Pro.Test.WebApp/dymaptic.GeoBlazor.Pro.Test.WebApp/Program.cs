using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;
using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;
using dymaptic.GeoBlazor.Pro;
using dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;
using dymaptic.GeoBlazor.Pro.Test.WebApp;
using dymaptic.GeoBlazor.Pro.Test.WebApp.Client;
using dymaptic.GeoBlazor.Pro.Test.WebApp.Components;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;


try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    // Load the Static Web Assets manifest even outside Development so RCL _content/... assets
    // resolve when running against build (non-published) output in Release.
    builder.WebHost.UseStaticWebAssets();

    builder.Configuration.AddUserSecrets<Program>();

    // Add services to the container.
    builder.Services.AddRazorComponents(options => options.DetailedErrors = true)
        .AddInteractiveServerComponents(options => options.DetailedErrors = true)
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddGeoBlazorPro(builder.Configuration);
    builder.Services.AddScoped<ITestLogger, ServerTestLogger>();
    builder.Services.AddProxyHttpClient();
    builder.Services.AddMemoryCache();

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

    app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.MapStaticAssets();

    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(Routes).Assembly,
            typeof(TestRunnerBase).Assembly,
            typeof(ProTestRunnerBase).Assembly);

    app.MapTestLogger();
    app.MapApplicationManagement();

    app.MapProxies();

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