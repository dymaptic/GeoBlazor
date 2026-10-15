using Microsoft.Extensions.Hosting;


namespace dymaptic.GeoBlazor.Pro.Test.Maui;

public class MauiApplicationLifetime: IHostApplicationLifetime
{
    private readonly CancellationTokenSource _startedCts = new();
    private readonly CancellationTokenSource _stoppingCts = new();
    private readonly CancellationTokenSource _stoppedCts = new();

    public CancellationToken ApplicationStarted => _startedCts.Token;
    public CancellationToken ApplicationStopping => _stoppingCts.Token;
    public CancellationToken ApplicationStopped => _stoppedCts.Token;

    public void StopApplication()
    {
        _startedCts.Cancel();
        _stoppingCts.Cancel();
        _stoppedCts.Cancel();

        Environment.Exit(Environment.ExitCode);
    }
}