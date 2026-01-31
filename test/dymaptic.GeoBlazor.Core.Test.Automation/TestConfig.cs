using CliWrap;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Polly;
using Polly.Retry;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
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

    public static Dictionary<string, string> FailedTests { get; } = [];

    public static List<string> InconclusiveTests { get; } = [];

    public static int PassedTestCount { get; set; }

    private static string ComposeFilePath => _proAvailable && !CoreOnly ? ProComposeFilePath : CoreComposeFilePath;
    private static string CoreComposeFilePath => Path.Combine(_projectFolder, "docker-compose-core.yml");
    private static string ProComposeFilePath => Path.Combine(_projectFolder, "docker-compose-pro.yml");
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
    private static string CoreSourceGenCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.core.sourcegen.{_coverageFileVersion}.{_coverageFormat}");
    private static string ProUnitCoverageFilePath => Path.Combine(UnitCoverageFolderPath,
        $"coverage.pro.unit.{_coverageFileVersion}.{_coverageFormat}");
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
    private static string CoreSourceGenTestPath => Path.Combine(CoreRepoRoot, "test",
        "dymaptic.GeoBlazor.Core.SourceGenerator.Tests",
        "dymaptic.GeoBlazor.Core.SourceGenerator.Tests.csproj");
    private static string LogFilePath => Path.Combine(_projectFolder, "test-run.log");
    private static string CoreTestSolutionFilePath => Path.Combine(CoreRepoRoot, "test",
        "dymaptic.GeoBlazor.Core.test.slnx");
    private static string ProTestSolutionFilePath => Path.Combine(ProRepoRoot, "test",
        "dymaptic.GeoBlazor.Pro.test.slnx");
    private static string SolutionFilePath => _proAvailable ? ProTestSolutionFilePath : CoreTestSolutionFilePath;

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
            if (!cts.IsCancellationRequested)
            {
                cts.Cancel();
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
        Trace.WriteLine($"Test Filter: {_filter ?? "NONE"}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Generating Test Coverage Report: {_cover}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using Browser Pool Size: {BrowserPoolSize}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using Render Mode: {RenderMode}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using Container: {_useContainer}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Using HTTPS Port: {_httpsPort}", ProcessName.TEST_SETUP);


        // kill old running test apps and containers
        Task[] cleanupTasks =
        [
            StopContainer(CoreComposeFilePath),
            StopContainer(ProComposeFilePath),
            KillProcessesByTestPorts()
        ];

        await Task.WhenAll(cleanupTasks);

        Task[] setupTasks =
        [
            InstallCodeCoverageTools(),
            EnsurePlaywrightBrowsersAreInstalled()
        ];

        await Task.WhenAll(setupTasks);

        await LaunchPipelineTask(ProcessName.PRE_BUILD, PreBuildAllProjects);

        List<Task> runTasks =
        [
            LaunchPipelineTask(_useContainer ? ProcessName.TEST_CONTAINER : ProcessName.TEST_APP, LaunchWebTests)
        ];

        if (!ProOnly)
        {
            runTasks.Add(LaunchPipelineTask(ProcessName.CORE_UNIT_TESTS, ctx =>
                RunUnitTests(CoreUnitTestPath, CoreUnitCoverageFilePath, ctx)));

            runTasks.Add(LaunchPipelineTask(ProcessName.CORE_SGEN_TESTS, ctx =>
                RunUnitTests(CoreSourceGenTestPath, CoreSourceGenCoverageFilePath, ctx)));
        }

        if (!CoreOnly)
        {
            runTasks.Add(LaunchPipelineTask(ProcessName.PRO_UNIT_TESTS, ctx =>
                RunUnitTests(ProUnitTestPath, ProUnitCoverageFilePath, ctx)));
        }

        await Task.WhenAll(runTasks);
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        try
        {
            bool isCancelled = cts.IsCancellationRequested;

            // Dispose browser pool first
            if (BrowserPool.TryGetInstance(out BrowserPool? pool) && pool is not null)
            {
                Trace.WriteLine("Disposing browser pool...", ProcessName.TEST_CLEANUP);

                try
                {
                    using CancellationTokenSource timeoutCts =
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
                cts.CancelAfter(5000);
            }

            if (!gracefulCts.IsCancellationRequested)
            {
                await gracefulCts.CancelAsync();
            }

            // Shorter delay if already cancelled
            await Task.Delay(isCancelled ? 1000 : 5000);

            if (FailedTests.Count > 0)
            {
                _causeOfFailure = "GEOBLAZOR INTERACTIVE TESTS FAILED";
            }

            if (_useContainer)
            {
                await StopContainer(ComposeFilePath);

                if (_cover && _causeOfFailure is null)
                {
                    CopyCoverageFromContainer();
                }
            }
            else
            {
                await StopTestApp();
            }

            await KillProcessesByTestPorts();

            if (_cover)
            {
                await GenerateCoverageReport();
            }

            Trace.WriteLine("-------------------------------------------------------");

            Trace.WriteLine("Test run complete", ProcessName.FINAL_SUMMARY);

            if (_causeOfFailure is not null)
            {
                Trace.WriteLine($"*****FAILURE: {_causeOfFailure}*****", ProcessName.FINAL_SUMMARY);
            }

            Trace.WriteLine($"{PassedTestCount} / {_filteredTests.Count} tests passed.", ProcessName.FINAL_SUMMARY);
            Trace.WriteLine("Inconclusive Tests:", ProcessName.FINAL_SUMMARY);

            if (InconclusiveTests.Count > 0)
            {
                Trace.WriteLine("-------------------------------------------------------");

                foreach (string inconclusive in InconclusiveTests)
                {
                    Trace.WriteLine($"- {inconclusive}", ProcessName.FINAL_SUMMARY);
                }
            }

            if (FailedTests.Count > 0)
            {
                Trace.WriteLine("-------------------------------------------------------");
                Trace.WriteLine("Failed Tests:", ProcessName.FINAL_SUMMARY);

                foreach (KeyValuePair<string, string> failedTest in FailedTests)
                {
                    Trace.WriteLine($"- {failedTest.Key}: {Environment.NewLine}{failedTest.Value}",
                        ProcessName.FINAL_SUMMARY);
                }
            }

            Trace.WriteLine("-------------------------------------------------------");

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
            new ResilienceContextCreationArguments(taskName, null, cts.Token));
        await appRetryPipeline.ExecuteAsync(task, context);

        ResilienceContextPool.Shared.Return(context);
    }

    private static void SetupConfiguration()
    {
        _projectFolder = Assembly.GetAssembly(typeof(TestConfig))!.Location;

        if (_projectFolder.Contains("bin"))
        {
            string[] parts = _projectFolder.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
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
        string proDockerPath = Path.GetFullPath(Path.Combine(_projectFolder, "..", "..", "..", "Dockerfile"));
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
            .AddDotEnvFile(true, true)
            .AddCommandLine(Environment.GetCommandLineArgs())
            .Build();

        _httpsPort = _configuration.GetValue("HTTPS_PORT", 9443);
        _httpPort = _configuration.GetValue("HTTP_PORT", 8080);
        TestAppUrl = _configuration.GetValue("TEST_APP_URL", $"https://localhost:{_httpsPort}");

        // Default to Server Mode for compatibility with Code Coverage Tools
        string renderMode = _configuration.GetValue("RENDER_MODE", nameof(BlazorMode.Server));

        if (Enum.TryParse(renderMode, true, out BlazorMode blazorMode))
        {
            RenderMode = blazorMode;
        }

        ParseFilter();

        _useContainer = _configuration.GetValue("USE_CONTAINER", false);

        // Configure browser pool size - larger pools improve parallelism
        IsCI = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
        int defaultPoolSize = IsCI ? 4 : 8; // Doubled from 2/4 to 4/8 for better parallelization
        BrowserPoolSize = _configuration.GetValue("BROWSER_POOL_SIZE", defaultPoolSize);
        Trace.WriteLine($"Browser pool size set to: {BrowserPoolSize} (CI: {IsCI})", ProcessName.TEST_SETUP);

        if (_cover)
        {
            _coverageFormat = _configuration.GetValue("COVERAGE_FORMAT", "xml");
            _coverageFileVersion = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            _reportGenLicenseKey = _configuration["REPORT_GEN_LICENSE_KEY"];
        }

        string? config = _configuration["CONFIGURATION"];

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

    private static void ParseFilter()
    {
        string[] envArgs = Environment.GetCommandLineArgs();

        _filter = envArgs.IndexOf("--filter") is var index and > 0
            && (envArgs.Length > index + 1)
                ? envArgs[envArgs.IndexOf("--filter") + 1].Replace("\\", "")
                : null;

        bool filterIncludesCoreTests = false;
        bool filterIncludesProTests = false;

        if (_filter is not null)
        {
            Dictionary<string, FilterOperator> operators = new()
            {
                ["~"] = FilterOperator.Contains,
                ["!~"] = FilterOperator.NotContains,
                ["="] = FilterOperator.Equals,
                ["!="] = FilterOperator.NotEquals
            };
            FilterType filterType = FilterType.FullyQualifiedName;
            string filterValue = _filter;
            FilterOperator filterOp = FilterOperator.Contains;

            if (operators.Keys
                    .OrderByDescending(k => k.Length) // order to check the negative operators first
                    .FirstOrDefault(_filter.Contains) is { } op)
            {
                filterOp = operators[op];
                string[] split = _filter.Split(op);
                filterType = Enum.Parse<FilterType>(split[0]);
                filterValue = split[1];
            }

            foreach (Type testType in testClasses)
            {
                string className = testType.Name;
                string classFullName = testType.FullName!;
                bool isPro = testType.Namespace!.StartsWith("dymaptic.GeoBlazor.Pro");
                List<string> classTests = [];

                string[] classTestCategories = testType
                    .GetCustomAttributes<TestCategoryAttribute>()
                    .SelectMany(ca => ca.TestCategories)
                    .ToArray();

                MethodInfo[] methods = testType.GetMethods(
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                string[] methodFullNames = methods.Select(m => $"{classFullName}.{m.Name}").ToArray();

                string[] methodNames = methods.Select(m => m.Name).ToArray();

                Dictionary<string, string[]> methodTestCategories = methods
                    .ToDictionary(m => m.Name,
                        m => m.GetCustomAttributes<TestCategoryAttribute>()
                            .SelectMany(ca => ca.TestCategories)
                            .Concat(classTestCategories)
                            .ToArray());

                switch (filterType)
                {
                    case FilterType.ClassName:
                        if (IsMatch(className, filterValue, filterOp))
                        {
                            classTests.AddRange(methodNames);
                        }

                        break;
                    case FilterType.Name:
                        foreach (string methodName in methodNames)
                        {
                            if (IsMatch(methodName, filterValue, filterOp))
                            {
                                classTests.Add(methodName);
                            }
                        }

                        break;
                    case FilterType.FullyQualifiedName:
                        foreach (string methodFullName in methodFullNames)
                        {
                            if (IsMatch(methodFullName, filterValue, filterOp))
                            {
                                classTests.Add(methodFullName);
                            }
                        }

                        break;
                    case FilterType.TestCategory:
                        foreach (KeyValuePair<string, string[]> kvp in methodTestCategories)
                        {
                            foreach (string testCategory in kvp.Value)
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

                    _filteredTests.AddRange(classTests);
                }
            }
        }
        else
        {
            filterIncludesProTests = true;
            filterIncludesCoreTests = true;

            _filteredTests = testClasses
                .SelectMany(t => t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .Select(m => m.Name))
                .ToList();
        }

        if (_proAvailable)
        {
            CoreOnly = _configuration!.GetValue("CORE_ONLY", false) || !filterIncludesProTests;

            ProOnly = _configuration!.GetValue("PRO_ONLY", false) || !filterIncludesCoreTests;
        }
        else
        {
            CoreOnly = true;
            ProOnly = false;
        }

        // only run coverage on a full test run, otherwise it overwrites the test coverage from previous runs
        _cover = _configuration!.GetValue("COVER", false) && _filter is null;
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
        if (_useContainer)
        {
            await StartContainer(context.CancellationToken);
        }
        else
        {
            await StartTestApp(context.CancellationToken);
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

    private static async ValueTask PreBuildAllProjects(ResilienceContext context)
    {
        Trace.WriteLine($"Building {SolutionFilePath}...", ProcessName.PRE_BUILD);

        CommandResult result = await Cli.Wrap("dotnet")
            .WithArguments([
                "build",
                SolutionFilePath,
                "-c", _runConfig!,
                "/p:GenerateXmlComments=false",
                "/p:GeneratePackage=false",
                "/p:GenerateDocs=false",
                "/p:ShowSourceGenDialogs=false"
            ])
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                Trace.WriteLine(line, ProcessName.PRE_BUILD)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
                Trace.WriteLine(line, ProcessName.PRE_BUILD_ERROR)))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync(context.CancellationToken, gracefulCts.Token);

        if (result.ExitCode != 0)
        {
            _causeOfFailure = $"PRE_BUILD FAILED: {SolutionFilePath}";

            throw new ProcessExitedException($"Pre-build of {SolutionFilePath} failed with exit code {result.ExitCode
            }");
        }

        Trace.WriteLine($"Successfully built {SolutionFilePath}", ProcessName.PRE_BUILD);

        Trace.WriteLine("Pre-build complete", ProcessName.PRE_BUILD);
    }

    private static async ValueTask RunUnitTests(string testPath, string coverageFilePath,
        ResilienceContext context)
    {
        string cmdLineApp = "dotnet";

        string[] args =
        [
            "test",
            "--project",
            testPath,
            "--no-build",
            "-c",
            _runConfig!,
            "--output",
            "Detailed",
            "/p:ShowSourceGenDialogs=false"
        ];

        if (!string.IsNullOrEmpty(_filter))
        {
            args = [..args, "--filter", _filter];
        }

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
        int passedTestCount = 0;

        bool ioExceptionThrown = false;
        string? ioExceptionMessage = null;
        string testGroupName = context.OperationKey!;

        CommandResult result = await Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
            {
                string trimmedLine = output.Trim();

                if (trimmedLine.Contains("The process cannot access the file"))
                {
                    ioExceptionMessage = trimmedLine;
                    ioExceptionThrown = true;
                }

                if (trimmedLine.StartsWith("failed ", StringComparison.OrdinalIgnoreCase))
                {
                    string testName = output.Split(" ")[1];
                    failedTests.TryAdd(testName, output);
                    filteredTests.Add(testName);
                }
                else if (trimmedLine.StartsWith("inconclusive ", StringComparison.OrdinalIgnoreCase))
                {
                    string testName = output.Split(" ")[1];
                    inconclusiveTests.Add(testName);
                    filteredTests.Add(testName);
                }
                else if (trimmedLine.StartsWith("passed ", StringComparison.OrdinalIgnoreCase))
                {
                    string testName = output.Split(" ")[1];
                    passedTestCount++;
                    filteredTests.Add(testName);
                }

                Trace.WriteLine(output, testGroupName);
            }))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output => Trace.WriteLine(output, $"{testGroupName}_ERROR")))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync(context.CancellationToken, gracefulCts.Token);

        if ((result.ExitCode != 0) && (result.ExitCode != 8)) // 8 = 0 tests ran
        {
            _causeOfFailure = $"{testGroupName} FAILED";

            if (result.ExitCode != 2) // 2 = test failed, we let the other test runners continue without throwing
            {
                if (ioExceptionThrown)
                {
                    throw new IOException(ioExceptionMessage);
                }

                throw new ProcessExitedException($"{testGroupName} process   exited with code {result.ExitCode}");
            }
        }

        foreach (KeyValuePair<string, string> failedTest in failedTests)
        {
            FailedTests.TryAdd(failedTest.Key, failedTest.Value);
        }

        InconclusiveTests.AddRange(inconclusiveTests);
        PassedTestCount += passedTestCount;
        _filteredTests.AddRange(filteredTests);
    }

    private static async Task StartContainer(CancellationToken token)
    {
        string cmdLineApp = "docker";

        string[] args =
        [
            "compose", "-f", ComposeFilePath, "up", "-d", "--build"
        ];
        Trace.WriteLine($"Starting container with: docker {string.Join(" ", args)}", ProcessName.TEST_SETUP);
        Trace.WriteLine($"Working directory: {_projectFolder}", ProcessName.TEST_SETUP);

        string sessionId = "geoblazor-cover";

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";
            string dockerCommand = $"docker {string.Join(" ", args)}";

            args =
            [
                "collect",
                "--session-id", sessionId,
                "-o", CoverageFilePath,
                "-f", _coverageFormat,
                dockerCommand
            ];
        }

        CommandTask<CommandResult> commandTask = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["HTTP_PORT"] = _httpPort.ToString(),
                ["HTTPS_PORT"] = _httpsPort.ToString(),
                ["COVERAGE_ENABLED"] = _cover.ToString().ToLower(),
                ["SESSION_ID"] = sessionId,
                ["COVERAGE_FORMAT"] = _coverageFormat,
                ["COVERAGE_FILE_VERSION"] = _coverageFileVersion
            })
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, ProcessName.TEST_CONTAINER)))
            .WithStandardErrorPipe(
                PipeTarget.ToDelegate(line => Trace.WriteLine(line, ProcessName.TEST_CONTAINER_ERROR)))
            .WithWorkingDirectory(_projectFolder)
            .ExecuteAsync(token, gracefulCts.Token);

        _testProcessId = commandTask.ProcessId;

        await WaitForHttpResponse();
    }

    private static async Task StartTestApp(CancellationToken token)
    {
        string cmdLineApp = "dotnet";

        string[] args =
        [
            "run", "--no-build", "--project", TestAppPath,
            "--urls", $"{TestAppUrl};{TestAppHttpUrl}",
            "--", "-c", "Release",
            "/p:GenerateXmlComments=false",
            "/p:GeneratePackage=false",
            "/p:GenerateDocs=false",
            "/p:DebugSymbols=true",
            "/p:DebugType=portable",
            "/p:UsePackageReference=false",
            "/p:ShowSourceGenDialogs=false",
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
                dotnetCommand
            ];
        }

        Trace.WriteLine($"Starting test app: {cmdLineApp} {string.Join(" ", args)}", ProcessName.TEST_SETUP);

        bool ioExceptionThrown = false;
        string? ioExceptionMessage = null;

        CommandTask<CommandResult> commandTask = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
            {
                if (line.Contains("The process cannot access the file")
                    || line.Contains("The \"UpdateExternallyDefinedStaticWebAssets\" task failed unexpectedly."))
                {
                    ioExceptionMessage = line;
                    ioExceptionThrown = true;
                }

                Trace.WriteLine(line, ProcessName.TEST_APP);
            }))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, ProcessName.TEST_APP_ERROR)))
            .WithWorkingDirectory(_projectFolder)
            .ExecuteAsync(token, gracefulCts.Token);

        _testProcessId = commandTask.ProcessId;

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

    private static async Task StopContainer(string composeFilePath)
    {
        // If coverage is enabled, gracefully shutdown dotnet-coverage before stopping the container
        if (_cover)
        {
            await ShutdownCoverageCollection();
        }

        try
        {
            Trace.WriteLine($"Stopping container with: docker compose -f {composeFilePath} down",
                ProcessName.TEST_CLEANUP);

            await Cli.Wrap("docker")
                .WithArguments($"compose -f \"{composeFilePath}\" down")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, ProcessName.TEST_CLEANUP)))
                .ExecuteAsync(cts.Token);
        }
        catch
        {
            // ignore, these just clutter the output
        }
    }

    private static async Task StopTestApp()
    {
        await KillProcessById(_testProcessId);
    }

    private static async Task ShutdownCoverageCollection()
    {
        try
        {
            // Get the container name from the compose file
            string containerName = _proAvailable && !CoreOnly
                ? "geoblazor-pro-tests-test-app-1"
                : "geoblazor-core-tests-test-app-1";

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

    private static void CopyCoverageFromContainer()
    {
        // If coverage was enabled, copy the coverage file from the volume mount directory
        string containerCoverageFile = Path.Combine(_projectFolder, "coverage", "coverage.xml");
        string targetCoverageFile = Path.Combine(_projectFolder, $"coverage.{_coverageFormat}");

        if (File.Exists(containerCoverageFile))
        {
            File.Copy(containerCoverageFile, targetCoverageFile, true);
            Trace.WriteLine($"Coverage file copied from container: {targetCoverageFile}", ProcessName.TEST_CLEANUP);
        }
        else
        {
            Trace.WriteLine($"Container coverage file not found: {containerCoverageFile}", ProcessName.TEST_CLEANUP);
        }
    }

    private static async Task WaitForHttpResponse()
    {
        // Configure HttpClient to ignore SSL certificate errors (for self-signed certs in Docker)
        HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        using HttpClient httpClient = new(handler);

        // worst-case scenario for docker build is ~ 6 minutes
        // set this to 60 seconds * 8 = 8 minutes
        int maxAttempts = 60 * 8;

        Exception? lastException = null;
        Process? testProcess = null;

        for (int i = 1; i <= maxAttempts; i++)
        {
            try
            {
                if (i % 10 == 0)
                {
                    Trace.WriteLine($"Waiting for Test Site at {TestAppHttpUrl}. Attempt {i} out of {maxAttempts}...",
                        ProcessName.TEST_SETUP);
                }

                HttpResponseMessage response =
                    await httpClient.GetAsync(TestAppHttpUrl, cts.Token);

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

            if (testProcess is null && _testProcessId is not null)
            {
                testProcess = Process.GetProcessById(_testProcessId.Value);
            }

            if (testProcess is not null && testProcess.HasExited)
            {
                int exitCode = testProcess.ExitCode;
                _causeOfFailure = $"TEST RUNNER PROCESS EXITED WITH CODE {exitCode}";

                throw new ProcessExitedException($"Test process exited with code {exitCode}");
            }

            await Task.Delay(1000, cts.Token);
        }

        _causeOfFailure = "TEST SITE NOT READY";

        throw new ProcessExitedException("Test page was not reachable within the allotted time frame", lastException);
    }

    private static async Task KillProcessById(int? processId)
    {
        if (processId.HasValue)
        {
            Process? process = null;

            try
            {
                Trace.WriteLine($"Sending 'exit' to process {processId}...", ProcessName.TEST_CLEANUP);
                process = Process.GetProcessById(processId.Value);

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

            if (process is not null && !process.HasExited)
            {
                Trace.WriteLine($"Killing process {processId}...", ProcessName.TEST_CLEANUP);
                process.Kill();
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
                    .WithArguments($"lsof -i:{_httpsPort} | awk '{{if(NR>1)print $2}}' | xargs -t -r kill -9")
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
        string reportDir = Path.Combine(_projectFolder, "coverage-report");
        string historyDir = Path.Combine(_projectFolder, "history");

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
                $"-reports:{CoverageFilePath};{CoreUnitCoverageFilePath};{ProUnitCoverageFilePath};{
                    CoreSourceGenCoverageFilePath}",
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
        ShouldHandle = new PredicateBuilder().Handle<IOException>(),
        OnRetry = context =>
        {
            Trace.WriteLine($"Attempt #{context.AttemptNumber + 1} for task failed. Retrying...",
                context.Context.OperationKey);

            return ValueTask.CompletedTask;
        }
    };
    private static readonly ResiliencePipeline appRetryPipeline = new ResiliencePipelineBuilder()
        .AddRetry(appRetryStrategyOptions)
        .Build();

    private static readonly CancellationTokenSource cts = new();
    private static readonly CancellationTokenSource gracefulCts = new();
    private static readonly Dictionary<string, Dictionary<DateTime, string>> logBuilders = [];
    private static readonly Type[] testClasses = typeof(GeoBlazorTestClass).Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(typeof(GeoBlazorTestClass)))
        .ToArray();
    private static string? _causeOfFailure;

    private static IConfiguration? _configuration;
    private static string? _runConfig;
    private static string? _targetFramework;
    private static bool _proAvailable;
    private static int _httpsPort;
    private static int _httpPort;
    private static string _projectFolder = string.Empty;
    private static int? _testProcessId;
    private static bool _useContainer;
    private static bool _cover;
    private static bool _showDialog;
    private static bool _cleanupComplete;
    private static string _coverageFormat = string.Empty;
    private static string _coverageFileVersion = string.Empty;
    private static string? _reportGenLicenseKey;
    private static string? _filter;
    private static List<string> _filteredTests = [];
    private static Regex _logLineRegex = new(
        @"^(?<timestamp>\[\d+:\d+:\d+\])\s*(?<processName>[A-Za-z_]+):\s*(?<content>[\s\S]*)",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

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

internal static class ProcessName
{
    public static string[] OrderedList =
    {
        TEST_SETUP, PRE_BUILD, CODE_COVERAGE_TOOL_INSTALLATION, TEST_APP, TEST_CONTAINER, WEB_TEST, CORE_UNIT_TESTS,
        CORE_SGEN_TESTS, PRO_UNIT_TESTS, CODE_COVERAGE, CODE_COVERAGE_REPORT, TEST_CLEANUP, TEST_SHUTDOWN,
        FINAL_SUMMARY
    };
    public const string TEST_SETUP = "TEST_SETUP";
    public const string PRE_BUILD = "PRE_BUILD";
    public const string CODE_COVERAGE_TOOL_INSTALLATION = "CODE_COVERAGE_TOOL_INSTALLATION";
    public const string TEST_APP = "TEST_APP";
    public const string TEST_CONTAINER = "TEST_CONTAINER";
    public const string WEB_TEST = "WEB_TEST";
    public const string CORE_UNIT_TESTS = "CORE_UNIT_TESTS";
    public const string CORE_SGEN_TESTS = "CORE_SGEN_TESTS";
    public const string PRO_UNIT_TESTS = "PRO_UNIT_TESTS";
    public const string CODE_COVERAGE = "CODE_COVERAGE";
    public const string CODE_COVERAGE_REPORT = "CODE_COVERAGE_REPORT";
    public const string TEST_CLEANUP = "TEST_CLEANUP";
    public const string TEST_SHUTDOWN = "TEST_SHUTDOWN";
    public const string FINAL_SUMMARY = "FINAL_SUMMARY";
    public const string PRE_BUILD_ERROR = "PRE_BUILD_ERROR";
    public const string CODE_COVERAGE_TOOL_INSTALLATION_ERROR = "CODE_COVERAGE_TOOL_INSTALLATION_ERROR";
    public const string TEST_APP_ERROR = "TEST_APP_ERROR";
    public const string TEST_CONTAINER_ERROR = "TEST_CONTAINER_ERROR";
    public const string WEB_TEST_ERROR = "WEB_TEST_ERROR";
    public const string CODE_COVERAGE_ERROR = "CODE_COVERAGE_ERROR";
    public const string CODE_COVERAGE_REPORT_ERROR = "CODE_COVERAGE_REPORT_ERROR";
}