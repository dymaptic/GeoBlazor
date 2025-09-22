using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Models;
using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client.Services;


namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Apis;

public static class AuthenticationApis
{
    public static WebApplication MapAuthenticationApis(this WebApplication app)
    {
        RouteGroupBuilder api = app.MapGroup("/api");
        
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
        return Microsoft.AspNetCore.Http.Results.Ok(
            new ClientConfigResponse(config["GeoBlazor:LicenseKey"] ?? config["GeoBlazor:RegistrationKey"],
                config["ArcGISPortalUrl"], config["ArcGISAppId"]));
    }

    private static async Task<IResult> HandlePostTokenAsync(ClientTokenRequest tokenRequest, IAuthService auth)
    {
        TokenResponse tokenResponse = await auth.GetTokenAsync(tokenRequest.ForceRefresh);
        return Microsoft.AspNetCore.Http.Results.Ok(tokenResponse);
    }
}