using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;
using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Pages;

public partial class Index
{
    [Inject]
    public required IJSRuntime JsRuntime { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    [Inject]
    public required JsModuleManager JsModuleManager { get; set; }
    [Inject]
    public required ITestLogger TestLogger { get; set; }
    [Inject]
    public required IAppValidator AppValidator { get; set; }
    [Inject]
    public required IConfiguration Configuration { get; set; }
    [CascadingParameter(Name = nameof(RunOnStart))]
    public required bool RunOnStart { get; set; }
    /// <summary>
    ///     Only run Pro Tests
    /// </summary>
    [CascadingParameter(Name = nameof(ProOnly))]
    public required bool ProOnly { get; set; }
    
    [CascadingParameter(Name = nameof(TestFilter))]
    public string? TestFilter { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (_allPassed)
        {
            return;
        }

        if (firstRender)
        {
            try
            {
                await AppValidator.ValidateLicense();
            }
            catch (Exception)
            {
                IConfigurationSection geoblazorConfig = Configuration.GetSection("GeoBlazor");

                throw new InvalidRegistrationException($"Failed to validate GeoBlazor License Key: {
                    geoblazorConfig.GetValue("LicenseKey", geoblazorConfig.GetValue("RegistrationKey", "No Key Found"))
                }");
            }

            _jsTestRunner = await JsRuntime.InvokeAsync<IJSObjectReference>("import",
                "./_content/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/testRunner.js");
            IJSObjectReference? proJs = await JsModuleManager.GetProJsModule(JsRuntime, CancellationToken.None);
            IJSObjectReference coreJs = await JsModuleManager.GetCoreJsModule(JsRuntime, proJs, CancellationToken.None);
            WFSServer[] wfsServers = Configuration.GetSection("WFSServers").Get<WFSServer[]>()!;
            await _jsTestRunner.InvokeVoidAsync("initialize", coreJs, wfsServers);

            NavigationManager.RegisterLocationChangingHandler(OnLocationChanging);

            await LoadSettings();

            if (!_settings.RetainResultsOnReload)
            {
                return;
            }

            FindAllTests();

            Dictionary<string, TestResult>? cachedResults =
                await _jsTestRunner.InvokeAsync<Dictionary<string, TestResult>?>("getTestResults");

            if (cachedResults is { Count: > 0 })
            {
                _results = cachedResults;
            }

            if (_results!.Count > 0)
            {
                string? firstUnpassedClass = _testClassNames
                    .FirstOrDefault(t => !_results.ContainsKey(t)
                        || (_results[t].Passed.Count == 0 && _results[t].Inconclusive.Count == 0));

                if (firstUnpassedClass is not null && _testClassNames.IndexOf(firstUnpassedClass) > 0)
                {
                    await ScrollAndOpenClass(firstUnpassedClass);
                }
            }

            // need an extra render cycle to register the `_testComponents` dictionary
            StateHasChanged();
        }
        else if (RunOnStart && !_running)
        {
            // Auto-run configuration
            _running = true;

            // give everything time to load correctly
            await Task.Delay(1000);
            await TestLogger.Log("Starting Test Auto-Run:");
            string? attempts = await JsRuntime.InvokeAsync<string?>("localStorage.getItem", "runAttempts");

            int attemptCount = 0;

            if (attempts is not null && int.TryParse(attempts, out attemptCount))
            {
                await TestLogger.Log($"Attempt #{attemptCount}");
            }

            await TestLogger.Log("----------");

            _allPassed = await RunTests(true, _cts.Token);

            if (!_allPassed)
            {
                await TestLogger.Log(
                    "Test Run Failed or Errors Encountered. Reload the page to re-run failed tests.");
                attemptCount++;
                await JsRuntime.InvokeVoidAsync("localStorage.setItem", "runAttempts", attemptCount);
            }
        }
    }

    private void FindAllTests()
    {
        _results = [];
        Type[] types;

        if (ProOnly)
        {
            var proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro.Test.Blazor.Shared");

            types = proAssembly.GetTypes()
                .Where(t => t.Name != "ProTestRunnerBase")
                .ToArray();
        }
        else
        {
            var assembly = Assembly.Load("dymaptic.GeoBlazor.Core.Test.Blazor.Shared");
            types = assembly.GetTypes();

            try
            {
                var proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro.Test.Blazor.Shared");

                types = types.Concat(proAssembly.GetTypes()
                        .Where(t => t.Name != "ProTestRunnerBase"))
                    .ToArray();
            }
            catch
            {
                //ignore if not running pro
            }
        }

        foreach (Type type in types)
        {
            if (!string.IsNullOrWhiteSpace(TestFilter))
            {
                string filter = TestFilter.Split('.')[0];
                if (!Regex.IsMatch(type.Name, $"^{filter}$", RegexOptions.IgnoreCase))
                {
                    continue;
                }
            }

            if (type.IsAssignableTo(typeof(TestRunnerBase)) && (type.Name != nameof(TestRunnerBase)))
            {
                _testClassTypes.Add(type);
                _testComponents[type.Name] = null;

                int testCount = type.GetMethods()
                    .Count(m => m.GetCustomAttribute(typeof(TestMethodAttribute), false) != null);
                _results![type.Name] = new TestResult(type.Name, testCount, [], [], [], false);
            }
        }

        // sort alphabetically
        _testClassTypes.Sort((t1, t2) => string.Compare(t1.Name, t2.Name, StringComparison.Ordinal));
        _testClassNames = _testClassTypes.Select(t => t.Name).ToList();
    }

    private async Task RunNewTests(bool onlyFailedTests = false, CancellationToken token = default)
    {
        string? firstUntestedClass = _testClassNames
            .FirstOrDefault(t => !_results!.ContainsKey(t)
                || (_results[t].Passed.Count == 0 && _results[t].Inconclusive.Count == 0));

        if (firstUntestedClass is not null)
        {
            int index = _testClassNames.IndexOf(firstUntestedClass);
            await RunTests(onlyFailedTests, token, index);
        }
        else
        {
            await RunTests(onlyFailedTests, token);
        }
    }

    private async Task<bool> RunTests(bool onlyFailedTests = false, CancellationToken token = default,
        int offset = 0)
    {
        _running = true;

        foreach (var kvp in _testComponents.OrderBy(k => _testClassNames.IndexOf(k.Key)).Skip(offset))
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            if (_results!.TryGetValue(kvp.Key, out TestResult? results))
            {
                if (onlyFailedTests && results.Failed.Count == 0
                    && (results.Passed.Count > 0 || results.Inconclusive.Count > 0))
                {
                    break;
                }
            }

            if (kvp.Value != null)
            {
                await kvp.Value!.RunTests(onlyFailedTests, cancellationToken: token);
            }
        }

        var resultBuilder = new StringBuilder($"""

                                               # GeoBlazor Unit Test Results
                                               {DateTime.Now}
                                               Passed: {_results!.Values.Select(r => r.Passed.Count).Sum()}
                                               Failed: {_results.Values.Select(r => r.Failed.Count).Sum()}
                                               Inconclusive: {_results.Values.Select(r => r.Inconclusive.Count).Sum()}
                                               """);

        foreach (KeyValuePair<string, TestResult> result in _results)
        {
            resultBuilder.AppendLine($"""

                                      ## {result.Key}
                                      Passed: {result.Value.Passed.Count}
                                      Failed: {result.Value.Failed.Count}
                                      Inconclusive: {result.Value.Inconclusive.Count}
                                      """);

            foreach (KeyValuePair<string, string?> methodResult in result.Value.Passed)
            {
                resultBuilder.AppendLine($"""
                                          ### {methodResult.Key} - Passed
                                          {methodResult.Value}
                                          """);
            }

            foreach (KeyValuePair<string, string?> methodResult in result.Value.Failed)
            {
                resultBuilder.AppendLine($"""
                                          ### {methodResult.Key} - Failed
                                          {methodResult.Value}
                                          """);
            }

            foreach (KeyValuePair<string, string?> methodResult in result.Value.Inconclusive)
            {
                resultBuilder.AppendLine($"""
                                          ### {methodResult.Key} - Inconclusive
                                          {methodResult.Value}
                                          """);
            }
        }

        await TestLogger.Log(resultBuilder.ToString());

        await InvokeAsync(async () =>
        {
            StateHasChanged();
            await Task.Delay(1000, token);
            _running = false;
        });

        return _results.Values.All(r => r.Failed.Count == 0);
    }

    private async Task OnTestResults(TestResult result)
    {
        _results![result.ClassName] = result;
        await SaveResults();
        await InvokeAsync(StateHasChanged);

        if (_settings.StopOnFail && result.Failed.Count > 0)
        {
            await CancelRun();
            await ScrollAndOpenClass(result.ClassName);
        }
    }

    private void ToggleAll()
    {
        _showAll = !_showAll;

        foreach (TestWrapper? component in _testComponents.Values)
        {
            component?.Toggle(_showAll);
        }
    }

    private async Task ScrollAndOpenClass(string className)
    {
        await _jsTestRunner!.InvokeVoidAsync("scrollToTestClass", className);
        TestWrapper? testClass = _testComponents[className];
        testClass?.Toggle(true);
    }

    private async Task CancelRun()
    {
        await _jsTestRunner!.InvokeVoidAsync("setWaitCursor", false);
        await Task.Yield();

        await InvokeAsync(async () =>
        {
            await _cts.CancelAsync();
            _cts = new CancellationTokenSource();
            _running = false;
        });
    }

    private async ValueTask OnLocationChanging(LocationChangingContext context)
    {
        await SaveResults();
    }

    private async Task SaveResults()
    {
        await _jsTestRunner!.InvokeVoidAsync("saveTestResults", _results);
    }

    private async Task SaveSettings()
    {
        await _jsTestRunner!.InvokeVoidAsync("saveSettings", _settings);
    }

    private async Task LoadSettings()
    {
        TestSettings? settings = await _jsTestRunner!.InvokeAsync<TestSettings?>("loadSettings");

        if (settings is not null)
        {
            _settings = settings;
        }
    }

    private MarkupString BuildResultSummaryLine(string testName, TestResult result)
    {
        StringBuilder builder = new(testName);
        builder.Append(" - ");

        if (result.Pending > 0)
        {
            builder.Append($"<span class=\"pending\">Pending: {result.Pending}</span>");
        }

        if (result.Passed.Count > 0 || result.Failed.Count > 0 || result.Inconclusive.Count > 0)
        {
            if (result.Pending > 0)
            {
                builder.Append(" | ");
            }
            builder.Append($"<span class=\"passed\">Passed: {result.Passed.Count}</span>");
            builder.Append(" | ");
            builder.Append($"<span class=\"failed\">Failed: {result.Failed.Count}</span>");
            if (result.Inconclusive.Count > 0)
            {
                builder.Append(" | ");
                builder.Append($"<span class=\"inconclusive\">Failed: {result.Inconclusive.Count}</span>");
            }
        }

        return new MarkupString(builder.ToString());
    }

    private int Remaining => _results?.Sum(r =>
        r.Value.TestCount - (r.Value.Passed.Count + r.Value.Failed.Count + r.Value.Inconclusive.Count)) ?? 0;
    private int Passed => _results?.Sum(r => r.Value.Passed.Count) ?? 0;
    private int Failed => _results?.Sum(r => r.Value.Failed.Count) ?? 0;
    private int Inconclusive => _results?.Sum(r => r.Value.Inconclusive.Count) ?? 0;
    private IJSObjectReference? _jsTestRunner;
    private Dictionary<string, TestResult>? _results;
    private bool _running;
    private readonly List<Type> _testClassTypes = [];
    private List<string> _testClassNames = [];
    private readonly Dictionary<string, TestWrapper?> _testComponents = new();
    private bool _showAll;
    private CancellationTokenSource _cts = new();
    private TestSettings _settings = new(false, true);
    private bool _allPassed;

    public record TestSettings(bool StopOnFail, bool RetainResultsOnReload)
    {
        public bool StopOnFail { get; set; } = StopOnFail;
        public bool RetainResultsOnReload { get; set; } = RetainResultsOnReload;
    }
    
    private record WFSServer(string Url, string OutputFormat);
}