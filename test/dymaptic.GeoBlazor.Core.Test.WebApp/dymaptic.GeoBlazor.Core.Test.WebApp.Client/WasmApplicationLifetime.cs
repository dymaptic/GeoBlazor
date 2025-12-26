using Microsoft.Extensions.Hosting;


namespace dymaptic.GeoBlazor.Core.Test.WebApp.Client;

public class WasmApplicationLifetime(IHttpClientFactory httpClientFactory) : IHostApplicationLifetime
{
    private readonly CancellationTokenSource _stoppingCts = new();
    private readonly CancellationTokenSource _stoppedCts = new();

    public CancellationToken ApplicationStarted => CancellationToken.None; // Already started in WASM
    public CancellationToken ApplicationStopping => _stoppingCts.Token;
    public CancellationToken ApplicationStopped => _stoppedCts.Token;

    public void StopApplication()
    {
        using HttpClient httpClient = httpClientFactory.CreateClient(nameof(WasmApplicationLifetime));
        _ = httpClient.PostAsync($"exit?exitCode={Environment.ExitCode}", null);
    }
}