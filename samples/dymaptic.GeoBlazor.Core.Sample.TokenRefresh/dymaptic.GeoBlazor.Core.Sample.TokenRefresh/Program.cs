using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Components;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Services;
using Microsoft.AspNetCore.StaticFiles;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var api = app.MapGroup("/api");

// GET /api/config  ? non-sensitive client config
api.MapGet("/config", (IConfiguration config) =>
{
    var payload = new
    {
        GeoBlazorLicenseKey = config["GeoBlazor:RegistrationKey"],
        ArcGISApiKey = config["ArcGISApiKey"],
        ArcGISPortalUrl = config["ArcGISPortalUrl"],
        ArcGISAppId = config["ArcGISAppId"]
    };
    return Results.Ok(payload);
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);

// POST /api/auth/token  ? body: true/false OR ?forceRefresh=true
api.MapPost("/auth/token", async (HttpContext ctx, ArcGisAuthService auth) =>
{
    bool forceRefresh = false;

    // Allow query string toggle
    if (ctx.Request.Query.TryGetValue("forceRefresh", out var q) &&
        bool.TryParse(q, out var fromQuery))
    {
        forceRefresh = fromQuery;
    }
    else
    {
        // Allow raw boolean body (not an object)
        try
        {
            var bodyBool = await JsonSerializer.DeserializeAsync<bool?>(ctx.Request.Body,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (bodyBool.HasValue) forceRefresh = bodyBool.Value;
        }
        catch
        {
            // ignore malformed bodies; default remains false
        }
    }

    try
    {
        var tokenResponse = await auth.GetTokenAsync(forceRefresh);
        return Results.Ok(tokenResponse);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client._Imports).Assembly);

app.Run();
