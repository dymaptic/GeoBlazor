using Microsoft.Playwright;
using System.Web;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

public abstract class GeoBlazorTestClass : PlaywrightTest
{
    private IBrowserContext Context { get; set; } = null!;

    private PageGotoOptions PageGotoOptions => new() { WaitUntil = WaitUntilState.Commit, Timeout = 60_000 };

    private LocatorAssertionsToBeVisibleOptions VisibleOptions => new() { Timeout = 90_000 };

    [TestInitialize]
    public Task TestSetup()
    {
        return Setup(0);
    }

    [TestCleanup]
    public async Task BrowserTearDown()
    {
        if (TestOK())
        {
            foreach (var context in _contexts)
            {
                await context.CloseAsync().ConfigureAwait(false);
            }
        }

        _contexts.Clear();

        // Return browser to pool instead of abandoning it
        if (_pooledBrowser is not null)
        {
            try
            {
                await BrowserPool.GetInstance(BrowserType, _launchOptions!, TestConfig.BrowserPoolSize)
                    .ReturnAsync(_pooledBrowser)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error returning browser to pool: {ex.Message}", "TEST");
            }
            finally
            {
                _pooledBrowser = null;
            }
        }
    }

    protected virtual Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
    {
        return Task.FromResult<(string, BrowserTypeConnectOptions?)?>(null);
    }

    protected async Task RunTestImplementation(string testName, int retries = 0)
    {
        var page = await Context
            .NewPageAsync()
            .ConfigureAwait(false);
        page.Console += HandleConsoleMessage;
        page.PageError += HandlePageError;

        try
        {
            string testUrl = BuildTestUrl(testName);

            Trace.WriteLine($"Navigating to {testUrl}", "TEST");

            await page.GotoAsync(testUrl, PageGotoOptions);
            Trace.WriteLine($"Page loaded for {testName}", "TEST");

            // Skip section toggle click if already expanded (optimization)
            ILocator sectionToggle = page.GetByTestId("section-toggle");
            var isExpanded = await sectionToggle.GetAttributeAsync("aria-expanded");

            if (isExpanded != "true")
            {
                await sectionToggle.ClickAsync();
            }

            ILocator testBtn = page.GetByText("Run Test");
            await testBtn.ClickAsync();

            ILocator passedSpan = page.GetByTestId("passed");
            ILocator inconclusiveSpan = page.GetByTestId("inconclusive");

            if (await inconclusiveSpan.IsVisibleAsync())
            {
                var (messages, errors) = CheckMessages(testName);
                Trace.WriteLine(messages, "TEST_RESPONSE");

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    // report errors but don't fail the test
                    Trace.WriteLine(errors, "TEST_ERROR");
                }

                // Inconclusive we treat as passing for our automation purposes
                Trace.WriteLine($"{testName} Inconclusive", "TEST_INCONCLUSIVE");
                TestConfig.InconclusiveTests.Add(testName);
            }
            else
            {
                await Expect(passedSpan).ToBeVisibleAsync(VisibleOptions);
                await Expect(passedSpan).ToHaveTextAsync("Passed: 1");
                var (messages, errors) = CheckMessages(testName);
                Trace.WriteLine(messages, "TEST_RESPONSE");

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    Trace.WriteLine(errors, "TEST_ERROR");
                    await RetryOrMarkAsFailure(page, testName, new Exception(errors), retries);

                    return;
                }

                Trace.WriteLine($"{testName} Passed", "TEST");
            }
        }
        catch (Exception ex)
        {
            var (messages, errors) = CheckMessages(testName);
            Trace.WriteLine(messages, "TEST_RESPONSE");
            Trace.WriteLine(errors, "TEST_ERROR");
            await RetryOrMarkAsFailure(page, testName, ex, retries);
        }
        finally
        {
            page.Console -= HandleConsoleMessage;
            page.PageError -= HandlePageError;
        }
    }

    private string BuildTestUrl(string testName)
    {
        return $"{TestConfig.TestAppUrl}?testFilter={testName}&renderMode={
            TestConfig.RenderMode}{(TestConfig.ProOnly ? "&proOnly" : "")}{(TestConfig.CoreOnly ? "&coreOnly" : "")}";
    }

    private async Task Setup(int retries)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(retries, 2);

        try
        {
            // Get pool instance and checkout a browser
            var pool = BrowserPool.GetInstance(BrowserType,
                _launchOptions!,
                TestConfig.BrowserPoolSize);

            _pooledBrowser = await pool.CheckoutAsync().ConfigureAwait(false);

            // Create context on the pooled browser
            Context = await NewContextAsync(ContextOptions()).ConfigureAwait(false);
            Context.SetDefaultTimeout(60_000);
        }
        catch (Exception e)
        {
            // transient error on setup found, seems to be very rare, so we will just retry
            Trace.WriteLine($"{e.Message}{Environment.NewLine}{e.StackTrace}", "ERROR");

            // If browser failed during setup, report it to the pool
            if (_pooledBrowser is not null)
            {
                await BrowserPool.GetInstance(BrowserType, _launchOptions!, TestConfig.BrowserPoolSize)
                    .ReportFailedAsync(_pooledBrowser)
                    .ConfigureAwait(false);
                _pooledBrowser = null;
            }

            await Setup(retries + 1);
        }
    }

    private async Task<IBrowserContext> NewContextAsync(BrowserNewContextOptions? options)
    {
        var context = await _pooledBrowser!.Browser.NewContextAsync(options).ConfigureAwait(false);
        _contexts.Add(context);

        return context;
    }

    private BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            BaseURL = TestConfig.TestAppUrl,
            Locale = "en-US",
            ColorScheme = ColorScheme.Light,
            IgnoreHTTPSErrors = true
        };
    }

    private (string Messages, string Errors) CheckMessages(string testName)
    {
        StringBuilder messageBuilder = new();
        StringBuilder errorBuilder = new();

        if (_consoleMessages.TryGetValue(testName, out var consoleMessages))
        {
            foreach (var message in consoleMessages)
            {
                messageBuilder.AppendLine(message);
            }
        }

        if (_errorMessages.TryGetValue(testName, out var errorMessages))
        {
            foreach (var message in errorMessages)
            {
                errorBuilder.AppendLine(message);
            }
        }

        return (messageBuilder.ToString(), errorBuilder.ToString());
    }

    // Set up console message logging
    private void HandleConsoleMessage(object? pageObject, IConsoleMessage message)
    {
        IPage page = (IPage)pageObject!;
        Uri uri = new(page.Url);
        string testName = HttpUtility.ParseQueryString(uri.Query)["testFilter"]!;

        if (message.Type == "error" || message.Text.Contains("error"))
        {
            if (!_errorMessages.ContainsKey(testName))
            {
                _errorMessages[testName] = [];
            }

            _errorMessages[testName].Add(message.Text);
        }
        else
        {
            if (!_consoleMessages.ContainsKey(testName))
            {
                _consoleMessages[testName] = [];
            }

            _consoleMessages[testName].Add(message.Text);
        }
    }

    private void HandlePageError(object? pageObject, string message)
    {
        IPage page = (IPage)pageObject!;
        Uri uri = new(page.Url);
        string testName = HttpUtility.ParseQueryString(uri.Query)["testFilter"]!.Split('.').Last();

        if (!_errorMessages.ContainsKey(testName))
        {
            _errorMessages[testName] = [];
        }

        _errorMessages[testName].Add(message);
    }

    private async Task RetryOrMarkAsFailure(IPage page, string testName, Exception ex, int retries)
    {
        if (retries > 2)
        {
            TestConfig.FailedTests[testName] = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}";
            Assert.Fail($"{testName} Exceeded the maximum number of retries.");
        }

        // Exponential backoff: 1s, 2s between retries
        var backoffMs = 1000 * (retries + 1);
        Trace.WriteLine($"Retrying {testName} in {backoffMs}ms (attempt {retries + 2}/3)", "TEST");
        await Task.Delay(backoffMs);

        page.Console -= HandleConsoleMessage;
        page.PageError -= HandlePageError;
        _consoleMessages.Remove(testName);
        _errorMessages.Remove(testName);

        await RunTestImplementation(testName, retries + 1);
    }

    private readonly List<IBrowserContext> _contexts = new();
    private readonly BrowserTypeLaunchOptions? _launchOptions = new()
    {
        Args =
        [
            "--no-sandbox",
            "--disable-setuid-sandbox",
            "--ignore-certificate-errors",
            "--ignore-gpu-blocklist",
            "--enable-webgl",
            "--enable-webgl2-compute-context",
            "--use-angle=default",
            "--enable-gpu-rasterization",
            "--enable-features=Vulkan",
            "--enable-unsafe-webgpu"
        ]
    };

    private readonly Dictionary<string, List<string>> _consoleMessages = [];
    private readonly Dictionary<string, List<string>> _errorMessages = [];
    private PooledBrowser? _pooledBrowser;
}