using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Objects;

public class AbortManager: IAsyncDisposable
{
    public AbortManager(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task<IJSObjectReference> CreateAbortSignal(CancellationToken cancellationToken)
    {
        if (_abortControllerModule is null)
        {
            _abortControllerModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", 
                cancellationToken, "./_content/dymaptic.GeoBlazor.Interactive/js/abortController.js");
        }
        AbortManagerResult result = await _abortControllerModule!
            .InvokeAsync<AbortManagerResult>("createAbortControllerAndSignal", cancellationToken);
        
        // ReSharper disable once AsyncVoidLambda
        CancellationTokenRegistration registration =
            cancellationToken.Register(async () => await AbortQuery(cancellationToken));

        _tokensAndControllers[cancellationToken] = new AbortReferenceRecord(registration, result.AbortControllerRef);

        return result.AbortSignalRef;
    }

    public async Task DisposeAbortController(CancellationToken cancellationToken)
    {
        (CancellationTokenRegistration registration, IJSObjectReference abortControllerRef) =
            _tokensAndControllers[cancellationToken];
        
        await registration.DisposeAsync();
        await abortControllerRef.DisposeAsync();
        _tokensAndControllers.Remove(cancellationToken);
    }
    
    public async ValueTask DisposeAsync()
    {
        foreach (CancellationToken token in _tokensAndControllers.Keys)
        {
            await AbortQuery(token);
        }
    }
    
    private async Task AbortQuery(CancellationToken cancellationToken)
    {
        (CancellationTokenRegistration registration, IJSObjectReference abortControllerRef) =
            _tokensAndControllers[cancellationToken];
        // ReSharper disable once MethodSupportsCancellation
        await abortControllerRef.InvokeVoidAsync("abort");
        await abortControllerRef.DisposeAsync();
        await registration.DisposeAsync();
        _tokensAndControllers.Remove(cancellationToken);
    }
    
    private IJSObjectReference? _abortControllerModule;
    private readonly IJSRuntime _jsRuntime;
    private readonly Dictionary<CancellationToken, AbortReferenceRecord> _tokensAndControllers = new();
    
    private record AbortReferenceRecord(CancellationTokenRegistration Registration, IJSObjectReference AbortControllerRef);
}

public record AbortManagerResult(IJSObjectReference AbortControllerRef, IJSObjectReference AbortSignalRef);