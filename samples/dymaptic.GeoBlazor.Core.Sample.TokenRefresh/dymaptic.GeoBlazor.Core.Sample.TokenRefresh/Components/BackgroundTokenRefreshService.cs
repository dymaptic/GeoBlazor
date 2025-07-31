using dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Client;

namespace dymaptic.GeoBlazor.Core.Sample.TokenRefresh.Components
{
    public class BackgroundTokenRefreshService(IServiceProvider serviceProvider, IConfiguration config) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var authService = scope.ServiceProvider.GetRequiredService<ArcGisAuthService>();
                    TokenResponse tokenResponse = await authService.GetTokenAsync(true);

                    if (!tokenResponse.Success)
                    {
                        // Handle error (e.g., log it)
                        Console.WriteLine(tokenResponse);
                    }
                }

                int refreshInterval = int.Parse(config["ArcGISTokenRefreshIntervalMinutes"] ?? "1440");
                await Task.Delay(TimeSpan.FromMinutes(refreshInterval), stoppingToken);
            }
        }
    }
}
