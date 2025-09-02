using System.Text.Json;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Services;

namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Apis;

public static class AuthenticationApis
{
    public static WebApplication MapAuthenticationApis(this WebApplication app)
    {
        var api = app.MapGroup("/api");

        api.MapGet("/config", HandleGetConfig)
           .Produces(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status400BadRequest);

        api.MapPost("/auth/token", HandlePostTokenAsync)
           .Produces(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status400BadRequest);

        return app;
    }

    private static IResult HandleGetConfig(IConfiguration config)
    {
        var payload = new
        {
            GeoBlazorLicenseKey = config["GeoBlazor:RegistrationKey"],
            ArcGISApiKey = config["ArcGISApiKey"],
            ArcGISPortalUrl = config["ArcGISPortalUrl"],
            ArcGISAppId = config["ArcGISAppId"]
        };
        return Microsoft.AspNetCore.Http.Results.Ok(payload);
    }

    private static async Task<IResult> HandlePostTokenAsync(HttpContext ctx, ArcGisAuthService auth)
    {
        bool forceRefresh = false;

        // Support query string: /api/auth/token?forceRefresh=true
        if (ctx.Request.Query.TryGetValue("forceRefresh", out var q) &&
            bool.TryParse(q, out var fromQuery))
        {
            forceRefresh = fromQuery;
        }
        else
        {
            // Support raw boolean body: true / false
            try
            {
                var bodyBool = await JsonSerializer.DeserializeAsync<bool?>(ctx.Request.Body,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (bodyBool.HasValue) forceRefresh = bodyBool.Value;
            }
            catch
            {
                // ignore malformed body; default stays false
            }
        }

        try
        {
            var tokenResponse = await auth.GetTokenAsync(forceRefresh);
            return Microsoft.AspNetCore.Http.Results.Ok(tokenResponse);
        }
        catch (Exception ex)
        {
            return Microsoft.AspNetCore.Http.Results.BadRequest(new { error = ex.Message });
        }
    }
}