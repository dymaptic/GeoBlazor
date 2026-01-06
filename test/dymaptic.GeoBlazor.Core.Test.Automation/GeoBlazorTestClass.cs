using Microsoft.Playwright;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Web;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

public abstract class GeoBlazorTestClass : PlaywrightTest
{
    private IBrowser Browser { get; set; } = null!;
    private IBrowserContext Context { get; set; } = null!;
    
    public static string? GenerateTestName(MethodInfo? _, object?[]? data)
    {
        if (data is null || (data.Length == 0))
        {
            return null;
        }

        return data[0]?.ToString()?.Split('.').Last();
    }

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
        Browser = null!;
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
        string testMethodName = testName.Split('.').Last();
        
        try
        {
            string testUrl = BuildTestUrl(testName);
            Trace.WriteLine($"Navigating to {testUrl}", "TEST")
;            await page.GotoAsync(testUrl,
                _pageGotoOptions);
            Trace.WriteLine($"Page loaded for {testName}", "TEST");
            ILocator sectionToggle = page.GetByTestId("section-toggle");
            await sectionToggle.ClickAsync(_clickOptions);
            ILocator testBtn = page.GetByText("Run Test");
            await testBtn.ClickAsync(_clickOptions);
            ILocator passedSpan = page.GetByTestId("passed");
            ILocator inconclusiveSpan = page.GetByTestId("inconclusive");

            if (await inconclusiveSpan.IsVisibleAsync())
            {
                Assert.Inconclusive("Inconclusive test");

                return;
            }
            
            await Expect(passedSpan).ToBeVisibleAsync(_visibleOptions);
            await Expect(passedSpan).ToHaveTextAsync("Passed: 1");
            Trace.WriteLine($"{testName} Passed", "TEST");

            if (_consoleMessages.TryGetValue(testName, out List<string>? consoleMessages))
            {
                foreach (string message in consoleMessages)
                {
                    Trace.WriteLine(message, "TEST");
                }
            }
        }
        catch (Exception ex)
        {
            if (_errorMessages.TryGetValue(testMethodName, out List<string>? testErrors))
            {
                foreach (string error in testErrors.Distinct())
                {
                    Trace.WriteLine(error, "ERROR");
                }
            }
            else
            {
                Trace.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", "ERROR");
            }
            
            if (retries > 2)
            {
                Assert.Fail($"{testName} Failed");
            }
            
            await RunTestImplementation(testName, retries + 1);
        }
        finally
        {
            page.Console -= HandleConsoleMessage;
            page.PageError -= HandlePageError;
        }
    }

    private string BuildTestUrl(string testName) => $"{TestConfig.TestAppUrl}?testFilter={testName}&renderMode={TestConfig.RenderMode}{(TestConfig.ProOnly ? "&proOnly": "")}{(TestConfig.CoreOnly ? "&coreOnly" : "")}";

    private async Task Setup(int retries)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(retries, 2);

        try
        {
            var service = await BrowserService.Register(this, BrowserType, await ConnectOptionsAsync())
                .ConfigureAwait(false);
            var baseBrowser = service.Browser;
            Browser = await baseBrowser.BrowserType.LaunchAsync(_launchOptions);
            Context = await NewContextAsync(ContextOptions()).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            // transient error on setup found, seems to be very rare, so we will just retry
            Trace.WriteLine($"{e.Message}{Environment.NewLine}{e.StackTrace}", "ERROR");
            await Setup(retries + 1);
        }
    }

    private async Task<IBrowserContext> NewContextAsync(BrowserNewContextOptions? options)
    {
        var context = await Browser.NewContextAsync(options).ConfigureAwait(false);
        _contexts.Add(context);

        return context;
    }

    private BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            BaseURL = TestConfig.TestAppUrl, Locale = "en-US", ColorScheme = ColorScheme.Light,
            IgnoreHTTPSErrors = true
        };
    }

    // Set up console message logging
    private void HandleConsoleMessage(object? pageObject, IConsoleMessage message)
    {
        IPage page = (IPage)pageObject!;
        Uri uri = new(page.Url);
        string testName = HttpUtility.ParseQueryString(uri.Query)["testFilter"]!.Split('.').Last();
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

    private Dictionary<string, List<string>> _consoleMessages = [];
    private Dictionary<string, List<string>> _errorMessages = [];
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

    private readonly PageGotoOptions _pageGotoOptions = new()
    {
        WaitUntil = WaitUntilState.DOMContentLoaded, 
        Timeout = 60_000
    };

    private readonly LocatorClickOptions _clickOptions = new()
    {
        Timeout = 120_000
    };
    
    private readonly LocatorAssertionsToBeVisibleOptions _visibleOptions = new()
    {
        Timeout = 120_000
    };
}