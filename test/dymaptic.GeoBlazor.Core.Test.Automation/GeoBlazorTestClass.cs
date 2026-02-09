using Microsoft.Playwright;
using Polly;
using Polly.Retry;
using System.Web;
using DelayBackoffType = Polly.DelayBackoffType;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

public abstract class GeoBlazorTestClass : PlaywrightTest
{
    private IBrowserContext Context { get; set; } = null!;

    private PageGotoOptions PageGotoOptions => new() { WaitUntil = WaitUntilState.Commit, Timeout = 60_000 };

    private LocatorAssertionsToBeVisibleOptions VisibleOptions => new() { Timeout = 90_000 };

    [TestInitialize]
    public async Task TestSetup()
    {
        // transient error on setup found, seems to be very rare, so we will just retry
        await _retryPipeline.ExecuteAsync(async _ => await Setup());
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
        switch (TestContext.CurrentTestOutcome)
        {
            case UnitTestOutcome.Passed:
                if (!TestConfig.SkippedTests.Contains(TestContext.TestName))
                {
                    TestConfig.PassedTests.Add(TestContext.TestName);
                }

                break;
            case UnitTestOutcome.Failed:
                if (!TestConfig.FailedTests.ContainsKey(TestContext.TestName))
                {
                    throw new Exception($"Test {TestContext.TestName
                    } failed but was not added to FailedTests during the Exception handler");
                }

                break;
            case UnitTestOutcome.Inconclusive:
                TestConfig.FilteredTests!.Remove($"{GetType().Name.Split('_').Last()}.{TestContext.TestName}");
                TestConfig.InconclusiveTests.Add(TestContext.TestName);

                break;
            case UnitTestOutcome.Ignored:
                TestConfig.FilteredTests!.Remove($"{GetType().Name.Split('_').Last()}.{TestContext.TestName}");
                TestConfig.SkippedTests.Add(TestContext.TestName);

                break;
        }

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
                Trace.WriteLine($"Error returning browser to pool: {ex.Message}", ProcessName.WEB_TEST);
            }
            finally
            {
                _pooledBrowser = null;
            }
        }
    }

    protected async Task RunTestImplementation(string testName)
    {
        if (TestConfig.UnitOnly)
        {
            TestConfig.SkippedTests.Add(testName.Split('.').Last());
            TestConfig.FilteredTests!.Remove(testName);
            Trace.WriteLine($"{testName} Skipped", ProcessName.WEB_TEST);

            return;
        }

        if (!TestConfig.FilteredTests!.Contains(testName))
        {
            TestConfig.SkippedTests.Add(testName);
            Trace.WriteLine($"{testName} Skipped", ProcessName.WEB_TEST);

            return;
        }

        var page = await Context
            .NewPageAsync()
            .ConfigureAwait(false);
        page.Console += HandleConsoleMessage;
        page.PageError += HandlePageError;

        try
        {
            string testUrl = BuildTestUrl(testName);

            using var testCts = CancellationTokenSource.CreateLinkedTokenSource(TestConfig.Cts.Token);
            testCts.CancelAfter(TimeSpan.FromMinutes(3));

            var context = ResilienceContextPool.Shared.Get(
                new ResilienceContextCreationArguments(testName, null, testCts.Token));

            await _retryPipeline.ExecuteAsync(async ctx =>
            {
                _consoleMessages[testName] = [];
                _errorMessages[testName] = [];

                Trace.WriteLine($"Navigating to {testUrl}", ProcessName.WEB_TEST);

                await page.GotoAsync(testUrl, PageGotoOptions);
                Trace.WriteLine($"Page loaded for {testName}", ProcessName.WEB_TEST);

                if (ctx.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                // Skip section toggle click if already expanded (optimization)
                ILocator sectionToggle = page.GetByTestId("section-toggle");
                var isExpanded = await sectionToggle.GetAttributeAsync("aria-expanded");

                if (isExpanded != "true")
                {
                    await sectionToggle.ClickAsync();
                }

                if (ctx.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                ILocator testBtn = page.GetByText("Run Test");
                await testBtn.ClickAsync();

                if (ctx.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                ILocator passedSpan = page.GetByTestId("passed");
                ILocator inconclusiveSpan = page.GetByTestId("inconclusive");

                if (await inconclusiveSpan.IsVisibleAsync())
                {
                    var (messages, errors) = CheckMessages(testName);
                    Trace.WriteLine(messages, ProcessName.WEB_TEST);

                    if (!string.IsNullOrWhiteSpace(errors))
                    {
                        // report errors but don't fail the test
                        Trace.WriteLine(errors, ProcessName.WEB_TEST_ERROR);
                    }

                    // Inconclusive we treat as passing for our automation purposes
                    Trace.WriteLine($"{testName} Inconclusive", ProcessName.WEB_TEST);
                    TestConfig.InconclusiveTests.Add(testName);
                    TestConfig.FilteredTests.Remove(testName);
                    TestConfig.WebInconclusiveTestCount++;
                }
                else
                {
                    await Expect(passedSpan).ToBeVisibleAsync(VisibleOptions);
                    await Expect(passedSpan).ToHaveTextAsync("Passed: 1");
                    var (messages, errors) = CheckMessages(testName);
                    Trace.WriteLine(messages, ProcessName.WEB_TEST);

                    if (!string.IsNullOrWhiteSpace(errors))
                    {
                        // these are typically browser console errors, the assertions in the
                        // test runner web app decides whether to fail the test or not
                        // so we just log here
                        Trace.WriteLine(errors, ProcessName.WEB_TEST_ERROR);
                    }

                    Trace.WriteLine($"{testName} Passed", ProcessName.WEB_TEST);
                    Trace.WriteLine($"{testName}: Adding 1 passed tests to total test count", ProcessName.WEB_TEST);
                }
            }, context);
        }
        catch (Exception)
        {
            var (messages, errors) = CheckMessages(testName);
            Trace.WriteLine(messages, ProcessName.WEB_TEST);
            Trace.WriteLine(errors, ProcessName.WEB_TEST_ERROR);

            TestConfig.FailedTests[testName] = $"{messages}{Environment.NewLine}{errors}";
            TestConfig.WebFailedTestCount++;
            Assert.Fail($"{testName} Failed: {errors}");
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

    private async Task Setup()
    {
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
            Trace.WriteLine($"{e.Message}{Environment.NewLine}{e.StackTrace}", ProcessName.WEB_TEST_ERROR);

            // If browser failed during setup, report it to the pool
            if (_pooledBrowser is not null)
            {
                await BrowserPool.GetInstance(BrowserType, _launchOptions!, TestConfig.BrowserPoolSize)
                    .ReportFailedAsync(_pooledBrowser)
                    .ConfigureAwait(false);
                _pooledBrowser = null;
            }

            throw;
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

    private static readonly RetryStrategyOptions retryStrategyOptions = new()
    {
        BackoffType = DelayBackoffType.Exponential,
        MaxRetryAttempts = 2,
        Delay = TimeSpan.FromSeconds(5),
        OnRetry = args =>
        {
            Trace.WriteLine($"Attempt {args.AttemptNumber + 1} failed. Retrying {args.Context.OperationKey} in {
                args.RetryDelay.TotalSeconds} seconds.",
                ProcessName.WEB_TEST);

            return ValueTask.CompletedTask;
        }
    };

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
    private readonly ResiliencePipeline _retryPipeline = new ResiliencePipelineBuilder()
        .AddRetry(retryStrategyOptions)
        .Build();

    private readonly Dictionary<string, List<string>> _consoleMessages = [];
    private readonly Dictionary<string, List<string>> _errorMessages = [];
    private PooledBrowser? _pooledBrowser;
}