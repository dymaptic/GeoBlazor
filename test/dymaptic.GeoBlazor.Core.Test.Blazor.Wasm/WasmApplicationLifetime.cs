using Microsoft.Extensions.Hosting;

namespace dymaptic.GeoBlazor.Core.Test.Blazor.Wasm;

public class WasmApplicationLifetime: IHostApplicationLifetime
{
    public CancellationToken ApplicationStarted => CancellationToken.None;

    public CancellationToken ApplicationStopping => CancellationToken.None;

    public CancellationToken ApplicationStopped => CancellationToken.None;

    public void StopApplication()
    {
        throw new NotImplementedException();
    }
}