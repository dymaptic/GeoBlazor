using Microsoft.Playwright;
using System.Collections.Concurrent;
using System.Diagnostics;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

/// <summary>
/// Thread-safe pool of browser instances for parallel test execution.
/// Limits concurrent browser processes to prevent resource exhaustion on CI runners.
/// </summary>
public sealed class BrowserPool : IAsyncDisposable
{
    private static BrowserPool? _instance;
    private static readonly object _instanceLock = new();

    private readonly ConcurrentQueue<PooledBrowser> _availableBrowsers = new();
    private readonly ConcurrentDictionary<Guid, PooledBrowser> _checkedOutBrowsers = new();
    private readonly SemaphoreSlim _poolSemaphore;
    private readonly SemaphoreSlim _creationLock = new(1, 1);
    private readonly BrowserTypeLaunchOptions _launchOptions;
    private readonly IBrowserType _browserType;
    private readonly int _maxPoolSize;
    private int _currentPoolSize;
    private bool _disposed;

    /// <summary>
    /// Maximum time to wait for a browser from the pool (3 minutes)
    /// </summary>
    private static readonly TimeSpan CheckoutTimeout = TimeSpan.FromMinutes(3);

    private BrowserPool(IBrowserType browserType, BrowserTypeLaunchOptions launchOptions, int maxPoolSize)
    {
        _browserType = browserType;
        _launchOptions = launchOptions;
        _maxPoolSize = maxPoolSize;
        _poolSemaphore = new SemaphoreSlim(maxPoolSize, maxPoolSize);
    }

    /// <summary>
    /// Gets or creates the singleton browser pool instance.
    /// </summary>
    public static BrowserPool GetInstance(IBrowserType browserType, BrowserTypeLaunchOptions launchOptions, int maxPoolSize = 2)
    {
        if (_instance is null)
        {
            lock (_instanceLock)
            {
                _instance ??= new BrowserPool(browserType, launchOptions, maxPoolSize);
            }
        }

        return _instance;
    }

    /// <summary>
    /// Tries to get the existing pool instance without creating one.
    /// Used for cleanup scenarios.
    /// </summary>
    public static bool TryGetInstance(out BrowserPool? pool)
    {
        pool = _instance;

        return pool is not null;
    }

    /// <summary>
    /// Checks out a browser from the pool. Creates a new one if pool isn't full.
    /// Waits if pool is exhausted until a browser becomes available.
    /// </summary>
    public async Task<PooledBrowser> CheckoutAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        // Wait for a slot in the pool
        bool acquired = await _poolSemaphore.WaitAsync(CheckoutTimeout, cancellationToken)
            .ConfigureAwait(false);

        if (!acquired)
        {
            throw new TimeoutException(
                $"Timed out waiting for browser from pool after {CheckoutTimeout.TotalSeconds} seconds. " +
                $"Pool size: {_maxPoolSize}, All browsers checked out.");
        }

        try
        {
            // Try to get an existing healthy browser from the queue
            while (_availableBrowsers.TryDequeue(out var pooledBrowser))
            {
                if (await pooledBrowser.IsHealthyAsync().ConfigureAwait(false))
                {
                    pooledBrowser.MarkCheckedOut();
                    _checkedOutBrowsers[pooledBrowser.Id] = pooledBrowser;
                    Trace.WriteLine($"Checked out existing browser {pooledBrowser.Id} from pool", "BROWSER_POOL");

                    return pooledBrowser;
                }

                // Browser is unhealthy, dispose it and decrement pool size
                Trace.WriteLine($"Disposing unhealthy browser {pooledBrowser.Id}", "BROWSER_POOL");
                await pooledBrowser.DisposeAsync().ConfigureAwait(false);
                Interlocked.Decrement(ref _currentPoolSize);
            }

            // No available browsers, create a new one
            await _creationLock.WaitAsync(cancellationToken).ConfigureAwait(false);

            try
            {
                var browser = await _browserType.LaunchAsync(_launchOptions).ConfigureAwait(false);
                var newPooledBrowser = new PooledBrowser(browser, this);
                newPooledBrowser.MarkCheckedOut();
                _checkedOutBrowsers[newPooledBrowser.Id] = newPooledBrowser;
                Interlocked.Increment(ref _currentPoolSize);
                Trace.WriteLine(
                    $"Created new browser {newPooledBrowser.Id}, pool size: {_currentPoolSize}/{_maxPoolSize}",
                    "BROWSER_POOL");

                return newPooledBrowser;
            }
            finally
            {
                _creationLock.Release();
            }
        }
        catch
        {
            // If we fail to get/create a browser, release the semaphore slot
            _poolSemaphore.Release();

            throw;
        }
    }

    /// <summary>
    /// Returns a browser to the pool for reuse by other tests.
    /// </summary>
    public async Task ReturnAsync(PooledBrowser pooledBrowser)
    {
        if (_disposed)
        {
            await pooledBrowser.DisposeAsync().ConfigureAwait(false);

            return;
        }

        if (!_checkedOutBrowsers.TryRemove(pooledBrowser.Id, out _))
        {
            // Browser wasn't tracked as checked out - may be a duplicate return
            Trace.WriteLine($"Warning: Browser {pooledBrowser.Id} returned but wasn't tracked as checked out",
                "BROWSER_POOL");

            return;
        }

        // Close all contexts to reset state for next test
        await pooledBrowser.CloseAllContextsAsync().ConfigureAwait(false);

        if (await pooledBrowser.IsHealthyAsync().ConfigureAwait(false))
        {
            pooledBrowser.MarkReturned();
            _availableBrowsers.Enqueue(pooledBrowser);
            Trace.WriteLine($"Returned browser {pooledBrowser.Id} to pool", "BROWSER_POOL");
        }
        else
        {
            // Browser is unhealthy, dispose it
            Trace.WriteLine($"Disposing unhealthy browser {pooledBrowser.Id} on return", "BROWSER_POOL");
            await pooledBrowser.DisposeAsync().ConfigureAwait(false);
            Interlocked.Decrement(ref _currentPoolSize);
        }

        // Release the semaphore slot
        _poolSemaphore.Release();
    }

    /// <summary>
    /// Reports a browser as crashed/failed. Removes from tracking and releases slot.
    /// </summary>
    public async Task ReportFailedAsync(PooledBrowser pooledBrowser)
    {
        _checkedOutBrowsers.TryRemove(pooledBrowser.Id, out _);

        try
        {
            await pooledBrowser.DisposeAsync().ConfigureAwait(false);
        }
        catch
        {
            // Ignore disposal errors for already-failed browsers
        }

        Interlocked.Decrement(ref _currentPoolSize);
        _poolSemaphore.Release();
        Trace.WriteLine($"Removed failed browser {pooledBrowser.Id} from pool", "BROWSER_POOL");
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        _disposed = true;

        // Dispose all available browsers
        while (_availableBrowsers.TryDequeue(out var browser))
        {
            await browser.DisposeAsync().ConfigureAwait(false);
        }

        // Dispose all checked out browsers
        foreach (var browser in _checkedOutBrowsers.Values)
        {
            await browser.DisposeAsync().ConfigureAwait(false);
        }

        _checkedOutBrowsers.Clear();

        _poolSemaphore.Dispose();
        _creationLock.Dispose();

        _instance = null;
        Trace.WriteLine("Browser pool disposed", "BROWSER_POOL");
    }

    /// <summary>
    /// Gets pool statistics for diagnostics
    /// </summary>
    public (int Available, int CheckedOut, int TotalCreated) GetStats() =>
        (_availableBrowsers.Count, _checkedOutBrowsers.Count, _currentPoolSize);
}

/// <summary>
/// Wrapper around IBrowser that tracks pool state and provides health checking.
/// </summary>
public sealed class PooledBrowser : IAsyncDisposable
{
    private readonly BrowserPool _pool;
    private bool _disposed;

    public Guid Id { get; } = Guid.NewGuid();
    public IBrowser Browser { get; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? CheckedOutAt { get; private set; }
    public DateTime? ReturnedAt { get; private set; }
    public int UseCount { get; private set; }

    internal PooledBrowser(IBrowser browser, BrowserPool pool)
    {
        Browser = browser;
        _pool = pool;

        // Subscribe to disconnect event for crash detection
        browser.Disconnected += OnBrowserDisconnected;
    }

    private async void OnBrowserDisconnected(object? sender, IBrowser browser)
    {
        Trace.WriteLine($"Browser {Id} disconnected unexpectedly", "BROWSER_POOL");
        await _pool.ReportFailedAsync(this).ConfigureAwait(false);
    }

    internal void MarkCheckedOut()
    {
        CheckedOutAt = DateTime.UtcNow;
        UseCount++;
    }

    internal void MarkReturned()
    {
        ReturnedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Checks if the browser is still connected and responsive.
    /// </summary>
    public Task<bool> IsHealthyAsync()
    {
        if (_disposed) return Task.FromResult(false);

        try
        {
            // Check if browser is still connected
            return Task.FromResult(Browser.IsConnected);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Closes all browser contexts to reset state between tests.
    /// </summary>
    public async Task CloseAllContextsAsync()
    {
        try
        {
            var contexts = Browser.Contexts.ToList();

            foreach (var context in contexts)
            {
                await context.CloseAsync().ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Error closing contexts for browser {Id}: {ex.Message}", "BROWSER_POOL");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        _disposed = true;

        Browser.Disconnected -= OnBrowserDisconnected;

        try
        {
            await Browser.CloseAsync().ConfigureAwait(false);
        }
        catch
        {
            // Ignore errors during browser close
        }
    }
}
