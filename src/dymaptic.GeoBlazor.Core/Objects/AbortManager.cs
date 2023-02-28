using Microsoft.JSInterop;


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
    public AbortManager(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
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
        if (_abortControllerModule is null)
        {
            _abortControllerModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import",
                cancellationToken, "./_content/dymaptic.GeoBlazor.Core/js/abortController.js");
        }

        AbortManagerResult result = await _abortControllerModule!
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
        (CancellationTokenRegistration registration, IJSObjectReference abortControllerRef) =
            _tokensAndControllers[cancellationToken];

        await registration.DisposeAsync();
        await abortControllerRef.DisposeAsync();
        _tokensAndControllers.Remove(cancellationToken);
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

    private readonly IJSRuntime _jsRuntime;
    private readonly Dictionary<CancellationToken, AbortReferenceRecord> _tokensAndControllers = new();

    private IJSObjectReference? _abortControllerModule;

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