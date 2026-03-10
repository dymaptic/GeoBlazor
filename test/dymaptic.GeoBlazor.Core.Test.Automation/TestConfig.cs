using CliWrap;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Polly;
using Polly.Retry;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using System.Xml;
using DelayBackoffType = Polly.DelayBackoffType;


[assembly: Parallelize(Scope = ExecutionScope.MethodLevel, Workers = 16)]


namespace dymaptic.GeoBlazor.Core.Test.Automation;

[TestClass]
public class TestConfig
{
    public static IConfiguration Configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true)
#if DEBUG
        .AddJsonFile("appsettings.Development.json", true)
#else
            .AddJsonFile("appsettings.Production.json", true)
#endif
        .AddUserSecrets<TestConfig>()
        .AddEnvironmentVariables()
        .AddDotEnvFile(true, false)
        .AddCommandLine(Environment.GetCommandLineArgs())
        .Build();
    
    public static readonly string ProjectFolder = Assembly.GetAssembly(typeof(TestConfig))!.Location.Contains("bin")
        ? Assembly.GetAssembly(typeof(TestConfig))!.Location.Split("bin").First().TrimEnd(Path.PathSeparator)
        : Assembly.GetAssembly(typeof(TestConfig))!.Location;

    public static readonly bool ProAvailable =
        File.Exists(Path.GetFullPath(Path.Combine(ProjectFolder, "..", "..", "..", "Dockerfile")));
    
    public static int HttpsPort = Configuration.GetValue("HTTPS_PORT", 9443);
    public static int HttpPort = Configuration.GetValue("HTTP_PORT", 8080);

    public static string TestAppUrl = Configuration.GetValue("WEB_APP_URL", $"https://localhost:{HttpsPort}");
    public static BlazorMode RenderMode { get; private set; }
    public static bool CoreOnly => FilteredTests[ProcessName.PRO_UNIT].Count == 0
        && FilteredTests[ProcessName.PRO_VALIDATION].Count == 0
        && FilteredTests[ProcessName.WEB_TEST].Count(t => t.ClassName.StartsWith("PRO_")) == 0;
    public static bool ProOnly => FilteredTests[ProcessName.CORE_UNIT].Count == 0
        && FilteredTests[ProcessName.WEB_TEST].Count(t => t.ClassName.StartsWith("CORE_")) == 0;
    public static bool UnitOnly => FilteredTests[ProcessName.WEB_TEST].Count == 0;
    public static bool WebOnly => FilteredTests[ProcessName.CORE_UNIT].Count == 0
        && FilteredTests[ProcessName.PRO_UNIT].Count == 0
        && FilteredTests[ProcessName.PRO_VALIDATION].Count == 0;

    /// <summary>
    ///     Maximum number of concurrent browser instances in the pool.
    ///     Configurable via BROWSER_POOL_SIZE environment variable.
    ///     Default: 4 for CI environments, 8 for local development.
    /// </summary>
    public static int BrowserPoolSize { get; private set; } = 4;

    /// <summary>
    ///     Indicates whether the tests are running in a CI environment.
    ///     Used for timeout and pool size configuration.
    /// </summary>
    public static bool IsCI { get; private set; }

    public static ConcurrentDictionary<string, Dictionary<string, string>> FailedTests { get; } = new();

    public static ConcurrentDictionary<string, byte> InconclusiveTests { get; } = new();
    public static ConcurrentDictionary<string, byte> PassedTests { get; } = new();
    public static ConcurrentDictionary<string, byte> SkippedTests { get; } = new();
    public static Dictionary<string, List<TestRecord>> FilteredTests { get; set; } = new()
    {
        [ProcessName.WEB_TEST] = [],
        [ProcessName.CORE_UNIT] = [],
        [ProcessName.PRO_UNIT] = [],
        [ProcessName.PRO_VALIDATION] = []
    };

    private static string ComposeFilePath => ProAvailable && !CoreOnly ? ProComposeFilePath : CoreComposeFilePath;
    private static string CoreComposeFilePath => Path.Combine(ProjectFolder, "docker-compose-core.yml");
    private static string ProComposeFilePath => Path.Combine(ProjectFolder, "docker-compose-pro.yml");
    private static string CoreUnitTestComposeFilePath => Path.Combine(ProjectFolder, "docker-compose-core-unit.yml");
    private static string ProUnitTestComposeFilePath => Path.Combine(ProjectFolder, "docker-compose-pro-unit.yml");
    private static string ProValidationTestComposeFilePath =>
        Path.Combine(ProjectFolder, "docker-compose-pro-validation.yml");
    private static string TestAppPath => ProAvailable
        ? Path.GetFullPath(Path.Combine(ProjectFolder, "..", "..", "..", "test",
            "dymaptic.GeoBlazor.Pro.Test.WebApp",
            "dymaptic.GeoBlazor.Pro.Test.WebApp",
            "dymaptic.GeoBlazor.Pro.Test.WebApp.csproj"))
        : Path.GetFullPath(Path.Combine(ProjectFolder, "..",
            "dymaptic.GeoBlazor.Core.Test.WebApp",
            "dymaptic.GeoBlazor.Core.Test.WebApp",
            "dymaptic.GeoBlazor.Core.Test.WebApp.csproj"));
    private static string TestAppHttpUrl => $"http://localhost:{HttpPort}";
    private static string CoverageFolderPath => Path.Combine(ProjectFolder, "coverage");
    private static string CoverageFilePath =>
        Path.Combine(CoverageFolderPath, $"coverage.{_coverageFileVersion}.{_coverageFormat}");
    private static string UnitCoverageFolderPath => Path.Combine(ProjectFolder, "unit-coverage");
    private static string CoreUnitCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.core.unit.{_coverageFileVersion}.{_coverageFormat}");
    private static string ProUnitCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.pro.unit.{_coverageFileVersion}.{_coverageFormat}");
    private static string ProValidationCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.pro.validation.{_coverageFileVersion}.{_coverageFormat}");
    private static string CoreRepoRoot => Path.GetFullPath(Path.Combine(ProjectFolder, "..", ".."));
    private static string ProRepoRoot => Path.GetFullPath(Path.Combine(ProjectFolder, "..", "..", ".."));
    private static string CoreProjectPath =>
        Path.GetFullPath(Path.Combine(CoreRepoRoot, "src", "dymaptic.GeoBlazor.Core"));
    private static string ProProjectPath =>
        Path.GetFullPath(Path.Combine(ProRepoRoot, "src", "dymaptic.GeoBlazor.Pro"));
    private static string CoreUnitTestPath => Path.Combine(CoreRepoRoot, "test",
        "dymaptic.GeoBlazor.Core.Test.Unit",
        "dymaptic.GeoBlazor.Core.Test.Unit.csproj");
    private static string ProUnitTestPath => Path.Combine(ProRepoRoot, "test",
        "dymaptic.GeoBlazor.Pro.Test.Unit",
        "dymaptic.GeoBlazor.Pro.Test.Unit.csproj");
    private static string ProValidationTestPath => Path.Combine(ProRepoRoot, "test",
        "dymaptic.GeoBlazor.Pro.Test.Validation",
        "dymaptic.GeoBlazor.Pro.Test.Validation.csproj");
    private static string LogFilePath => Path.Combine(ProjectFolder, "test-run.log");
    public static int WebFailedTestCount;
    public static int WebInconclusiveTestCount;

    public static readonly CancellationTokenSource Cts = new();

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        fullSuiteStopwatch.Start();
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new StringBuilderTraceListener(logBuilders));
        Trace.AutoFlush = true;

        // Handle Ctrl-C gracefully
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true; // Prevent immediate termination to allow cleanup
            Trace.WriteLine("Ctrl-C detected, initiating shutdown...", ProcessName.TEST_SHUTDOWN);

            _ = Task.Run(AssemblyCleanup);

            int timeoutSeconds = 30;

            while (!_cleanupComplete && (timeoutSeconds > 0))
            {
                Thread.Sleep(1000);
                timeoutSeconds--;
            }

            if (_cleanupComplete)
            {
                Trace.WriteLine("Shutdown complete", ProcessName.TEST_SHUTDOWN);
                Environment.Exit(1);

                return;
            }

            // Trigger cancellation
            if (!Cts.IsCancellationRequested)
            {
                Cts.Cancel();
            }

            if (!gracefulCts.IsCancellationRequested)
            {
                gracefulCts.Cancel();
            }

            _ = Task.Run(async () =>
            {
                // Force exit after timeout if cleanup hangs
                await Task.Delay(15000); // an extra 15 second timeout for cleanup
                Trace.WriteLine("Cleanup timeout - forcing exit", ProcessName.TEST_SHUTDOWN);
                Environment.Exit(1);
            });
        };

        SetupConfiguration();

        if (!IsCI && _showDialog)
        {
            string os = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "win"
                : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                    ? "osx"
                    : "linux";
            string arch = RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant();

            Utilities.StartConsoleDialog(Path.Combine(CoreRepoRoot, "build-tools", $"{os}-{arch}"),
                "GeoBlazor Unit Tests");
        }

        Trace.WriteLine($"Running tests for {_runConfig} on {_targetFramework}...", ProcessName.TEST_SETUP);

        Trace.WriteLine($"Test Filters: {(_filters is null ? "NONE" : string.Join(", ", _filters))}",
            ProcessName.TEST_SETUP);
        Trace.WriteLine($"Generating Test Coverage Report: {_cover}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using Browser Pool Size: {BrowserPoolSize}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using Render Mode: {RenderMode}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using Container: {_useContainer}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Docker No-Cache: {_noCache}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using HTTPS Port: {HttpsPort}", ProcessName.TEST_SETUP);

        if (CoreOnly)
        {
            Trace.WriteLine("Running Core Tests Only", ProcessName.TEST_SETUP);
        }
        else if (ProOnly)
        {
            Trace.WriteLine("Running Pro Tests Only", ProcessName.TEST_SETUP);
        }
        else
        {
            Trace.WriteLine("Running Core and Pro Tests on Pro test runner", ProcessName.TEST_SETUP);
        }

        // kill old running test apps and containers
        Task[] cleanupTasks =
        [
            StopContainer(CoreComposeFilePath),
            StopContainer(ProComposeFilePath),
            StopContainer(CoreUnitTestComposeFilePath),
            StopContainer(ProUnitTestComposeFilePath),
            StopContainer(ProValidationTestComposeFilePath),
            KillProcessesByTestPorts()
        ];

        await Task.WhenAll(cleanupTasks);

        List<Task> setupTasks =
        [
            EnsurePlaywrightBrowsersAreInstalled()
        ];

        if (_cover)
        {
            setupTasks.Add(InstallCodeCoverageTools());
        }

        await Task.WhenAll(setupTasks);

        // UNIT TESTS
        if (!WebOnly)
        {
            if (!ProOnly)
            {
                runTasks.Add(LaunchPipelineTask(ProcessName.CORE_UNIT, LaunchUnitTests));
            }

            if (!CoreOnly)
            {
                runTasks.Add(LaunchPipelineTask(ProcessName.PRO_UNIT, LaunchUnitTests));
                runTasks.Add(LaunchPipelineTask(ProcessName.PRO_VALIDATION, LaunchUnitTests));
            }
        }

        // Fire off the Web Browser for main web tests suite
        if (!UnitOnly)
        {
            await LaunchPipelineTask(ProcessName.WEB_APP_SERVER, LaunchWebTests);
        }
        
        await Task.WhenAll(runTasks);

        Trace.WriteLine($"Assembly Initialization Complete in {fullSuiteStopwatch.Elapsed.Minutes}m {
            fullSuiteStopwatch.Elapsed.Seconds}s",
            ProcessName.TEST_SETUP);
        _webTestStartTime = DateTime.UtcNow;
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        // ensure unit tests have completed
        if (runTasks.Any())
        {
            await Task.WhenAll(runTasks);
        }

        Stopwatch cleanupStopwatch = new();
        cleanupStopwatch.Start();
        DateTime webTestEndTime = DateTime.UtcNow;

        try
        {
            bool isCancelled = Cts.IsCancellationRequested;

            // Dispose browser pool first
            if (BrowserPool.TryGetInstance(out BrowserPool? pool) && pool is not null)
            {
                Trace.WriteLine("Disposing browser pool...", ProcessName.TEST_CLEANUP);

                try
                {
                    using CancellationTokenSource timeoutCts = new(TimeSpan.FromSeconds(isCancelled ? 3 : 10));
                    await pool.DisposeAsync().ConfigureAwait(false);
                    Trace.WriteLine("Browser pool disposed", ProcessName.TEST_CLEANUP);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Browser pool disposal error: {ex.Message}", ProcessName.TEST_CLEANUP);
                }
            }

            if (!isCancelled)
            {
                Cts.CancelAfter(5000);
            }

            if (!gracefulCts.IsCancellationRequested)
            {
                await gracefulCts.CancelAsync();
            }

            // Shorter delay if already cancelled
            await Task.Delay(isCancelled ? 1000 : 5000);

            if (_useContainer)
            {
                if (_cover)
                {
                    List<Task> coverageShutdownTasks =
                    [
                        ShutdownContainerCoverage(ProcessName.WEB_APP_SERVER, ComposeFilePath)
                    ];

                    if (!ProOnly && !WebOnly)
                    {
                        coverageShutdownTasks.Add(ShutdownContainerCoverage(ProcessName.CORE_UNIT,
                            CoreUnitTestComposeFilePath));
                    }

                    if (!CoreOnly && !WebOnly)
                    {
                        coverageShutdownTasks.Add(ShutdownContainerCoverage(ProcessName.PRO_UNIT,
                            ProUnitTestComposeFilePath));

                        coverageShutdownTasks.Add(ShutdownContainerCoverage(ProcessName.PRO_VALIDATION,
                            ProValidationTestComposeFilePath));
                    }

                    await Task.WhenAll(coverageShutdownTasks);
                }

                List<Task> appShutdownTasks =
                [
                    StopContainer(ComposeFilePath)
                ];

                if (!ProOnly && !WebOnly)
                {
                    appShutdownTasks.Add(StopContainer(CoreUnitTestComposeFilePath));
                }

                if (!CoreOnly && !WebOnly)
                {
                    appShutdownTasks.Add(StopContainer(ProUnitTestComposeFilePath));
                    appShutdownTasks.Add(StopContainer(ProValidationTestComposeFilePath));
                }

                await Task.WhenAll(appShutdownTasks);
            }
            else if (!CoreOnly && !WebOnly)
            {
                // Pro Unit always runs in container
                await ShutdownContainerCoverage(ProcessName.PRO_UNIT, ProUnitTestComposeFilePath);
            }

            await KillProcessesByIds();
            await KillProcessesByTestPorts();

            if (_cover)
            {
                await GenerateCoverageReport();
            }

            cleanupStopwatch.Stop();

            Trace.WriteLine(
                $"Assembly Cleanup Complete in {cleanupStopwatch.Elapsed.Minutes}m {cleanupStopwatch.Elapsed.Seconds}s",
                ProcessName.TEST_CLEANUP);

            fullSuiteStopwatch.Stop();

            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            Trace.WriteLine("TEST RUN COMPLETE", ProcessName.FINAL_SUMMARY);

            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            Trace.WriteLine($"TIME: {fullSuiteStopwatch.Elapsed.Minutes}m {fullSuiteStopwatch.Elapsed.Seconds}s",
                ProcessName.FINAL_SUMMARY);

            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            if (!ProOnly && !WebOnly)
            {
                AddTestProcessSummary(ProcessName.CORE_UNIT);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            if (!CoreOnly && !WebOnly)
            {
                AddTestProcessSummary(ProcessName.PRO_UNIT);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
                AddTestProcessSummary(ProcessName.PRO_VALIDATION);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            if (!UnitOnly)
            {
                Trace.WriteLine(
                    $"{ProcessName.WEB_APP_SERVER} SUMMARY: {(WebFailedTestCount > 0 ? "FAILED!" : "PASSED")}",
                    ProcessName.FINAL_SUMMARY);

                int webTestTotalCount = FilteredTests[ProcessName.WEB_TEST].Count;
                Trace.WriteLine($"  total: {webTestTotalCount}", ProcessName.FINAL_SUMMARY);
                Trace.WriteLine($"  failed: {WebFailedTestCount}", ProcessName.FINAL_SUMMARY);
                int succeeded = webTestTotalCount - WebFailedTestCount - WebInconclusiveTestCount;
                Trace.WriteLine($"  succeeded: {succeeded}", ProcessName.FINAL_SUMMARY);
                Trace.WriteLine($"  skipped: {WebInconclusiveTestCount}", ProcessName.FINAL_SUMMARY);
                TimeSpan webTestDuration = webTestEndTime - _webTestStartTime;

                Trace.WriteLine(
                    $"  duration: {webTestDuration.Minutes}m {webTestDuration.Seconds}s {webTestDuration.Milliseconds
                    }ms",
                    ProcessName.FINAL_SUMMARY);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            Trace.WriteLine($"PASSED TESTS: {PassedTests.Count} / {FilteredTests.Values.Sum(v => v.Count)}", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            if (InconclusiveTests.Count > 0)
            {
                Trace.WriteLine($"INCONCLUSIVE TESTS: {InconclusiveTests.Count}", ProcessName.FINAL_SUMMARY);

                foreach (string inconclusive in InconclusiveTests.Keys)
                {
                    Trace.WriteLine($"  {inconclusive}", ProcessName.FINAL_SUMMARY);
                }

                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            if (SkippedTests.Count > 0)
            {
                Trace.WriteLine($"SKIPPED TESTS: {SkippedTests.Count}", ProcessName.FINAL_SUMMARY);

                foreach (string skipped in SkippedTests.Keys)
                {
                    Trace.WriteLine($"  {skipped}", ProcessName.FINAL_SUMMARY);
                }

                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            int failedCount = FailedTests.Values.Sum(d => d.Count);

            Trace.WriteLine($"FAILED TESTS: {failedCount}", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            if (FailedTests.Count > 0)
            {
                Trace.WriteLine("FAILED TEST DETAILS:", ProcessName.FINAL_SUMMARY);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

                foreach (KeyValuePair<string, Dictionary<string, string>> kvp in FailedTests)
                {
                    string testCategory = kvp.Key.ToUpperInvariant();

                    List<KeyValuePair<string, string>> sortedFailedTests = kvp.Value
                        .OrderBy(d => d.Key)
                        .ToList();

                    for (int i = 0; i < sortedFailedTests.Count; i++)
                    {
                        KeyValuePair<string, string> failedTest = sortedFailedTests[i];

                        if (i > 0)
                        {
                            Trace.WriteLine("------------", ProcessName.FINAL_SUMMARY);
                        }

                        // trim off extra timestamp from web browser and split lines
                        string[] errorLines = failedTest.Value.Substring(26).Split(Environment.NewLine);

                        Trace.WriteLine($"  {testCategory} - {failedTest.Key}",
                            ProcessName.FINAL_SUMMARY);

                        foreach (string errorLine in errorLines)
                        {
                            Trace.WriteLine($"    {errorLine}", ProcessName.FINAL_SUMMARY);
                        }
                    }
                }
            }

            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            await BuildLogFile();
        }
        finally
        {
            _cleanupComplete = true;
        }
    }

    private static async Task LaunchPipelineTask(string taskName, Func<ResilienceContext, ValueTask> task)
    {
        ResilienceContext context = ResilienceContextPool.Shared.Get(
            new ResilienceContextCreationArguments(taskName, null, Cts.Token));
        await appRetryPipeline.ExecuteAsync(task, context);

        ResilienceContextPool.Shared.Return(context);
    }

    private static void SetupConfiguration()
    {
        // Default to Server Mode for compatibility with Code Coverage Tools
        string renderMode = Configuration.GetValue("RENDER_MODE", nameof(BlazorMode.Server));

        if (Enum.TryParse(renderMode, true, out BlazorMode blazorMode))
        {
            RenderMode = blazorMode;
        }

        ParseFilters();

        _useContainer = Configuration.GetValue("USE_CONTAINER", false);
        _noCache = Configuration.GetValue("NO_CACHE", false);

        // Configure browser pool size - larger pools improve parallelism
        IsCI = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
        int defaultPoolSize = IsCI ? 4 : 8; // Doubled from 2/4 to 4/8 for better parallelization
        BrowserPoolSize = Configuration.GetValue("BROWSER_POOL_SIZE", defaultPoolSize);
        Trace.WriteLine($"Browser pool size set to: {BrowserPoolSize} (CI: {IsCI})", ProcessName.TEST_SETUP);

        if (_cover)
        {
            _coverageFormat = Configuration.GetValue("COVERAGE_FORMAT", "xml");
            _coverageFileVersion = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            _reportGenLicenseKey = Configuration["REPORT_GEN_LICENSE_KEY"];
        }

        string? config = Configuration["CONFIGURATION"];

        if (!string.IsNullOrEmpty(config))
        {
            _runConfig = config;
        }

        if (_runConfig is null)
        {
#if DEBUG
            _runConfig = "Debug";
#else
            _runConfig = "Release";
#endif
        }

        _targetFramework ??= Configuration.GetValue("TARGET_FRAMEWORK", "net10.0");
        _showDialog = Configuration.GetValue("SHOW_DIALOG", true);
    }

    private static void ParseFilters()
    {
        string[] envArgs = Environment.GetCommandLineArgs();

        _filters = [];

        for (int i = 0; i < envArgs.Length; i++)
        {
            string arg = envArgs[i];

            if ((arg == "--filter") && (i + 1 < envArgs.Length))
            {
                string[] filters = envArgs[i + 1].Replace("\\", "").Split('|');
                _filters.AddRange(filters);

                foreach (string filter in filters)
                {
                    ParseFilter(filter); 
                }

                // Microsoft.Test.Platform only accepts a single filter argument
                break;
            }
        }

        if (_filters.Count == 0)
        {
            FilteredTests[ProcessName.WEB_TEST] = webTests.ToList();
            FilteredTests[ProcessName.CORE_UNIT] = coreUnitTests.ToList();
            FilteredTests[ProcessName.PRO_UNIT] = proUnitTests.ToList();
            FilteredTests[ProcessName.PRO_VALIDATION] = proValidationTests.ToList();
        }

        if (FilteredTests.Values.All(v => v.Count == 0))
        {
            throw new InvalidOperationException("No tests found to run. Please check your filters.");
        }

        if (!ProAvailable || Configuration.GetValue("CORE_ONLY", false))
        {
            FilteredTests[ProcessName.PRO_UNIT].Clear();
            FilteredTests[ProcessName.PRO_VALIDATION].Clear();
            FilteredTests[ProcessName.WEB_TEST].RemoveAll(t => t.ClassName.StartsWith("PRO_"));
        }
        else if (Configuration.GetValue("PRO_ONLY", false))
        {
            FilteredTests[ProcessName.CORE_UNIT].Clear();
            FilteredTests[ProcessName.WEB_TEST].RemoveAll(t => t.ClassName.StartsWith("CORE_"));
        }

        // Remove AutomationExclude tests from FilteredTests so the denominator matches
        // what MSTest actually runs (the CLI filter TestCategory!~AutomationExclude excludes them)
        foreach (List<TestRecord> tests in FilteredTests.Values)
        {
            tests.RemoveAll(t => t.Categories.Any(c => c.Contains("AutomationExclude")));
        }

        // Remove custom routing keywords that control TestConfig logic but aren't
        // valid MSTest filter expressions (they'd be interpreted as FullyQualifiedName~keyword)
        _filters.RemoveAll(f => f is "unit" or "web" or "core" or "core_" or "pro" or "pro_");

        // only run coverage on a full test run, otherwise it overwrites the test coverage from previous runs
        _cover = Configuration.GetValue("COVER", false)
            && _filters.Count == 0
            && !CoreOnly && !ProOnly
            && !WebOnly && !UnitOnly;
    }

    private static void ParseFilter(string filter)
    {
        // check for custom filters first
        string lowered = filter.ToLowerInvariant();

        switch (lowered)
        {
            case "web":
                FilteredTests[ProcessName.WEB_TEST] = webTests.ToList();
                return;
            case "unit":
                FilteredTests[ProcessName.CORE_UNIT] = coreUnitTests.ToList();
                FilteredTests[ProcessName.PRO_UNIT] = proUnitTests.ToList();
                FilteredTests[ProcessName.PRO_VALIDATION] = proValidationTests.ToList();

                return;
            case "core":
            case "core_":
                FilteredTests[ProcessName.CORE_UNIT] = coreUnitTests.ToList();
                FilteredTests[ProcessName.WEB_TEST] = coreWebTests.ToList();

                return;
            case "pro":
            case "pro_":
                FilteredTests[ProcessName.PRO_UNIT] = proUnitTests.ToList();
                FilteredTests[ProcessName.PRO_VALIDATION] = proValidationTests.ToList();
                FilteredTests[ProcessName.WEB_TEST] = proWebTests.ToList();
                
                return;
            default:
            {
                Dictionary<string, FilterOperator> operators = new()
                {
                    ["~"] = FilterOperator.Contains,
                    ["!~"] = FilterOperator.NotContains,
                    ["="] = FilterOperator.Equals,
                    ["!="] = FilterOperator.NotEquals
                };
                FilterType filterType = FilterType.FullyQualifiedName;
                string filterValue = filter;
                FilterOperator filterOp = FilterOperator.Contains;

                if (operators.Keys
                        .OrderByDescending(k => k.Length) // order to check the negative operators first
                        .FirstOrDefault(filter.Contains) is { } op)
                {
                    filterOp = operators[op];
                    string[] split = filter.Split(op);
                    filterType = Enum.Parse<FilterType>(split[0]);
                    filterValue = split[1];
                }
                
                FilteredTests[ProcessName.WEB_TEST].AddRange(
                    ParseTestGroup(coreWebTests, filterType, filterOp, filterValue));

                FilteredTests[ProcessName.WEB_TEST]
                    .AddRange(ParseTestGroup(proWebTests, filterType, filterOp, filterValue));
                
                FilteredTests[ProcessName.CORE_UNIT].AddRange(
                    ParseTestGroup(coreUnitTests, filterType, filterOp, filterValue));
                
                FilteredTests[ProcessName.PRO_UNIT].AddRange(
                    ParseTestGroup(proUnitTests, filterType, filterOp, filterValue));
                
                FilteredTests[ProcessName.PRO_VALIDATION].AddRange(
                    ParseTestGroup(proValidationTests, filterType, filterOp, filterValue));

                break;
            }
        }
    }
    private static List<TestRecord> ParseTestGroup(List<TestRecord> tests, FilterType filterType, 
        FilterOperator filterOp, string filterValue)
    {
        List<TestRecord> matchingTests = [];

        switch (filterType)
        {
            case FilterType.ClassName:
                foreach (TestRecord test in tests)
                {
                    if (IsMatch(test.ClassName, filterValue, filterOp))
                    {
                        matchingTests.Add(test);
                    }
                }

                break;
            case FilterType.Name:
                foreach (TestRecord test in tests)
                {
                    if (IsMatch(test.MethodName, filterValue, filterOp))
                    {
                        matchingTests.Add(test);
                    }
                }

                break;
            case FilterType.FullyQualifiedName:
                foreach (TestRecord test in tests)
                {
                    if (IsMatch(test.FullyQualifiedName, filterValue, filterOp))
                    {
                        matchingTests.Add(test);
                    }
                }

                break;
            case FilterType.TestCategory:
                foreach (TestRecord test in tests)
                {
                    foreach (string category in test.Categories)
                    {
                        if (IsMatch(category, filterValue, filterOp))
                        {
                            matchingTests.Add(test);
                        }
                    }
                }

                break;
        }

        return matchingTests;
    }

    private static bool IsMatch(string value, string filterValue, FilterOperator filterOp)
    {
        return filterOp switch
        {
            FilterOperator.Contains => value.Contains(filterValue),
            FilterOperator.NotContains => !value.Contains(filterValue),
            FilterOperator.Equals => value.Equals(filterValue, StringComparison.OrdinalIgnoreCase),
            FilterOperator.NotEquals => !value.Equals(filterValue, StringComparison.OrdinalIgnoreCase),
            _ => throw new ArgumentOutOfRangeException(nameof(filterOp), filterOp, null)
        };
    }

    private static async ValueTask LaunchWebTests(ResilienceContext context)
    {
        webLaunchStopwatch.Start();

        try
        {
            if (_useContainer)
            {
                await StartWebAppContainer(context);
            }
            else
            {
                await StartWebApp(context.CancellationToken);
            }
        }
        catch (Exception ex)
        {
            context.Properties.Set(exceptionKey, $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");

            throw;
        }
        finally
        {
            webLaunchStopwatch.Stop();

            Trace.WriteLine($"Web Tests Server Ready in {webLaunchStopwatch.Elapsed.Minutes}m {
                webLaunchStopwatch.Elapsed.Seconds
            }s", ProcessName.WEB_APP_SERVER);
        }
    }

    private static async ValueTask LaunchUnitTests(ResilienceContext context)
    {
        Stopwatch unitTestStopwatch = Stopwatch.StartNew();

        try
        {
            // Pro Unit tests need to always run in a container because they wipe out state that other tests depend on.
            if (_useContainer || (context.OperationKey == ProcessName.PRO_UNIT))
            {
                await StartUnitTestContainer(context);
            }
            else
            {
                await RunUnitTests(context);
            }
        }
        catch (Exception ex)
        {
            context.Properties.Set(exceptionKey, $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");

            throw;
        }
        finally
        {
            unitTestStopwatch.Stop();

            Trace.WriteLine(
                $"Tests Complete in {unitTestStopwatch.Elapsed.Minutes}m {unitTestStopwatch.Elapsed.Seconds}s",
                context.OperationKey);
        }
    }

    private static async Task InstallCodeCoverageTools()
    {
        if (!_cover)
        {
            return;
        }

        await Cli.Wrap("dotnet")
            .WithArguments([
                "tool",
                "install",
                "--global",
                "dotnet-coverage"
            ])
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, ProcessName.CODE_COVERAGE_TOOL_INSTALLATION)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, ProcessName.CODE_COVERAGE_TOOL_INSTALLATION_ERROR)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();

        await Cli.Wrap("dotnet")
            .WithArguments([
                "tool",
                "install",
                "--global",
                "dotnet-reportgenerator-globaltool"
            ])
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, ProcessName.CODE_COVERAGE_TOOL_INSTALLATION)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, ProcessName.CODE_COVERAGE_TOOL_INSTALLATION_ERROR)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();

        // ensure output directory exists
        Directory.CreateDirectory(Path.Combine(ProjectFolder, "coverage"));
    }

    private static async Task EnsurePlaywrightBrowsersAreInstalled()
    {
        try
        {
            // Use Playwright's built-in installation via Program.Main
            // This is more reliable cross-platform than calling pwsh
            int exitCode = Program.Main(["install"]);

            if (exitCode != 0)
            {
                Trace.WriteLine($"Playwright browser installation returned exit code: {exitCode}",
                    ProcessName.TEST_SETUP);
            }

            await Task.CompletedTask; // Keep method async for consistency
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Playwright browser installation failed: {ex.Message}", ProcessName.TEST_SETUP);
        }
    }

    private static async ValueTask RunUnitTests(ResilienceContext context)
    {
        string processName = context.OperationKey!;

        string testPath = processName switch
        {
            ProcessName.CORE_UNIT => CoreUnitTestPath,
            ProcessName.PRO_UNIT => ProUnitTestPath,
            ProcessName.PRO_VALIDATION => ProValidationTestPath,
            _ => throw new ArgumentOutOfRangeException(nameof(processName), processName, null)
        };

        string coverageFilePath = processName switch
        {
            ProcessName.CORE_UNIT => CoreUnitCoverageFilePath,
            ProcessName.PRO_UNIT => ProUnitCoverageFilePath,
            ProcessName.PRO_VALIDATION => ProValidationCoverageFilePath,
            _ => throw new ArgumentOutOfRangeException(nameof(processName), processName, null)
        };

        string cmdLineApp = "dotnet";

        List<string> args =
        [
            "test",
            "--project",
            testPath,
            "--no-build",
            "-c",
            _runConfig!,
            "--output",
            "Detailed",
            "/p:ShowScriptDialogs=false"
        ];

        List<string> filterArgs = [.._filters ?? [], "TestCategory!~AutomationExclude"];
        string filter = string.Join("&", filterArgs);
        args.Add("--filter");
        args.Add(filter);

        if (_cover)
        {
            Directory.CreateDirectory(UnitCoverageFolderPath);
            cmdLineApp = "dotnet-coverage";
            string dotnetCommand = $"dotnet {string.Join(" ", args)}";

            args =
            [
                "collect",
                "-o", coverageFilePath,
                "-f", _coverageFormat,
                "--include-files", "**/dymaptic.GeoBlazor.Core.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Pro.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Pro.Validator.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Core.SourceGenerator.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Pro.SourceGenerator.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Core.SourceGenerator.Shared.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Core.Analyzers.dll",
                dotnetCommand
            ];
        }

        Dictionary<string, string> failedTests = [];
        List<string> inconclusiveTests = [];
        List<string> passedTests = [];

        bool ioExceptionThrown = false;
        string? ioExceptionMessage = null;

        CommandResult result = await Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                TrackUnitTestOutput(output, processName, ref failedTests, ref inconclusiveTests,
                    ref passedTests, ref ioExceptionMessage, ref ioExceptionThrown)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output => Trace.WriteLine(output, $"{processName}_ERROR")))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync(context.CancellationToken, gracefulCts.Token);

        // 0 = Passed
        // 2 = Tests failed, we will catch this in our final summary
        // 8 = No tests ran
        int[] allowedExitCodes = [0, 2, 8];

        if (!allowedExitCodes.Contains(result.ExitCode))
        {
            if (ioExceptionThrown)
            {
                throw new IOException(ioExceptionMessage);
            }

            throw new ProcessExitedException($"{processName} process exited with code {result.ExitCode}");
        }

        if (!FailedTests.ContainsKey(processName))
        {
            FailedTests[processName] = new Dictionary<string, string>();
        }

        foreach (KeyValuePair<string, string> failedTest in failedTests)
        {
            FailedTests[processName].TryAdd(failedTest.Key, failedTest.Value);
        }

        foreach (string test in inconclusiveTests)
        {
            InconclusiveTests.TryAdd(test, 0);
        }

        Trace.WriteLine($"Adding {passedTests.Count} passed tests to total test count", processName);

        foreach (string test in passedTests)
        {
            PassedTests.TryAdd($"{processName}:{test}", 0);
        }
    }

    private static async ValueTask StartUnitTestContainer(ResilienceContext context)
    {
        string cmdLineApp = "docker";

        string processName = context.OperationKey!;

        string filePath = processName switch
        {
            ProcessName.CORE_UNIT => CoreUnitTestComposeFilePath,
            ProcessName.PRO_UNIT => ProUnitTestComposeFilePath,
            ProcessName.PRO_VALIDATION => ProValidationTestComposeFilePath,
            _ => throw new ArgumentOutOfRangeException(nameof(processName), processName, null)
        };

        string[] args =
        [
            "compose", "-f", filePath, "up", "-d", "--build"
        ];

        if (_noCache || (context.Properties.TryGetValue(retryAttemptKey, out int retryAttempt) && (retryAttempt > 0)))
        {
            // rebuild without cache when explicitly requested or on retry
            await BuildContainer(filePath, processName, context);
        }

        Trace.WriteLine($"Starting container with: docker {string.Join(" ", args)}", $"CONTAINER_BUILD: {processName}");
        Trace.WriteLine($"Working directory: {ProjectFolder}", $"CONTAINER_BUILD: {processName}");

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";
            string dockerCommand = $"docker {string.Join(" ", args)}";

            args =
            [
                "collect",
                "--session-id", processName,
                "-o", CoverageFilePath,
                "-f", _coverageFormat,
                dockerCommand
            ];
        }

        Dictionary<string, string> failedTests = [];
        List<string> inconclusiveTests = [];
        List<string> passedTests = [];

        string? ioExceptionMessage = null;
        bool ioExceptionThrown = false;
        string? containerExceptionMessage = null;
        bool containerExceptionThrown = false;
        CancellationTokenSource waitTokenSource = new();

        CancellationTokenSource linkedTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken, waitTokenSource.Token);

        List<string> filterArgs = [.._filters ?? [], "TestCategory!~AutomationExclude"];
        string filter = string.Join("&", filterArgs);

        _ = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["FILTER"] = filter,
                ["COVER"] = _cover.ToString().ToLower(),
                ["SESSION_ID"] = processName,
                ["COVERAGE_FORMAT"] = _coverageFormat,
                ["COVERAGE_FILE_VERSION"] = _coverageFileVersion,
                ["GEOBLAZOR_CORE_LICENSE_KEY"] = Configuration["GEOBLAZOR_CORE_LICENSE_KEY"],
                ["GEOBLAZOR_PRO_LICENSE_KEY"] = Configuration["GEOBLAZOR_PRO_LICENSE_KEY"]
            })
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                TrackUnitTestOutput(output, processName, ref failedTests, ref inconclusiveTests,
                    ref passedTests, ref ioExceptionMessage, ref ioExceptionThrown,
                    waitTokenSource)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
            {
                if (line.Contains("ERROR:"))
                {
                    containerExceptionMessage = line;
                    containerExceptionThrown = true;
                    waitTokenSource.Cancel();
                }
            }))
            .WithWorkingDirectory(ProjectFolder)
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync(linkedTokenSource.Token, gracefulCts.Token);

        string containerName = processName switch
        {
            ProcessName.CORE_UNIT => "gb-core-unit-core-unit-1",
            ProcessName.PRO_UNIT => "gb-pro-unit-pro-unit-1",
            ProcessName.PRO_VALIDATION => "gb-pro-validation-pro-validation-1",
            _ => throw new ArgumentException("Invalid process name", nameof(processName))
        };

        try
        {
            if (ioExceptionThrown)
            {
                throw new IOException(ioExceptionMessage);
            }

            if (containerExceptionThrown)
            {
                throw new ContainerException(containerExceptionMessage!);
            }

            await WaitForDockerContainer(processName, containerName, waitTokenSource.Token);

            if (ioExceptionThrown)
            {
                throw new IOException(ioExceptionMessage);
            }

            await Cli.Wrap("docker")
                .WithArguments(["container", "logs", "--follow", "--details", containerName])
                .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                    TrackUnitTestOutput(output, processName, ref failedTests, ref inconclusiveTests,
                        ref passedTests, ref ioExceptionMessage, ref ioExceptionThrown,
                        waitTokenSource)))
                .WithStandardErrorPipe(PipeTarget.ToDelegate(output => Trace.WriteLine(output, processName)))
                .ExecuteAsync(context.CancellationToken, gracefulCts.Token);
        }
        catch (Exception)
        {
            if (ioExceptionThrown)
            {
                throw new IOException(ioExceptionMessage);
            }

            if (containerExceptionThrown)
            {
                throw new ContainerException(containerExceptionMessage!);
            }

            throw;
        }

        if (!FailedTests.ContainsKey(processName))
        {
            FailedTests[processName] = new Dictionary<string, string>();
        }

        foreach (KeyValuePair<string, string> failedTest in failedTests)
        {
            FailedTests[processName].TryAdd(failedTest.Key, failedTest.Value);
        }

        foreach (string test in inconclusiveTests)
        {
            InconclusiveTests.TryAdd(test, 0);
        }

        Trace.WriteLine($"Adding {passedTests.Count} passed tests to total test count", processName);

        foreach (string test in passedTests)
        {
            PassedTests.TryAdd(test, 0);
        }
    }

    private static void TrackUnitTestOutput(string output, string processName,
        ref Dictionary<string, string> failedTests, ref List<string> inconclusiveTests,
        ref List<string> passedTests, ref string? ioExceptionMessage, 
        ref bool ioExceptionThrown, CancellationTokenSource? waitTokenSource = null)
    {
        string trimmedLine = output.Trim();

        if (trimmedLine.Contains("The process cannot access the file")
            || trimmedLine.Contains("The \"UpdateExternallyDefinedStaticWebAssets\" task failed unexpectedly.")
            || trimmedLine.Contains("No file exists for the asset at either location"))
        {
            ioExceptionMessage = trimmedLine;
            ioExceptionThrown = true;
            waitTokenSource?.Cancel();
        }

        if (trimmedLine.StartsWith("failed ", StringComparison.OrdinalIgnoreCase))
        {
            string testName = trimmedLine.Split(" ")[1];
            failedTests.TryAdd(testName, output);
        }
        else if (trimmedLine.StartsWith("inconclusive ", StringComparison.OrdinalIgnoreCase))
        {
            string testName = trimmedLine.Split(" ")[1];
            inconclusiveTests.Add(testName);
        }
        else if (trimmedLine.StartsWith("passed ", StringComparison.OrdinalIgnoreCase))
        {
            string testName = trimmedLine.Split(" ")[1];
            passedTests.Add(testName);
        }

        Trace.WriteLine(output, processName);
    }

    private static async Task StartWebApp(CancellationToken token)
    {
        string? licenseKey = CoreOnly
            ? Configuration["GEOBLAZOR_CORE_LICENSE_KEY"]
            : Configuration["GEOBLAZOR_PRO_LICENSE_KEY"];

        if (licenseKey is not null)
        {
            EnsureGeoBlazorLicenseKeyInUserSecrets(TestAppPath, licenseKey);
        }

        string cmdLineApp = "dotnet";

        string[] args =
        [
            "run", "--no-build", "--project", TestAppPath,
            "--urls", $"{TestAppUrl};{TestAppHttpUrl}",
            "--", "-c", _runConfig!,
            "/p:GenerateXmlComments=false",
            "/p:GeneratePackage=false",
            "/p:GenerateDocs=false",
            "/p:DebugSymbols=true",
            "/p:DebugType=portable",
            "/p:UsePackageReferences=false",
            "/p:ShowScriptDialogs=false",
            "-v:d"
        ];

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";

            // Join the dotnet run command into a single string for dotnet-coverage
            string dotnetCommand = $"dotnet {string.Join(" ", args)}";

            // Include GeoBlazor assemblies for coverage
            args =
            [
                "collect",
                "-o", CoverageFilePath,
                "-f", _coverageFormat,
                "--include-files", "**/dymaptic.GeoBlazor.Core.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Pro.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Pro.Validator.dll",
                dotnetCommand
            ];
        }

        Trace.WriteLine($"Starting test app: {cmdLineApp} {string.Join(" ", args)}", ProcessName.WEB_APP_SERVER);

        bool ioExceptionThrown = false;
        string? ioExceptionMessage = null;

        CommandTask<CommandResult> commandTask = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
            {
                if (line.Contains("The process cannot access the file")
                    || line.Contains("The \"UpdateExternallyDefinedStaticWebAssets\" task failed unexpectedly.")
                    || line.Contains("No file exists for the asset at either location"))
                {
                    ioExceptionMessage = line;
                    ioExceptionThrown = true;
                }

                Trace.WriteLine(line, ProcessName.WEB_APP_SERVER);
            }))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
                Trace.WriteLine(line, ProcessName.WEB_APP_ERROR)))
            .WithWorkingDirectory(ProjectFolder)
            .ExecuteAsync(token, gracefulCts.Token);

        processIds.Add(commandTask.ProcessId);

        try
        {
            await WaitForHttpResponse();
        }
        catch (Exception)
        {
            if (ioExceptionThrown)
            {
                throw new IOException(ioExceptionMessage);
            }

            throw;
        }
    }

    private static async Task StartWebAppContainer(ResilienceContext context)
    {
        string cmdLineApp = "docker";

        string[] args =
        [
            "compose", "-f", ComposeFilePath, "up", "-d", "--build"
        ];

        if (_noCache || (context.Properties.TryGetValue(retryAttemptKey, out int retryAttempt) && (retryAttempt > 0)))
        {
            // rebuild without cache when explicitly requested or on retry
            await BuildContainer(ComposeFilePath, ProcessName.WEB_APP_SERVER, context);
        }

        Trace.WriteLine($"Starting container with: docker {string.Join(" ", args)}", ProcessName.WEB_APP_SERVER);
        Trace.WriteLine($"Working directory: {ProjectFolder}", ProcessName.WEB_APP_SERVER);

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";
            string dockerCommand = $"docker {string.Join(" ", args)}";

            args =
            [
                "collect",
                "--session-id", ProcessName.WEB_APP_SERVER,
                "-o", CoverageFilePath,
                "-f", _coverageFormat,
                dockerCommand
            ];
        }

        CancellationTokenSource waitTokenSource = new();

        CancellationTokenSource linkedTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken, waitTokenSource.Token);

        _webAppContainerExceptionThrown = false;
        _webAppContainerExceptionMessage = null;

        CommandTask<CommandResult> commandTask = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["HTTP_PORT"] = HttpPort.ToString(),
                ["HTTPS_PORT"] = HttpsPort.ToString(),
                ["COVER"] = _cover.ToString().ToLower(),
                ["SESSION_ID"] = ProcessName.WEB_APP_SERVER,
                ["COVERAGE_FORMAT"] = _coverageFormat,
                ["COVERAGE_FILE_VERSION"] = _coverageFileVersion,
                ["GEOBLAZOR_CORE_LICENSE_KEY"] = Configuration["GEOBLAZOR_CORE_LICENSE_KEY"],
                ["GEOBLAZOR_PRO_LICENSE_KEY"] = Configuration["GEOBLAZOR_PRO_LICENSE_KEY"]
            })
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, ProcessName.WEB_APP_SERVER)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
            {
                if (line.Contains("ERROR:"))
                {
                    _webAppContainerExceptionMessage = line;
                    _webAppContainerExceptionThrown = true;
                    waitTokenSource.Cancel();
                }
            }))
            .WithWorkingDirectory(ProjectFolder)
            .ExecuteAsync(linkedTokenSource.Token, gracefulCts.Token);

        processIds.Add(commandTask.ProcessId);
        _webTestProcessId = commandTask.ProcessId;

        if (_webAppContainerExceptionThrown)
        {
            throw new ContainerException(_webAppContainerExceptionMessage!);
        }

        await WaitForHttpResponse();
    }

    private static async Task BuildContainer(string filePath, string processName, ResilienceContext context)
    {
        string cmdLineApp = "docker";

        string[] args =
        [
            "compose", "-f", filePath, "build", "--no-cache"
        ];

        Trace.WriteLine($"Re-building container with: docker {string.Join(" ", args)}",
            $"CONTAINER_BUILD: {processName}");
        Trace.WriteLine($"Working directory: {ProjectFolder}", $"CONTAINER_BUILD: {processName}");

        CancellationTokenSource waitTokenSource = new();

        CancellationTokenSource linkedTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken, waitTokenSource.Token);

        _webAppContainerExceptionThrown = false;
        _webAppContainerExceptionMessage = null;

        await Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["HTTP_PORT"] = HttpPort.ToString(),
                ["HTTPS_PORT"] = HttpsPort.ToString(),
                ["COVER"] = _cover.ToString().ToLower(),
                ["SESSION_ID"] = processName,
                ["COVERAGE_FORMAT"] = _coverageFormat,
                ["COVERAGE_FILE_VERSION"] = _coverageFileVersion,
                ["GEOBLAZOR_CORE_LICENSE_KEY"] = Configuration["GEOBLAZOR_CORE_LICENSE_KEY"],
                ["GEOBLAZOR_PRO_LICENSE_KEY"] = Configuration["GEOBLAZOR_PRO_LICENSE_KEY"]
            })
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                Trace.WriteLine(line, $"CONTAINER_BUILD: {processName}")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
            {
                if (line.Contains("ERROR:"))
                {
                    _webAppContainerExceptionMessage = line;
                    _webAppContainerExceptionThrown = true;
                    waitTokenSource.Cancel();
                }
            }))
            .WithWorkingDirectory(ProjectFolder)
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync(linkedTokenSource.Token, gracefulCts.Token);

        if (_webAppContainerExceptionThrown)
        {
            throw new ContainerException(_webAppContainerExceptionMessage!);
        }
    }

    private static async Task ShutdownContainerCoverage(string processName, string composeFilePath)
    {
        // Get the container name from the compose file
        string containerName = processName switch
        {
            ProcessName.WEB_APP_SERVER when composeFilePath.EndsWith("core.yml") => "geoblazor-core-tests-test-app-1",
            ProcessName.WEB_APP_SERVER when composeFilePath.EndsWith("pro.yml") => "geoblazor-pro-tests-test-app-1",
            ProcessName.CORE_UNIT => "gb-core-unit-core-unit-1",
            ProcessName.PRO_UNIT => "gb-pro-unit-pro-unit-1",
            ProcessName.PRO_VALIDATION => "gb-pro-validation-pro-validation-1",
            _ => throw new ArgumentException("Invalid process name", nameof(processName))
        };

        try
        {
            Trace.WriteLine($"Shutting down coverage collection in container: {containerName}",
                ProcessName.CODE_COVERAGE);

            // Call dotnet-coverage shutdown inside the container to gracefully write coverage data
            await Cli.Wrap("docker")
                .WithArguments($"exec {containerName} /tools/dotnet-coverage shutdown geoblazor-coverage")
                .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                    Trace.WriteLine(line, ProcessName.CODE_COVERAGE)))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();

            // Give time for coverage file to be written
            await Task.Delay(3000);
            Trace.WriteLine("Coverage shutdown command completed", ProcessName.CODE_COVERAGE);
        }
        catch
        {
            // ignore, these just clutter the output
        }
    }

    private static async Task StopContainer(string composeFilePath)
    {
        try
        {
            Trace.WriteLine($"Stopping container with: docker compose -f {composeFilePath} down",
                ProcessName.TEST_CLEANUP);

            await Cli.Wrap("docker")
                .WithArguments($"compose -f \"{composeFilePath}\" down")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, ProcessName.TEST_CLEANUP)))
                .ExecuteAsync(Cts.Token);
        }
        catch
        {
            // ignore, these just clutter the output
        }
    }

    private static async Task WaitForHttpResponse()
    {
        // Configure HttpClient to ignore SSL certificate errors (for self-signed certs in Docker)
        HttpClientHandler handler = new()
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        using HttpClient httpClient = new(handler);

        // worst-case scenario for docker build is ~ 6 minutes
        // set this to 60 seconds * 15 = 15 minutes
        double maxMinutes = 15.0;
        int maxAttempts = (int)(60 * maxMinutes);

        Exception? lastException = null;
        Process? testProcess = null;

        for (int i = 1; i <= maxAttempts; i++)
        {
            try
            {
                if (i % 10 == 0)
                {
                    double minutes = i / 60.0;

                    Trace.WriteLine(
                        $"Waiting for Test Site at {TestAppHttpUrl}.{minutes:N2} out of max {maxMinutes:N2} minutes...",
                        ProcessName.WEB_APP_SERVER);
                }

                HttpResponseMessage response =
                    await httpClient.GetAsync(TestAppHttpUrl, Cts.Token);

                if (response.IsSuccessStatusCode ||
                    response.StatusCode is >= (HttpStatusCode)300 and < (HttpStatusCode)400)
                {
                    Trace.WriteLine($"Test Site is ready! Status: {response.StatusCode}", ProcessName.WEB_APP_SERVER);

                    return;
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging SSL/connection issues
                lastException = ex;
            }

            if (_webAppContainerExceptionThrown)
            {
                throw new ContainerException(_webAppContainerExceptionMessage!);
            }

            if (testProcess is null && _webTestProcessId is not null)
            {
                try
                {
                    testProcess = Process.GetProcessById(_webTestProcessId.Value);
                }
                catch (ArgumentException)
                {
                    // process is not running yet/anymore, keep waiting
                }
            }

            if (testProcess is not null && testProcess.HasExited)
            {
                try
                {
                    int exitCode = testProcess.ExitCode;

                    if (exitCode != 0)
                    {
                        throw new ProcessExitedException($"Test process exited with code {exitCode}");
                    }
                }
                catch
                {
                    // ignore - the container building process can exit silently and all is fine
                }
            }

            await Task.Delay(1000, Cts.Token);
        }

        throw new ProcessExitedException("Test page was not reachable within the allotted time frame", lastException);
    }

    private static async Task WaitForDockerContainer(string processName, string containerName,
        CancellationToken cancellationToken)
    {
        // worst-case scenario for docker build is ~ 6 minutes
        // set this to 60 seconds * 15 = 15 minutes
        double maxMinutes = 15.0;
        int maxAttempts = (int)(60 * maxMinutes);

        Exception? lastException = null;

        string[] listArgs = ["container", "ls"];
        bool isRunning = false;

        for (int i = 1; i <= maxAttempts; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            try
            {
                if (i % 10 == 0)
                {
                    double minutes = i / 60.0;

                    Trace.WriteLine(
                        $"Waiting for Test Container {containerName}. {minutes:N2} out of max {maxMinutes
                            :N2} minutes...",
                        $"CONTAINER_BUILD: {processName}");
                }

                await Cli.Wrap("docker")
                    .WithArguments(listArgs)
                    .WithValidation(CommandResultValidation.None)
                    .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                    {
                        if (line.Contains(containerName))
                        {
                            Trace.WriteLine($"Container {containerName} is running", $"CONTAINER_BUILD: {processName}");
                            isRunning = true;
                        }
                    }))
                    .ExecuteAsync(Cts.Token);

                if (isRunning)
                {
                    Trace.WriteLine($"Test Container {containerName} is ready!", $"CONTAINER_BUILD: {processName}");

                    return;
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging SSL/connection issues
                lastException = ex;
            }

            await Task.Delay(1000, Cts.Token);
        }

        throw new ProcessExitedException(
            $"{processName} Docker Container was not reachable within the allotted time frame", lastException);
    }

    private static async Task KillProcessesByIds()
    {
        foreach (int processId in processIds)
        {
            Process? process = null;

            try
            {
                Trace.WriteLine($"Sending 'exit' to process {processId}...", ProcessName.TEST_CLEANUP);
                process = Process.GetProcessById(processId);

                if (_useContainer)
                {
                    await process.StandardInput.WriteLineAsync("exit");
                    await Task.Delay(5000);
                }
            }
            catch
            {
                // ignore, these just clutter the output
            }

            try
            {
                if (process is not null && !process.HasExited)
                {
                    Trace.WriteLine($"Killing process {processId}...", ProcessName.TEST_CLEANUP);
                    process.Kill();
                }
            }
            catch
            {
                // ignore, these just clutter the output
            }
        }
    }

    private static async Task KillProcessesByTestPorts()
    {
        try
        {
            Trace.WriteLine($"Killing any remaining processes holding HTTPS port {HttpsPort}",
                ProcessName.TEST_CLEANUP);

            if (OperatingSystem.IsWindows())
            {
                string[] arguments =
                [
                    "-NoProfile", "-ExecutionPolicy", "ByPass", "-Command",
                    "{",
                    "Get-NetTCPConnection", "-LocalPort", HttpsPort.ToString(), "-State", "Listen",
                    "|", "Select-Object", "-ExpandProperty", "OwningProcess",
                    "|", "ForEach-Object",
                    "{",
                    "Stop-Process", "-Id", "$_", "-Force",
                    "}",
                    "}"
                ];

                // Use PowerShell for more reliable Windows port killing
                await Cli.Wrap("pwsh")
                    .WithArguments(arguments)
                    .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                        Trace.WriteLine(line, ProcessName.TEST_CLEANUP)))
                    .WithValidation(CommandResultValidation.None)
                    .ExecuteAsync();
            }
            else
            {
                await Cli.Wrap("/bin/bash")
                    .WithArguments([
                        "-c",
                        $"lsof -i:{HttpsPort} | awk '{{if(NR>1)print $2}}' | xargs -t -r kill -9"
                    ])
                    .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                        Trace.WriteLine(line, ProcessName.TEST_CLEANUP)))
                    .WithValidation(CommandResultValidation.None)
                    .ExecuteAsync();
            }
        }
        catch
        {
            // ignore, these just clutter the test output
        }
    }

    private static async Task GenerateCoverageReport()
    {
        string reportDir = Path.Combine(ProjectFolder, "coverage-report");
        string historyDir = Path.Combine(ProjectFolder, "history");

        if (!File.Exists(CoverageFilePath))
        {
            Trace.WriteLine($"Coverage file not found: {CoverageFilePath}", ProcessName.CODE_COVERAGE_ERROR);

            return;
        }

        try
        {
            Trace.WriteLine("Generating coverage report...", ProcessName.CODE_COVERAGE_REPORT);

            List<string> assemblyFilters =
            [
                "+dymaptic.GeoBlazor.Core.dll",
                "+dymaptic.GeoBlazor.Core.SourceGenerator.dll",
                "+dymaptic.GeoBlazor.Core.SourceGenerator.Shared.dll",
                "+dymaptic.GeoBlazor.Core.Analyzers.dll",
                "+dymaptic.GeoBlazor.Pro.dll",
                "+dymaptic.GeoBlazor.Pro.Validator.dll",
                "+dymaptic.GeoBlazor.Pro.SourceGenerator.dll"
            ];

            assemblyFilters = CoreOnly
                ? assemblyFilters.Where(a => a.Contains("Core")).ToList()
                : ProOnly
                    ? assemblyFilters.Where(a => a.Contains("Pro")).ToList()
                    : assemblyFilters;

            List<string> sourceDirs = CoreOnly
                ? [CoreProjectPath]
                : ProOnly
                    ? [ProProjectPath]
                    : [CoreProjectPath, ProProjectPath];

            List<string> args =
            [
                $"-reports:{CoverageFilePath};{CoreUnitCoverageFilePath};{ProUnitCoverageFilePath}",
                $"-targetdir:{reportDir}",
                "-reporttypes:Html;TextSummary;Badges",
                $"-historydir:{historyDir}",

                // Include only GeoBlazor Core and Pro assemblies, exclude everything else
                $"-assemblyfilters:{string.Join(";", assemblyFilters)}",
                $"-sourcedirs:{string.Join(";", sourceDirs)}"
            ];

            if (!string.IsNullOrEmpty(_reportGenLicenseKey))
            {
                args.Add($"-license:{_reportGenLicenseKey}");
            }

            await Cli.Wrap("reportgenerator")
                .WithArguments(args)
                .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                    Trace.WriteLine(line, ProcessName.CODE_COVERAGE_REPORT)))
                .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
                    Trace.WriteLine(line, ProcessName.CODE_COVERAGE_REPORT_ERROR)))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();

            string textSummaryPath = Path.Combine(reportDir, "Summary.txt");
            string webReportPath = Path.Combine(reportDir, "index.html");

            if (File.Exists(textSummaryPath))
            {
                Trace.WriteLine(await File.ReadAllTextAsync(textSummaryPath),
                    ProcessName.CODE_COVERAGE_REPORT);
                Trace.WriteLine($"Full report at [Coverage Report]({webReportPath})", ProcessName.CODE_COVERAGE_REPORT);
            }

            // copy the badge image to the repo root
            string lineBadgePath = Path.Combine(reportDir, "badge_linecoverage.svg");
            string methodBadgePath = Path.Combine(reportDir, "badge_methodcoverage.svg");
            string fullMethodBadgePath = Path.Combine(reportDir, "badge_fullmethodcoverage.svg");

            if (!ProOnly)
            {
                File.Copy(lineBadgePath, Path.Combine(CoreRepoRoot, "badge_linecoverage.svg"), true);
                File.Copy(methodBadgePath, Path.Combine(CoreRepoRoot, "badge_methodcoverage.svg"), true);
                File.Copy(fullMethodBadgePath, Path.Combine(CoreRepoRoot, "badge_fullmethodcoverage.svg"), true);
                File.Copy(lineBadgePath, Path.Combine(CoreProjectPath, "badge_linecoverage.svg"), true);
                File.Copy(methodBadgePath, Path.Combine(CoreProjectPath, "badge_methodcoverage.svg"), true);
                File.Copy(fullMethodBadgePath, Path.Combine(CoreProjectPath, "badge_fullmethodcoverage.svg"), true);
            }

            if (!CoreOnly)
            {
                File.Copy(lineBadgePath, Path.Combine(ProRepoRoot, "badge_linecoverage.svg"), true);
                File.Copy(methodBadgePath, Path.Combine(ProRepoRoot, "badge_methodcoverage.svg"), true);
                File.Copy(fullMethodBadgePath, Path.Combine(ProRepoRoot, "badge_fullmethodcoverage.svg"), true);
                File.Copy(lineBadgePath, Path.Combine(ProProjectPath, "badge_linecoverage.svg"), true);
                File.Copy(methodBadgePath, Path.Combine(ProProjectPath, "badge_methodcoverage.svg"), true);
                File.Copy(fullMethodBadgePath, Path.Combine(ProProjectPath, "badge_fullmethodcoverage.svg"), true);
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Failed to generate coverage report: {ex.Message}", ProcessName.CODE_COVERAGE_ERROR);
        }
    }

    private static void AddTestProcessSummary(string processName)
    {
        if (!logBuilders.TryGetValue(processName, out Dictionary<DateTime, string>? coreUnitLog))
        {
            return;
        }

        bool summaryStarted = false;

        foreach (KeyValuePair<DateTime, string> log in coreUnitLog.OrderBy(kv => kv.Key))
        {
            if (log.Value.Contains("Test run summary"))
            {
                summaryStarted = true;
                bool passed = log.Value.Contains("Passed", StringComparison.OrdinalIgnoreCase);
                string line = passed ? $"{processName} SUMMARY: PASSED" : $"{processName} SUMMARY: FAILED";
                Trace.WriteLine(line, ProcessName.FINAL_SUMMARY);

                continue;
            }

            if (summaryStarted)
            {
                Trace.WriteLine(log.Value, ProcessName.FINAL_SUMMARY);
            }
        }
    }

    private static async Task BuildLogFile()
    {
        StringBuilder sb = new();

        foreach ((string processName, Dictionary<DateTime, string> logEntries)
            in logBuilders.OrderBy(kv => ProcessName.OrderedList.IndexOf(kv.Key)))
        {
            foreach (KeyValuePair<DateTime, string> entry in logEntries.OrderBy(kv => kv.Key))
            {
                sb.AppendLine($"[{entry.Key.ToString("u")}] {processName}: {entry.Value}");
            }
        }

        await File.WriteAllTextAsync(LogFilePath, sb.ToString());
    }

    private static void EnsureGeoBlazorLicenseKeyInUserSecrets(string projectFilePath, string licenseKey)
    {
        string userSecretsFilePath = GetUserSecretsFilePath(projectFilePath);
        SetLicenseKey(userSecretsFilePath, licenseKey);
    }

    private static string GetUserSecretsFilePath(string projectFilePath)
    {
        try
        {
            XmlDocument projectDoc = new();
            projectDoc.Load(projectFilePath);

            // Get UserSecrets
            XmlNode? node = projectDoc.SelectSingleNode("//PropertyGroup/UserSecretsId");
            string? userSecretsId = node?.InnerText;

            if (string.IsNullOrEmpty(userSecretsId))
            {
                Trace.WriteLine("User secrets ID not found in project file.");

                return string.Empty;
            }

            string secretsFilePath = PathHelper.GetSecretsPathFromSecretsId(userSecretsId);

            return secretsFilePath;
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Error reading project file: {ex.Message}");

            return string.Empty;
        }
    }

    private static void SetLicenseKey(string filePath, string? key)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        string json = File.ReadAllText(filePath);

        if (JsonNode.Parse(json, jsonNodeOptions) is not { } doc)
        {
            json = key is null
                ? "{}"
                : $$"""
                    {
                        "GeoBlazor": {   
                            "LicenseKey": "{{key.Replace("\u002B", "+")}}",
                            "Theme": "Dark"
                        }
                    }            
                    """;
        }
        else
        {
            doc["GeoBlazor"] = new JsonObject { ["LicenseKey"] = key, ["Theme"] = "Dark" };
            json = doc.ToJsonString(jsonSerializerOptions);
        }

        File.WriteAllText(filePath, json);
    }

    private static List<TestRecord> AnalyzeUnitTests(string projectPath)
    {
        List<TestRecord> tests = [];
        string directoryPath = Path.GetDirectoryName(projectPath)!;

        if (!Directory.Exists(directoryPath))
        {
            return tests;
        }

        string[] files = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            string text = File.ReadAllText(file);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(text);
            SyntaxNode root = tree.GetRoot();

            BaseNamespaceDeclarationSyntax? namespaceDeclarationSyntax = root
                .DescendantNodes()
                .OfType<BaseNamespaceDeclarationSyntax>()
                .FirstOrDefault();

            ClassDeclarationSyntax? classDeclaration = root
                .DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault();

            if (namespaceDeclarationSyntax is null 
                || classDeclaration is null 
                || classDeclaration.AttributeLists
                    .SelectMany(a => a.Attributes)
                    .All(a => a.Name.ToString() != "TestClass")) 
            {
                continue;
            }

            string nameSpace = namespaceDeclarationSyntax.Name.ToString();
            string className = classDeclaration.Identifier.Text;

            string[] classCategories = classDeclaration.AttributeLists
                .SelectMany(a => a.Attributes)
                .Where(a => a.Name.ToString() == "TestCategory")
                .SelectMany(a => a.ArgumentList!.Arguments)
                .Select(ag => ag.FullSpan.ToString())
                .ToArray();

            tests.AddRange(classDeclaration
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Where(m => m.AttributeLists
                    .SelectMany(a => a.Attributes)
                    .Any(a => a.Name.ToString() is "TestMethod" or "DataTestMethod"))
                .Select(m =>
                    new TestRecord($"{className}.{m.Identifier.Text}", nameSpace, className, m.Identifier.Text,
                        m.AttributeLists
                            .SelectMany(a => a.Attributes)
                            .Where(a => a.Name.ToString() == "TestCategory")
                            .SelectMany(a => a.ArgumentList!.Arguments)
                            .Select(ag => ag.FullSpan.ToString())
                            .Concat(classCategories)
                            .ToArray())));
        }

        return tests;
    }

    private static readonly Stopwatch fullSuiteStopwatch = new();
    private static readonly Stopwatch webLaunchStopwatch = new();
    private static readonly JsonNodeOptions jsonNodeOptions = new();
    private static readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };
    private static readonly List<Task> runTasks = [];

    private static readonly RetryStrategyOptions appRetryStrategyOptions = new()
    {
        BackoffType = DelayBackoffType.Exponential,
        MaxRetryAttempts = 3,
        Delay = TimeSpan.FromSeconds(5),
        ShouldHandle = new PredicateBuilder()
            .Handle<IOException>()
            .Handle<ProcessExitedException>()
            .Handle<ContainerException>(),
        OnRetry = context =>
        {
            Trace.WriteLine($"Attempt #{context.AttemptNumber + 1} for task failed with exception {
                context.Context.Properties.GetValue(exceptionKey, "")}. Retrying...",
                context.Context.OperationKey);
            context.Context.Properties.Set(retryAttemptKey, context.AttemptNumber);

            return ValueTask.CompletedTask;
        }
    };
    private static readonly ResiliencePipeline appRetryPipeline = new ResiliencePipelineBuilder()
        .AddRetry(appRetryStrategyOptions)
        .Build();
    private static readonly CancellationTokenSource gracefulCts = new();
    private static readonly Dictionary<string, Dictionary<DateTime, string>> logBuilders = [];
    private static readonly Type[] testClasses = typeof(GeoBlazorTestClass).Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(typeof(GeoBlazorTestClass)))
        .ToArray();
    private static readonly List<TestRecord> webTests = testClasses
        .SelectMany(t => t.GetMethods(BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.DeclaredOnly)
            .Select(m => new TestRecord(m.TestName(), t.Namespace!, t.Name, m.Name, 
                t.GetCustomAttributes<TestCategoryAttribute>()
                    .SelectMany(ca => ca.TestCategories)
                    .Concat(m.GetCustomAttributes<TestCategoryAttribute>()
                        .SelectMany(ma => ma.TestCategories)).ToArray())))
        .ToList();
    private static readonly List<TestRecord> coreWebTests = webTests
        .Where(t => t.ClassName.StartsWith("CORE_"))
        .ToList();
    private static readonly List<TestRecord> proWebTests = webTests
        .Where(t => t.ClassName.StartsWith("PRO_"))
        .ToList();
    private static readonly List<TestRecord> coreUnitTests = AnalyzeUnitTests(CoreUnitTestPath);
    private static readonly List<TestRecord> proUnitTests = AnalyzeUnitTests(ProUnitTestPath);
    private static readonly List<TestRecord> proValidationTests = AnalyzeUnitTests(ProValidationTestPath);
    private static readonly List<int> processIds = [];

    private static readonly ResiliencePropertyKey<int> retryAttemptKey = new("RetryAttempt");
    private static readonly ResiliencePropertyKey<string?> exceptionKey = new("Exception");

    private static string? _runConfig;
    private static string? _targetFramework;
    private static int? _webTestProcessId;
    private static DateTime _webTestStartTime;
    private static bool _useContainer;
    private static bool _noCache;
    private static bool _cover;
    private static bool _showDialog;
    private static bool _cleanupComplete;
    private static bool _webAppContainerExceptionThrown;
    private static string? _webAppContainerExceptionMessage;
    private static string _coverageFormat = string.Empty;
    private static string _coverageFileVersion = string.Empty;
    private static string? _reportGenLicenseKey;
    private static List<string>? _filters;

    private enum FilterOperator
    {
        Contains,
        NotContains,
        Equals,
        NotEquals
    }

    private enum FilterType
    {
        FullyQualifiedName,
        Name,
        ClassName,
        Priority,
        TestCategory
    }
}

internal class ContainerException(string message) : Exception(message);

internal static class ProcessName
{
    public static readonly string[] OrderedList =
    {
        TEST_SETUP,
        PRE_BUILD,
        CODE_COVERAGE_TOOL_INSTALLATION,
        WEB_APP_SERVER,
        WEB_TEST,
        CORE_UNIT,
        PRO_UNIT,
        PRO_VALIDATION,
        CODE_COVERAGE,
        CODE_COVERAGE_REPORT,
        TEST_CLEANUP,
        TEST_SHUTDOWN,
        FINAL_SUMMARY
    };
    public const string TEST_SETUP = "TEST_SETUP";
    public const string PRE_BUILD = "PRE_BUILD";
    public const string CODE_COVERAGE_TOOL_INSTALLATION = "CODE_COVERAGE_TOOL_INSTALLATION";
    public const string WEB_APP_SERVER = "WEB_APP_SERVER";
    public const string WEB_TEST = "WEB_TEST";
    public const string CORE_UNIT = "CORE_UNIT";
    public const string PRO_UNIT = "PRO_UNIT";
    public const string PRO_VALIDATION = "PRO_VALIDATION";
    public const string CODE_COVERAGE = "CODE_COVERAGE";
    public const string CODE_COVERAGE_REPORT = "CODE_COVERAGE_REPORT";
    public const string TEST_CLEANUP = "TEST_CLEANUP";
    public const string TEST_SHUTDOWN = "TEST_SHUTDOWN";
    public const string FINAL_SUMMARY = "FINAL_SUMMARY";
    public const string PRE_BUILD_ERROR = "PRE_BUILD_ERROR";
    public const string CODE_COVERAGE_TOOL_INSTALLATION_ERROR = "CODE_COVERAGE_TOOL_INSTALLATION_ERROR";
    public const string WEB_APP_ERROR = "WEB_APP_ERROR";
    public const string WEB_TEST_ERROR = "WEB_TEST_ERROR";
    public const string CODE_COVERAGE_ERROR = "CODE_COVERAGE_ERROR";
    public const string CODE_COVERAGE_REPORT_ERROR = "CODE_COVERAGE_REPORT_ERROR";
}

public record TestRecord(string TestName, string Namespace, string ClassName, string MethodName, 
    string[] Categories)
{
    public string FullyQualifiedName => $"{Namespace}.{TestName}";
}