using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;


namespace dymaptic.GeoBlazor.Core.Test.WebApp;

public static class TestApi
{
    public static void MapTestLogger(this WebApplication app)
    {
        app.MapPost("/log", (LogMessage message, ITestLogger logger) =>
            logger.Log(message.Message));
        
        app.MapPost("/log-error", (LogMessage message, ITestLogger logger) =>
            logger.LogError(message.Message, message.Exception));
    }
}