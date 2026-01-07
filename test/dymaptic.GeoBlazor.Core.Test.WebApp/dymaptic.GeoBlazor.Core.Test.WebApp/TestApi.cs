using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;


namespace dymaptic.GeoBlazor.Core.Test.WebApp;

public static class TestApi
{
    extension(WebApplication app)
    {
        public void MapTestLogger()
        {
            app.MapPost("/log", (LogMessage message, ITestLogger logger) =>
                logger.Log(message.Message));
        
            app.MapPost("/log-error", (LogMessage message, ITestLogger logger) =>
                logger.LogError(message.Message, message.Exception));
        }

        public void MapApplicationManagement()
        {
            app.MapPost("/exit", (string exitCode, ITestLogger logger, IHostApplicationLifetime lifetime) =>
            {
                logger.Log($"Exiting application with code {exitCode}");
                Environment.ExitCode = int.Parse(exitCode);
                lifetime.StopApplication();
            });
        }
    }
}