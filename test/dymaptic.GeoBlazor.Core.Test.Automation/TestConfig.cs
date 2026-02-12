using CliWrap;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Polly;
using Polly.Retry;
using System.Net;
using System.Runtime.InteropServices;
using DelayBackoffType = Polly.DelayBackoffType;


[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]


namespace dymaptic.GeoBlazor.Core.Test.Automation;

[TestClass]
public class TestConfig
{
    public static string TestAppUrl { get; private set; } = "";
    public static BlazorMode RenderMode { get; private set; }
    public static bool CoreOnly { get; private set; }
    public static bool ProOnly { get; private set; }
    public static bool UnitOnly { get; set; }
    public static bool WebOnly { get; set; }

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

    public static ConcurrentDictionary<string, string> FailedTests { get; } = new();

    public static ConcurrentDictionary<string, byte> InconclusiveTests { get; } = new();
    public static ConcurrentDictionary<string, byte> PassedTests { get; } = new();
    public static ConcurrentDictionary<string, byte> SkippedTests { get; } = new();
    public static List<string>? FilteredTests { get; set; }

    private static string ComposeFilePath => _proAvailable && !CoreOnly ? ProComposeFilePath : CoreComposeFilePath;
    private static string CoreComposeFilePath => Path.Combine(_projectFolder, "docker-compose-core.yml");
    private static string ProComposeFilePath => Path.Combine(_projectFolder, "docker-compose-pro.yml");
    private static string CoreUnitTestComposeFilePath => Path.Combine(_projectFolder, "docker-compose-core-unit.yml");
    private static string ProUnitTestComposeFilePath => Path.Combine(_projectFolder, "docker-compose-pro-unit.yml");
    private static string ProValidationTestComposeFilePath =>
        Path.Combine(_projectFolder, "docker-compose-pro-validation.yml");
    private static string TestAppPath => _proAvailable
        ? Path.GetFullPath(Path.Combine(_projectFolder, "..", "..", "..", "test",
            "dymaptic.GeoBlazor.Pro.Test.WebApp",
            "dymaptic.GeoBlazor.Pro.Test.WebApp",
            "dymaptic.GeoBlazor.Pro.Test.WebApp.csproj"))
        : Path.GetFullPath(Path.Combine(_projectFolder, "..",
            "dymaptic.GeoBlazor.Core.Test.WebApp",
            "dymaptic.GeoBlazor.Core.Test.WebApp",
            "dymaptic.GeoBlazor.Core.Test.WebApp.csproj"));
    private static string TestAppHttpUrl => $"http://localhost:{_httpPort}";
    private static string CoverageFolderPath => Path.Combine(_projectFolder, "coverage");
    private static string CoverageFilePath =>
        Path.Combine(CoverageFolderPath, $"coverage.{_coverageFileVersion}.{_coverageFormat}");
    private static string UnitCoverageFolderPath => Path.Combine(_projectFolder, "unit-coverage");
    private static string CoreUnitCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.core.unit.{_coverageFileVersion}.{_coverageFormat}");
    private static string ProUnitCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.pro.unit.{_coverageFileVersion}.{_coverageFormat}");
    private static string ProValidationCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.pro.validation.{_coverageFileVersion}.{_coverageFormat}");
    private static string CoreRepoRoot => Path.GetFullPath(Path.Combine(_projectFolder, "..", ".."));
    private static string ProRepoRoot => Path.GetFullPath(Path.Combine(_projectFolder, "..", "..", ".."));
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
    private static string LogFilePath => Path.Combine(_projectFolder, "test-run.log");
    private static string CoreTestSolutionFilePath => Path.Combine(CoreRepoRoot, "test",
        "dymaptic.GeoBlazor.Core.test.slnx");
    private static string ProTestSolutionFilePath => Path.Combine(ProRepoRoot, "test",
        "dymaptic.GeoBlazor.Pro.test.slnx");
    private static string SolutionFilePath => _proAvailable ? ProTestSolutionFilePath : CoreTestSolutionFilePath;
    public static int WebFailedTestCount;
    public static int WebInconclusiveTestCount;

    public static readonly CancellationTokenSource Cts = new();

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new StringBuilderTraceListener(logBuilders));
        Trace.AutoFlush = true;

        // Handle Ctrl-C gracefully
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true; // Prevent immediate termination to allow cleanup
            Trace.WriteLine("Ctrl-C detected, initiating shutdown...", ProcessName.TEST_SHUTDOWN);

            _ = Task.Run(AssemblyCleanup);

            var timeoutSeconds = 30;

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
            var os = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "win"
                : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                    ? "osx"
                    : "linux";
            var arch = RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant();

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
        Trace.WriteLine($"Using HTTPS Port: {_httpsPort}", ProcessName.TEST_SETUP);

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

        if (!_useContainer)
        {
            await LaunchPipelineTask(ProcessName.PRE_BUILD, PreBuildAllProjects);
        }

        List<Task> runTasks = [];

        if (!UnitOnly)
        {
            // WEB TESTS
            runTasks.Add(LaunchPipelineTask(ProcessName.WEB_APP, LaunchWebTests));
        }

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

        await Task.WhenAll(runTasks);
        _webTestStartTime = DateTime.UtcNow;
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        var webTestEndTime = DateTime.UtcNow;

        try
        {
            var isCancelled = Cts.IsCancellationRequested;

            // Dispose browser pool first
            if (BrowserPool.TryGetInstance(out var pool) && pool is not null)
            {
                Trace.WriteLine("Disposing browser pool...", ProcessName.TEST_CLEANUP);

                try
                {
                    using var timeoutCts =
                        new CancellationTokenSource(TimeSpan.FromSeconds(isCancelled ? 3 : 10));
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
                        ShutdownContainerCoverage(ProcessName.WEB_APP, ComposeFilePath)
                    ];

                    if (!ProOnly)
                    {
                        coverageShutdownTasks.Add(ShutdownContainerCoverage(ProcessName.CORE_UNIT,
                            CoreUnitTestComposeFilePath));
                    }

                    if (!CoreOnly)
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

                if (!ProOnly)
                {
                    appShutdownTasks.Add(StopContainer(CoreUnitTestComposeFilePath));
                }

                if (!CoreOnly)
                {
                    appShutdownTasks.Add(StopContainer(ProUnitTestComposeFilePath));
                    appShutdownTasks.Add(StopContainer(ProValidationTestComposeFilePath));
                }

                await Task.WhenAll(appShutdownTasks);
            }
            else if (!CoreOnly)
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

            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            Trace.WriteLine("TEST RUN COMPLETE", ProcessName.FINAL_SUMMARY);

            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            if (!ProOnly)
            {
                AddTestProcessSummary(ProcessName.CORE_UNIT);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            if (!CoreOnly)
            {
                AddTestProcessSummary(ProcessName.PRO_UNIT);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
                AddTestProcessSummary(ProcessName.PRO_VALIDATION);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            Trace.WriteLine($"{ProcessName.WEB_APP} SUMMARY: {(WebFailedTestCount > 0 ? "FAILED!" : "PASSED")}",
                ProcessName.FINAL_SUMMARY);
            Trace.WriteLine($"  total: {_webTestTotalTestCount}", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine($"  failed: {WebFailedTestCount}", ProcessName.FINAL_SUMMARY);
            var succeeded = _webTestTotalTestCount - WebFailedTestCount - WebInconclusiveTestCount;
            Trace.WriteLine($"  succeeded: {succeeded}", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine($"  skipped: {WebInconclusiveTestCount}", ProcessName.FINAL_SUMMARY);
            var webTestDuration = webTestEndTime - _webTestStartTime;

            Trace.WriteLine(
                $"  duration: {webTestDuration.Minutes}m {webTestDuration.Seconds}s {webTestDuration.Milliseconds}ms",
                ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            Trace.WriteLine($"PASSED TESTS: {PassedTests.Count} / {FilteredTests!.Count}", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            if (InconclusiveTests.Count > 0)
            {
                Trace.WriteLine($"INCONCLUSIVE TESTS: {InconclusiveTests.Count}", ProcessName.FINAL_SUMMARY);

                foreach (var inconclusive in InconclusiveTests.Keys)
                {
                    Trace.WriteLine($"  {inconclusive}", ProcessName.FINAL_SUMMARY);
                }

                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            if (SkippedTests.Count > 0)
            {
                Trace.WriteLine($"INCONCLUSIVE TESTS: {SkippedTests.Count}", ProcessName.FINAL_SUMMARY);

                foreach (var skipped in SkippedTests.Keys)
                {
                    Trace.WriteLine($"  {skipped}", ProcessName.FINAL_SUMMARY);
                }

                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            }

            Trace.WriteLine($"FAILED TESTS: {FailedTests.Count}", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

            if (FailedTests.Count > 0)
            {
                Trace.WriteLine("FAILED TEST DETAILS:", ProcessName.FINAL_SUMMARY);
                Trace.WriteLine("-------------------------------------------------------", ProcessName.FINAL_SUMMARY);

                var sortedFailedTests = FailedTests
                    .OrderBy(kvp => kvp.Key)
                    .ToList();

                for (var i = 0; i < sortedFailedTests.Count; i++)
                {
                    var failedTest = sortedFailedTests[i];

                    if (i > 0)
                    {
                        Trace.WriteLine("------------", ProcessName.FINAL_SUMMARY);
                    }

                    // trim off extra timestamp from web browser and split lines
                    var errorLines = failedTest.Value.Substring(26).Split(Environment.NewLine);

                    Trace.WriteLine($"  {failedTest.Key}:",
                        ProcessName.FINAL_SUMMARY);

                    foreach (var errorLine in errorLines)
                    {
                        Trace.WriteLine($"    {errorLine}", ProcessName.FINAL_SUMMARY);
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
        var context = ResilienceContextPool.Shared.Get(
            new ResilienceContextCreationArguments(taskName, null, Cts.Token));
        await appRetryPipeline.ExecuteAsync(task, context);

        ResilienceContextPool.Shared.Return(context);
    }

    private static void SetupConfiguration()
    {
        _projectFolder = Assembly.GetAssembly(typeof(TestConfig))!.Location;

        if (_projectFolder.Contains("bin"))
        {
            var parts = _projectFolder.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            _runConfig = parts[^3];
            _targetFramework = parts[^2];
        }

        while (_projectFolder.Contains("bin"))
        {
            // get the test project folder
            _projectFolder = Path.GetDirectoryName(_projectFolder)!;
        }

        // assemblyLocation = GeoBlazor.Pro/GeoBlazor/test/dymaptic.GeoBlazor.Core.Test.Automation
        // this pulls us up to GeoBlazor.Pro then finds the Dockerfile
        var proDockerPath = Path.GetFullPath(Path.Combine(_projectFolder, "..", "..", "..", "Dockerfile"));
        _proAvailable = File.Exists(proDockerPath);

        _configuration = new ConfigurationBuilder()
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

        _httpsPort = _configuration.GetValue("HTTPS_PORT", 9443);
        _httpPort = _configuration.GetValue("HTTP_PORT", 8080);
        TestAppUrl = _configuration.GetValue("WEB_APP_URL", $"https://localhost:{_httpsPort}");

        // Default to Server Mode for compatibility with Code Coverage Tools
        var renderMode = _configuration.GetValue("RENDER_MODE", nameof(BlazorMode.Server));

        if (Enum.TryParse(renderMode, true, out BlazorMode blazorMode))
        {
            RenderMode = blazorMode;
        }

        ParseFilters();

        _useContainer = _configuration.GetValue("USE_CONTAINER", false);

        // Configure browser pool size - larger pools improve parallelism
        IsCI = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
        var defaultPoolSize = IsCI ? 4 : 8; // Doubled from 2/4 to 4/8 for better parallelization
        BrowserPoolSize = _configuration.GetValue("BROWSER_POOL_SIZE", defaultPoolSize);
        Trace.WriteLine($"Browser pool size set to: {BrowserPoolSize} (CI: {IsCI})", ProcessName.TEST_SETUP);

        if (_cover)
        {
            _coverageFormat = _configuration.GetValue("COVERAGE_FORMAT", "xml");
            _coverageFileVersion = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            _reportGenLicenseKey = _configuration["REPORT_GEN_LICENSE_KEY"];
        }

        var config = _configuration["CONFIGURATION"];

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

        _targetFramework ??= _configuration.GetValue("TARGET_FRAMEWORK", "net10.0");
        _showDialog = _configuration.GetValue("SHOW_DIALOG", true);
    }

    private static void ParseFilters()
    {
        var envArgs = Environment.GetCommandLineArgs();

        bool? filtersIncludeCoreTests = null;
        bool? filtersIncludeProTests = null;

        FilteredTests = testClasses
            .SelectMany(t => t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(m => m.TestName()))
            .ToList();

        for (var i = 0; i < envArgs.Length; i++)
        {
            var arg = envArgs[i];

            if ((arg == "--filter") && (i + 1 < envArgs.Length))
            {
                filtersIncludeCoreTests ??= false;
                filtersIncludeProTests ??= false;
                _filters ??= [];
                var filter = envArgs[i + 1].Replace("\\", "");
                _filters.Add(filter);
                List<string> filteredTests = [];
                var filterIncludesProTests = false;
                var filterIncludesCoreTests = false;

                ParseFilter(filter, ref filteredTests,
                    ref filterIncludesProTests, ref filterIncludesCoreTests);
                filtersIncludeProTests = filtersIncludeProTests.Value || filterIncludesProTests;
                filtersIncludeCoreTests = filtersIncludeCoreTests.Value || filterIncludesCoreTests;
                FilteredTests = FilteredTests.Intersect(filteredTests).ToList();
            }
        }

        if (!UnitOnly && (FilteredTests.Count == 0))
        {
            throw new InvalidOperationException("No tests found to run. Please check your filters.");
        }

        if (_proAvailable)
        {
            CoreOnly = _configuration!.GetValue("CORE_ONLY", false) || (filtersIncludeProTests == false);

            ProOnly = _configuration!.GetValue("PRO_ONLY", false) || (filtersIncludeCoreTests == false);
        }
        else
        {
            CoreOnly = true;
            ProOnly = false;
        }

        // only run coverage on a full test run, otherwise it overwrites the test coverage from previous runs
        _cover = _configuration!.GetValue("COVER", false)
            && _filters is null
            && !CoreOnly && !ProOnly
            && !WebOnly && !UnitOnly;

        // count this here because we add the unit tests later
        _webTestTotalTestCount = FilteredTests.Count;
    }

    private static void ParseFilter(string filter, ref List<string> filteredTests,
        ref bool filterIncludesProTests, ref bool filterIncludesCoreTests)
    {
        // check for custom filters first
        var lowered = filter.ToLowerInvariant();

        switch (lowered)
        {
            case "web":
                WebOnly = true;
                filterIncludesProTests = true;
                filterIncludesCoreTests = true;

                filteredTests = testClasses
                    .SelectMany(t =>
                        t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                            .Select(m => m.TestName()))
                    .ToList();

                return;
            case "unit":
                UnitOnly = true;
                filterIncludesProTests = true;
                filterIncludesCoreTests = true;

                return;
            case "core":
            case "core_":
                filteredTests = testClasses
                    .Where(c => c.Name.StartsWith("CORE_"))
                    .SelectMany(t =>
                        t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                            .Select(m => m.TestName()))
                    .ToList();
                filterIncludesCoreTests = true;

                return;
            case "pro":
            case "pro_":
                filteredTests = testClasses
                    .Where(c => c.Name.StartsWith("PRO_"))
                    .SelectMany(t =>
                        t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                            .Select(m => m.TestName()))
                    .ToList();
                filterIncludesProTests = true;

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
                var filterType = FilterType.FullyQualifiedName;
                var filterValue = filter;
                var filterOp = FilterOperator.Contains;

                if (operators.Keys
                        .OrderByDescending(k => k.Length) // order to check the negative operators first
                        .FirstOrDefault(filter.Contains) is { } op)
                {
                    filterOp = operators[op];
                    var split = filter.Split(op);
                    filterType = Enum.Parse<FilterType>(split[0]);
                    filterValue = split[1];
                }

                foreach (var testType in testClasses)
                {
                    ParseTestClass(testType, filterType, filterOp, filterValue, filteredTests,
                        ref filterIncludesProTests, ref filterIncludesCoreTests);
                }

                break;
            }
        }
    }

    private static void ParseTestClass(Type testType, FilterType filterType, FilterOperator filterOp,
        string filterValue, List<string> filteredTests, ref bool filterIncludesProTests,
        ref bool filterIncludesCoreTests)
    {
        var className = testType.Name;
        var isPro = className.StartsWith("PRO_");
        List<string> classTests = [];

        var classTestCategories = testType
            .GetCustomAttributes<TestCategoryAttribute>()
            .SelectMany(ca => ca.TestCategories)
            .ToArray();

        var methods = testType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        var methodTestCategories = methods
            .ToDictionary(m => m.TestName(),
                m => m.GetCustomAttributes<TestCategoryAttribute>()
                    .SelectMany(ca => ca.TestCategories)
                    .Concat(classTestCategories)
                    .ToArray());

        switch (filterType)
        {
            case FilterType.ClassName:
                if (IsMatch(className, filterValue, filterOp))
                {
                    classTests.AddRange(methods.Select(m => m.TestName()));
                }

                break;
            case FilterType.Name:
                foreach (var method in methods)
                {
                    if (IsMatch(method.Name, filterValue, filterOp))
                    {
                        classTests.Add(method.TestName());
                    }
                }

                break;
            case FilterType.FullyQualifiedName:
                foreach (var method in methods)
                {
                    var fullyQualifiedName = $"{method.DeclaringType!.FullName}.{method.Name}";

                    var fullyQualifiedWithoutCoreOrPro = fullyQualifiedName
                        .Replace("CORE_", "")
                        .Replace("PRO_", "");

                    if (IsMatch(fullyQualifiedWithoutCoreOrPro, filterValue, filterOp)
                        || IsMatch(fullyQualifiedName, filterValue, filterOp))
                    {
                        classTests.Add(method.TestName());
                    }
                }

                break;
            case FilterType.TestCategory:
                foreach (var kvp in methodTestCategories)
                {
                    foreach (var testCategory in kvp.Value)
                    {
                        if (IsMatch(testCategory, filterValue, filterOp))
                        {
                            classTests.Add(kvp.Key);

                            break;
                        }
                    }
                }

                break;
        }

        if (classTests.Count > 0)
        {
            if (isPro)
            {
                filterIncludesProTests = true;
            }
            else
            {
                filterIncludesCoreTests = true;
            }

            filteredTests.AddRange(classTests);
        }
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
    }

    private static async ValueTask LaunchUnitTests(ResilienceContext context)
    {
        try
        {
            // Pro Unit tests need to always run in a container because they wipe out state that other tests depend on.
            if (_useContainer || context.OperationKey == ProcessName.PRO_UNIT)
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
        Directory.CreateDirectory(Path.Combine(_projectFolder, "coverage"));
    }

    private static async Task EnsurePlaywrightBrowsersAreInstalled()
    {
        try
        {
            // Use Playwright's built-in installation via Program.Main
            // This is more reliable cross-platform than calling pwsh
            var exitCode = Program.Main(["install"]);

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

    private static async ValueTask PreBuildAllProjects(ResilienceContext context)
    {
        Trace.WriteLine($"Building {SolutionFilePath}...", ProcessName.PRE_BUILD);

        var result = await Cli.Wrap("dotnet")
            .WithArguments([
                "build",
                SolutionFilePath,
                "-c", _runConfig!,
                "/p:GenerateXmlComments=false",
                "/p:GeneratePackage=false",
                "/p:GenerateDocs=false",
                "/p:ShowScriptDialogs=false"
            ])
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                Trace.WriteLine(line, ProcessName.PRE_BUILD)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
                Trace.WriteLine(line, ProcessName.PRE_BUILD_ERROR)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync(context.CancellationToken, gracefulCts.Token);

        if (result.ExitCode != 0)
        {
            throw new ProcessExitedException($"Pre-build of {SolutionFilePath} failed with exit code {result.ExitCode
            }");
        }

        Trace.WriteLine($"Successfully built {SolutionFilePath}", ProcessName.PRE_BUILD);

        Trace.WriteLine("Pre-build complete", ProcessName.PRE_BUILD);
    }

    private static async ValueTask RunUnitTests(ResilienceContext context)
    {
        var processName = context.OperationKey!;

        var testPath = processName switch
        {
            ProcessName.CORE_UNIT => CoreUnitTestPath,
            ProcessName.PRO_UNIT => ProUnitTestPath,
            ProcessName.PRO_VALIDATION => ProValidationTestPath,
            _ => throw new ArgumentOutOfRangeException(nameof(processName), processName, null)
        };

        var coverageFilePath = processName switch
        {
            ProcessName.CORE_UNIT => CoreUnitCoverageFilePath,
            ProcessName.PRO_UNIT => ProUnitCoverageFilePath,
            ProcessName.PRO_VALIDATION => ProValidationCoverageFilePath,
            _ => throw new ArgumentOutOfRangeException(nameof(processName), processName, null)
        };

        var cmdLineApp = "dotnet";

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

        if (_filters is not null && (_filters.Count > 0))
        {
            foreach (var filter in _filters)
            {
                args.Add("--filter");
                args.Add(filter);
            }
        }

        if (_cover)
        {
            Directory.CreateDirectory(UnitCoverageFolderPath);
            cmdLineApp = "dotnet-coverage";
            var dotnetCommand = $"dotnet {string.Join(" ", args)}";

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
        List<string> filteredTests = [];
        List<string> passedTests = [];

        var ioExceptionThrown = false;
        string? ioExceptionMessage = null;

        var result = await Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                TrackUnitTestOutput(output, processName, ref failedTests, ref inconclusiveTests,
                    ref filteredTests, ref passedTests, ref ioExceptionMessage, ref ioExceptionThrown)))
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

        foreach (var failedTest in failedTests)
        {
            FailedTests.TryAdd(failedTest.Key, failedTest.Value);
        }

        foreach (var test in inconclusiveTests)
        {
            InconclusiveTests.TryAdd(test, 0);
        }

        Trace.WriteLine($"Adding {passedTests.Count} passed tests to total test count", processName);

        foreach (var test in passedTests)
        {
            PassedTests.TryAdd(test, 0);
        }

        FilteredTests!.AddRange(filteredTests);
    }

    private static async ValueTask StartUnitTestContainer(ResilienceContext context)
    {
        var cmdLineApp = "docker";

        var processName = context.OperationKey!;

        var filePath = processName switch
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

        if (context.Properties.TryGetValue(retryAttemptKey, out var retryAttempt) && (retryAttempt > 0))
        {
            // if the first build fails, try with no cache
            await BuildContainer(filePath, processName, context);
        }

        Trace.WriteLine($"Starting container with: docker {string.Join(" ", args)}", processName);
        Trace.WriteLine($"Working directory: {_projectFolder}", processName);

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";
            var dockerCommand = $"docker {string.Join(" ", args)}";

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
        List<string> filteredTests = [];
        List<string> passedTests = [];

        string? ioExceptionMessage = null;
        var ioExceptionThrown = false;
        string? containerExceptionMessage = null;
        var containerExceptionThrown = false;
        CancellationTokenSource waitTokenSource = new();

        var linkedTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken, waitTokenSource.Token);

        _ = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["COVER"] = _cover.ToString().ToLower(),
                ["SESSION_ID"] = processName,
                ["COVERAGE_FORMAT"] = _coverageFormat,
                ["COVERAGE_FILE_VERSION"] = _coverageFileVersion,
                ["GEOBLAZOR_CORE_LICENSE_KEY"] = _configuration!["GEOBLAZOR_CORE_LICENSE_KEY"],
                ["GEOBLAZOR_PRO_LICENSE_KEY"] = _configuration["GEOBLAZOR_PRO_LICENSE_KEY"]
            })
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                TrackUnitTestOutput(output, processName, ref failedTests, ref inconclusiveTests,
                    ref filteredTests, ref passedTests, ref ioExceptionMessage, ref ioExceptionThrown,
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
            .WithWorkingDirectory(_projectFolder)
            .ExecuteAsync(linkedTokenSource.Token, gracefulCts.Token);

        var containerName = processName switch
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
                        ref filteredTests, ref passedTests, ref ioExceptionMessage, ref ioExceptionThrown,
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

        foreach (var failedTest in failedTests)
        {
            FailedTests.TryAdd(failedTest.Key, failedTest.Value);
        }

        foreach (var test in inconclusiveTests)
        {
            InconclusiveTests.TryAdd(test, 0);
        }

        Trace.WriteLine($"Adding {passedTests.Count} passed tests to total test count", processName);

        foreach (var test in passedTests)
        {
            PassedTests.TryAdd(test, 0);
        }

        FilteredTests!.AddRange(filteredTests);
    }

    private static void TrackUnitTestOutput(string output, string processName,
        ref Dictionary<string, string> failedTests, ref List<string> inconclusiveTests,
        ref List<string> filteredTests, ref List<string> passedTests,
        ref string? ioExceptionMessage, ref bool ioExceptionThrown, CancellationTokenSource? waitTokenSource = null)
    {
        var trimmedLine = output.Trim();

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
            var testName = trimmedLine.Split(" ")[1];
            failedTests.TryAdd(testName, output);
            filteredTests.Add(testName);
        }
        else if (trimmedLine.StartsWith("inconclusive ", StringComparison.OrdinalIgnoreCase))
        {
            var testName = trimmedLine.Split(" ")[1];
            inconclusiveTests.Add(testName);
            filteredTests.Add(testName);
        }
        else if (trimmedLine.StartsWith("passed ", StringComparison.OrdinalIgnoreCase))
        {
            var testName = trimmedLine.Split(" ")[1];
            passedTests.Add(testName);
            filteredTests.Add(testName);
        }

        Trace.WriteLine(output, processName);
    }

    private static async Task StartWebApp(CancellationToken token)
    {
        var cmdLineApp = "dotnet";

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
            "/p:UsePackageReference=false",
            "/p:ShowScriptDialogs=false",
            "-v:d"
        ];

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";

            // Join the dotnet run command into a single string for dotnet-coverage
            var dotnetCommand = $"dotnet {string.Join(" ", args)}";

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

        Trace.WriteLine($"Starting test app: {cmdLineApp} {string.Join(" ", args)}", ProcessName.TEST_SETUP);

        var ioExceptionThrown = false;
        string? ioExceptionMessage = null;

        var commandTask = Cli.Wrap(cmdLineApp)
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

                Trace.WriteLine(line, ProcessName.WEB_APP);
            }))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
                Trace.WriteLine(line, ProcessName.WEB_APP_ERROR)))
            .WithWorkingDirectory(_projectFolder)
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
        var cmdLineApp = "docker";

        string[] args =
        [
            "compose", "-f", ComposeFilePath, "up", "-d", "--build"
        ];

        if (context.Properties.TryGetValue(retryAttemptKey, out var retryAttempt) && (retryAttempt > 0))
        {
            // if the first build fails, try with no cache
            await BuildContainer(ComposeFilePath, ProcessName.WEB_APP, context);
        }

        Trace.WriteLine($"Starting container with: docker {string.Join(" ", args)}", ProcessName.WEB_APP);
        Trace.WriteLine($"Working directory: {_projectFolder}", ProcessName.WEB_APP);

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";
            var dockerCommand = $"docker {string.Join(" ", args)}";

            args =
            [
                "collect",
                "--session-id", ProcessName.WEB_APP,
                "-o", CoverageFilePath,
                "-f", _coverageFormat,
                dockerCommand
            ];
        }

        CancellationTokenSource waitTokenSource = new();

        var linkedTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken, waitTokenSource.Token);

        _webAppContainerExceptionThrown = false;
        _webAppContainerExceptionMessage = null;

        var commandTask = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["HTTP_PORT"] = _httpPort.ToString(),
                ["HTTPS_PORT"] = _httpsPort.ToString(),
                ["COVER"] = _cover.ToString().ToLower(),
                ["SESSION_ID"] = ProcessName.WEB_APP,
                ["COVERAGE_FORMAT"] = _coverageFormat,
                ["COVERAGE_FILE_VERSION"] = _coverageFileVersion,
                ["GEOBLAZOR_CORE_LICENSE_KEY"] = _configuration!["GEOBLAZOR_CORE_LICENSE_KEY"],
                ["GEOBLAZOR_PRO_LICENSE_KEY"] = _configuration["GEOBLAZOR_PRO_LICENSE_KEY"]
            })
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, ProcessName.WEB_APP)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
            {
                if (line.Contains("ERROR:"))
                {
                    _webAppContainerExceptionMessage = line;
                    _webAppContainerExceptionThrown = true;
                    waitTokenSource.Cancel();
                }
            }))
            .WithWorkingDirectory(_projectFolder)
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
        var cmdLineApp = "docker";

        string[] args =
        [
            "compose", "-f", filePath, "build", "--no-cache"
        ];

        Trace.WriteLine($"Re-building container with: docker {string.Join(" ", args)}", processName);
        Trace.WriteLine($"Working directory: {_projectFolder}", processName);

        CancellationTokenSource waitTokenSource = new();

        var linkedTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(context.CancellationToken, waitTokenSource.Token);

        _webAppContainerExceptionThrown = false;
        _webAppContainerExceptionMessage = null;

        await Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["HTTP_PORT"] = _httpPort.ToString(),
                ["HTTPS_PORT"] = _httpsPort.ToString(),
                ["COVER"] = _cover.ToString().ToLower(),
                ["SESSION_ID"] = processName,
                ["COVERAGE_FORMAT"] = _coverageFormat,
                ["COVERAGE_FILE_VERSION"] = _coverageFileVersion,
                ["GEOBLAZOR_CORE_LICENSE_KEY"] = _configuration!["GEOBLAZOR_CORE_LICENSE_KEY"],
                ["GEOBLAZOR_PRO_LICENSE_KEY"] = _configuration["GEOBLAZOR_PRO_LICENSE_KEY"]
            })
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, processName)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
            {
                if (line.Contains("ERROR:"))
                {
                    _webAppContainerExceptionMessage = line;
                    _webAppContainerExceptionThrown = true;
                    waitTokenSource.Cancel();
                }
            }))
            .WithWorkingDirectory(_projectFolder)
            .ExecuteAsync(linkedTokenSource.Token, gracefulCts.Token);

        if (_webAppContainerExceptionThrown)
        {
            throw new ContainerException(_webAppContainerExceptionMessage!);
        }
    }

    private static async Task ShutdownContainerCoverage(string processName, string composeFilePath)
    {
        // Get the container name from the compose file
        var containerName = processName switch
        {
            ProcessName.WEB_APP when composeFilePath.EndsWith("core.yml") => "geoblazor-core-tests-test-app-1",
            ProcessName.WEB_APP when composeFilePath.EndsWith("pro.yml") => "geoblazor-pro-tests-test-app-1",
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
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        using HttpClient httpClient = new(handler);

        // worst-case scenario for docker build is ~ 6 minutes
        // set this to 60 seconds * 8 = 8 minutes
        var maxAttempts = 60 * 8;

        Exception? lastException = null;
        Process? testProcess = null;

        for (var i = 1; i <= maxAttempts; i++)
        {
            try
            {
                if (i % 10 == 0)
                {
                    Trace.WriteLine($"Waiting for Test Site at {TestAppHttpUrl}. Attempt {i} out of {maxAttempts}...",
                        ProcessName.TEST_SETUP);
                }

                var response =
                    await httpClient.GetAsync(TestAppHttpUrl, Cts.Token);

                if (response.IsSuccessStatusCode ||
                    response.StatusCode is >= (HttpStatusCode)300 and < (HttpStatusCode)400)
                {
                    Trace.WriteLine($"Test Site is ready! Status: {response.StatusCode}", ProcessName.TEST_SETUP);

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
                    var exitCode = testProcess.ExitCode;

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
        // set this to 60 seconds * 8 = 8 minutes
        var maxAttempts = 60 * 8;

        Exception? lastException = null;

        string[] listArgs = ["container", "ls"];
        var isRunning = false;

        for (var i = 1; i <= maxAttempts; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            try
            {
                if (i % 10 == 0)
                {
                    Trace.WriteLine($"Waiting for Test Container {containerName}. Attempt {i} out of {maxAttempts}...",
                        processName);
                }

                await Cli.Wrap("docker")
                    .WithArguments(listArgs)
                    .WithValidation(CommandResultValidation.None)
                    .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                    {
                        if (line.Contains(containerName))
                        {
                            Trace.WriteLine($"Container {containerName} is running", processName);
                            isRunning = true;
                        }
                    }))
                    .ExecuteAsync(Cts.Token);

                if (isRunning)
                {
                    Trace.WriteLine($"Test Container {containerName} is ready!", processName);

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
        foreach (var processId in processIds)
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
            Trace.WriteLine($"Killing any remaining processes holding HTTPS port {_httpsPort}",
                ProcessName.TEST_CLEANUP);

            if (OperatingSystem.IsWindows())
            {
                string[] arguments =
                [
                    "-NoProfile", "-ExecutionPolicy", "ByPass", "-Command",
                    "{",
                    "Get-NetTCPConnection", "-LocalPort", _httpsPort.ToString(), "-State", "Listen",
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
                        $"lsof -i:{_httpsPort} | awk '{{if(NR>1)print $2}}' | xargs -t -r kill -9"
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
        var reportDir = Path.Combine(_projectFolder, "coverage-report");
        var historyDir = Path.Combine(_projectFolder, "history");

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

            var textSummaryPath = Path.Combine(reportDir, "Summary.txt");
            var webReportPath = Path.Combine(reportDir, "index.html");

            if (File.Exists(textSummaryPath))
            {
                Trace.WriteLine(await File.ReadAllTextAsync(textSummaryPath),
                    ProcessName.CODE_COVERAGE_REPORT);
                Trace.WriteLine($"Full report at [Coverage Report]({webReportPath})", ProcessName.CODE_COVERAGE_REPORT);
            }

            // copy the badge image to the repo root
            var lineBadgePath = Path.Combine(reportDir, "badge_linecoverage.svg");
            var methodBadgePath = Path.Combine(reportDir, "badge_methodcoverage.svg");
            var fullMethodBadgePath = Path.Combine(reportDir, "badge_fullmethodcoverage.svg");

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
        if (!logBuilders.TryGetValue(processName, out var coreUnitLog))
        {
            return;
        }

        var summaryStarted = false;

        foreach (var log in coreUnitLog.OrderBy(kv => kv.Key))
        {
            if (log.Value.Contains("Test run summary"))
            {
                summaryStarted = true;
                var passed = log.Value.Contains("Passed", StringComparison.OrdinalIgnoreCase);
                var line = passed ? $"{processName} SUMMARY: PASSED" : $"{processName} SUMMARY: FAILED";
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

        foreach (var (processName, logEntries)
            in logBuilders.OrderBy(kv => ProcessName.OrderedList.IndexOf(kv.Key)))
        {
            foreach (var entry in logEntries.OrderBy(kv => kv.Key))
            {
                sb.AppendLine($"[{entry.Key.ToString("u")}] {processName}: {entry.Value}");
            }
        }

        await File.WriteAllTextAsync(LogFilePath, sb.ToString());
    }

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
    private static readonly List<int> processIds = [];

    private static readonly ResiliencePropertyKey<int> retryAttemptKey = new("RetryAttempt");
    private static readonly ResiliencePropertyKey<string?> exceptionKey = new("Exception");

    private static IConfiguration? _configuration;
    private static string? _runConfig;
    private static string? _targetFramework;
    private static bool _proAvailable;
    private static int _httpsPort;
    private static int _httpPort;
    private static string _projectFolder = string.Empty;
    private static int? _webTestProcessId;
    private static int _webTestTotalTestCount;
    private static DateTime _webTestStartTime;
    private static bool _useContainer;
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
        TEST_SETUP, PRE_BUILD, CODE_COVERAGE_TOOL_INSTALLATION, WEB_APP, WEB_TEST, CORE_UNIT, PRO_UNIT,
        PRO_VALIDATION, CODE_COVERAGE, CODE_COVERAGE_REPORT, TEST_CLEANUP, TEST_SHUTDOWN, FINAL_SUMMARY
    };
    public const string TEST_SETUP = "TEST_SETUP";
    public const string PRE_BUILD = "PRE_BUILD";
    public const string CODE_COVERAGE_TOOL_INSTALLATION = "CODE_COVERAGE_TOOL_INSTALLATION";
    public const string WEB_APP = "WEB_APP";
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