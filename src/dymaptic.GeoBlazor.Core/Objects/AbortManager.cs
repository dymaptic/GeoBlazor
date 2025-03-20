namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The AbortManager translates a .NET <see cref="CancellationToken" /> into a JavaScript abort signal.
/// </summary>
public class AbortManager : IAsyncDisposable
{
    /// <summary>
    ///     Creates a new AbortManager.
    /// </summary>
    /// <param name="jsRuntime">
    ///     The <see cref="IJSRuntime" /> to use for JavaScript interop.
    /// </param>
    /// <param name="jsModuleManager">
    ///     The <see cref="JsModuleManager" /> to use for JavaScript interop.
    /// </param>
    public AbortManager(IJSRuntime jsRuntime, JsModuleManager jsModuleManager)
    {
        _jsRuntime = jsRuntime;
        _jsModuleManager = jsModuleManager;
    }
    
    /// <summary>
    ///     Creates a new AbortManager.
    /// </summary>
    /// <param name="jsModule">
    ///     The CoreJsModule to use for JavaScript interop.
    /// </param>
    public AbortManager(IJSObjectReference jsModule)
    {
        _jsModule = jsModule;
    }

    /// <summary>
    ///     Disposes the full AbortManager, and cancels all queries.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        foreach (CancellationToken token in _tokensAndControllers.Keys)
        {
            await AbortQuery(token);
        }
    }

    /// <summary>
    ///     Creates a new abort signal for the given <see cref="CancellationToken" />.
    /// </summary>
    /// <remarks>
    ///     Uses of this method should always be followed by <see cref="DisposeAbortController" /> when you are finished with
    ///     the JavaScript calls.
    /// </remarks>
    /// <param name="cancellationToken">
    ///     The <see cref="CancellationToken" /> to create the abort signal for.
    /// </param>
    public async Task<IJSObjectReference> CreateAbortSignal(CancellationToken cancellationToken)
    {
        if (_jsModule is null)
        {
            IJSObjectReference? proJsModule = await _jsModuleManager!.GetArcGisJsPro(_jsRuntime!, cancellationToken);
            _jsModule = await _jsModuleManager.GetArcGisJsCore(_jsRuntime!, proJsModule, cancellationToken);
        }
        
        AbortManagerResult result = await _jsModule
            .InvokeAsync<AbortManagerResult>("createAbortControllerAndSignal", cancellationToken);

        // ReSharper disable once AsyncVoidLambda
        CancellationTokenRegistration registration =
            cancellationToken.Register(async () => await AbortQuery(cancellationToken));

        _tokensAndControllers[cancellationToken] = new AbortReferenceRecord(registration, result.AbortControllerRef);

        return result.AbortSignalRef;
    }

    /// <summary>
    ///     Disposes the signal created for a specific JavaScript call, this should always be called when you are done with the
    ///     signal.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The <see cref="CancellationToken" /> to abort the query for.
    /// </param>
    public async Task DisposeAbortController(CancellationToken cancellationToken)
    {
        try
        {
            (CancellationTokenRegistration registration, IJSObjectReference abortControllerRef) =
                _tokensAndControllers[cancellationToken];

            await registration.DisposeAsync();
            await abortControllerRef.DisposeAsync();

            if (_tokensAndControllers.ContainsKey(cancellationToken))
            {
                _tokensAndControllers.TryRemove(cancellationToken, out _);
            }
        }
        catch
        {
            // ignore
        }
    }

    private async Task AbortQuery(CancellationToken cancellationToken)
    {
        try
        {
            (CancellationTokenRegistration registration, IJSObjectReference abortControllerRef) =
                _tokensAndControllers[cancellationToken];

            // ReSharper disable once MethodSupportsCancellation
            await abortControllerRef.InvokeVoidAsync("abort");
            await abortControllerRef.DisposeAsync();
            await registration.DisposeAsync();
        }
        catch
        {
            // swallow these exceptions, it usually means we are disconnected already.
        }
        
        _tokensAndControllers.TryRemove(cancellationToken, out _);
    }

    
    private readonly ConcurrentDictionary<CancellationToken, AbortReferenceRecord> _tokensAndControllers = new();

    private IJSObjectReference? _jsModule;
    private readonly IJSRuntime? _jsRuntime;
    private readonly JsModuleManager? _jsModuleManager;

    private record AbortReferenceRecord(CancellationTokenRegistration Registration,
        IJSObjectReference AbortControllerRef);
}

/// <summary>
///     The result of creating an abort controller and signal.
/// </summary>
/// <param name="AbortControllerRef">
///     Reference to the JavaScript abort controller.
/// </param>
/// <param name="AbortSignalRef">
///     Reference to the JavaScript abort signal.
/// </param>
public record AbortManagerResult(IJSObjectReference AbortControllerRef, IJSObjectReference AbortSignalRef);