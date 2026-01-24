using CliWrap;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Net;


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
    private static string UnitCoverageFilePath =>
        Path.Combine(UnitCoverageFolderPath, $"coverage.{_coverageFileVersion}.{_coverageFormat}");
    private static string SgenCoverageFolderPath => Path.Combine(_projectFolder, "sgen-coverage");
    private static string SgenCoverageFilePath =>
        Path.Combine(SgenCoverageFolderPath, $"coverage.{_coverageFileVersion}.{_coverageFormat}");
    private static string CoreRepoRoot => Path.GetFullPath(Path.Combine(_projectFolder, "..", ".."));
    private static string ProRepoRoot => Path.GetFullPath(Path.Combine(_projectFolder, "..", "..", ".."));
    private static string CoreProjectPath =>
        Path.GetFullPath(Path.Combine(CoreRepoRoot, "src", "dymaptic.GeoBlazor.Core"));
    private static string ProProjectPath =>
        Path.GetFullPath(Path.Combine(ProRepoRoot, "src", "dymaptic.GeoBlazor.Pro"));
    private static string LogFilePath => Path.Combine(_projectFolder, "test-run.log");

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new StringBuilderTraceListener(logBuilder));
        Trace.AutoFlush = true;

        // Handle Ctrl-C gracefully
        Console.CancelKeyPress += (sender, e) =>
        {
            Trace.WriteLine("Ctrl-C detected, initiating shutdown...", "TEST_SHUTDOWN");
            e.Cancel = true; // Prevent immediate termination to allow cleanup

            // Trigger cancellation
            if (!cts.IsCancellationRequested)
            {
                cts.Cancel();
            }

            if (!gracefulCts.IsCancellationRequested)
            {
                gracefulCts.Cancel();
            }

            // Force exit after timeout if cleanup hangs
            Task.Run(async () =>
            {
                await Task.Delay(15000); // 15 second timeout for cleanup
                Trace.WriteLine("Cleanup timeout - forcing exit", "TEST_SHUTDOWN");
                Environment.Exit(1);
            });
        };

        SetupConfiguration();

        if (!IsCI)
        {
            Utilities.StartConsoleDialog(Path.Combine(CoreRepoRoot, "build-tools"),
                "GeoBlazor Unit Tests");
        }

        // kill old running test apps and containers
        Task[] cleanupTasks =
        [
            StopContainer(CoreComposeFilePath),
            StopContainer(ProComposeFilePath),
            StopTestApp()
        ];

        await Task.WhenAll(cleanupTasks);

        Task[] setupTasks =
        [
            InstallCodeCoverageTools(),
            EnsurePlaywrightBrowsersAreInstalled()
        ];

        await Task.WhenAll(setupTasks);

        Task[] runTasks =
        [
            RunUnitTests(),
            RunSourceGeneratorTests(),
            LaunchWebTests()
        ];

        await Task.WhenAll(runTasks);
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        var isCancelled = cts.IsCancellationRequested;

        // Dispose browser pool first
        if (BrowserPool.TryGetInstance(out var pool) && pool is not null)
        {
            Trace.WriteLine("Disposing browser pool...", "TEST_CLEANUP");

            try
            {
                using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(isCancelled ? 3 : 10));
                await pool.DisposeAsync().ConfigureAwait(false);
                Trace.WriteLine("Browser pool disposed", "TEST_CLEANUP");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Browser pool disposal error: {ex.Message}", "TEST_CLEANUP");
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

        if (_useContainer)
        {
            await StopContainer(ComposeFilePath);

            if (_cover)
            {
                CopyCoverageFromContainer();
            }
        }
        else
        {
            await StopTestApp();
        }

        if (_cover)
        {
            await GenerateCoverageReport();
        }

        Trace.WriteLine("-------------------------------------------------------");
        Trace.WriteLine("Test run complete", "FINAL_SUMMARY");
        int passedTestCount = _filteredTests.Count - FailedTests.Count - InconclusiveTests.Count;
        Trace.WriteLine($"{passedTestCount} / {_filteredTests.Count} tests passed.", "FINAL_SUMMARY");
        Trace.WriteLine("Inconclusive Tests:", "FINAL_SUMMARY");

        foreach (string inconclusive in InconclusiveTests)
        {
            Trace.WriteLine($"- {inconclusive}", "FINAL_SUMMARY");
        }

        Trace.WriteLine("-------------------------------------------------------");
        Trace.WriteLine("Failed Tests:", "FINAL_SUMMARY");

        foreach (KeyValuePair<string, string> failedTest in FailedTests)
        {
            Trace.WriteLine($"- {failedTest.Key}: {Environment.NewLine}{failedTest.Value}",
                "FINAL_SUMMARY");
        }

        await File.WriteAllTextAsync(LogFilePath, logBuilder.ToString());
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
            .AddDotEnvFile(true, true)
            .AddCommandLine(Environment.GetCommandLineArgs())
            .Build();

        _httpsPort = _configuration.GetValue("HTTPS_PORT", 9443);
        _httpPort = _configuration.GetValue("HTTP_PORT", 8080);
        TestAppUrl = _configuration.GetValue("TEST_APP_URL", $"https://localhost:{_httpsPort}");

        // Default to Server Mode for compatibility with Code Coverage Tools
        var renderMode = _configuration.GetValue("RENDER_MODE", nameof(BlazorMode.Server));

        if (Enum.TryParse(renderMode, true, out BlazorMode blazorMode))
        {
            RenderMode = blazorMode;
        }

        ParseFilter();

        _useContainer = _configuration.GetValue("USE_CONTAINER", false);

        // Configure browser pool size - larger pools improve parallelism
        IsCI = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
        var defaultPoolSize = IsCI ? 4 : 8; // Doubled from 2/4 to 4/8 for better parallelization
        BrowserPoolSize = _configuration.GetValue("BROWSER_POOL_SIZE", defaultPoolSize);
        Trace.WriteLine($"Browser pool size set to: {BrowserPoolSize} (CI: {IsCI})", "TEST_SETUP");

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
    }

    private static void ParseFilter()
    {
        string[] envArgs = Environment.GetCommandLineArgs();

        _filter = envArgs.IndexOf("--filter") is var index and > 0
            && envArgs.Length > index + 1
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

    private static async Task RunUnitTests()
    {
        var unitTestPath = Path.Combine(_projectFolder, "..",
            "dymaptic.GeoBlazor.Core.Test.Unit",
            "dymaptic.GeoBlazor.Core.Test.Unit.csproj");
        var cmdLineApp = "dotnet";

        string[] args =
        [
            "test",
            "--project",
            unitTestPath,
            "-c",
            "Release",
            "--output",
            "Detailed"
        ];

        if (!string.IsNullOrEmpty(_filter))
        {
            args = [..args, "--filter", _filter];
        }

        if (_cover)
        {
            Directory.CreateDirectory(UnitCoverageFolderPath);
            cmdLineApp = "dotnet-coverage";
            var dotnetCommand = $"dotnet {string.Join(" ", args)}";

            args =
            [
                "collect",
                "-o", UnitCoverageFilePath,
                "-f", _coverageFormat,
                "--include-files", "**/dymaptic.GeoBlazor.Core.dll",
                "--include-files", "**/dymaptic.GeoBlazor.Pro.dll",
                dotnetCommand
            ];
        }

        var result = await Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output => Trace.WriteLine(output, "UNIT_TEST")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output => Trace.WriteLine(output, "UNIT_TEST_ERROR")))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();

        if (result.ExitCode != 0 && result.ExitCode != 8) // 8 = 0 tests ran
        {
            throw new ProcessExitedException($"Unit test process exited with code {result.ExitCode}");
        }
    }

    private static async Task RunSourceGeneratorTests()
    {
        var sgenFilePath = Path.Combine(_projectFolder, "..",
            "dymaptic.GeoBlazor.Core.SourceGenerator.Tests",
            "dymaptic.GeoBlazor.Core.SourceGenerator.Tests.csproj");
        var cmdLineApp = "dotnet";

        string[] args =
        [
            "test",
            "--project",
            sgenFilePath,
            "-c",
            "Release",
            "--output",
            "Detailed"
        ];

        if (!string.IsNullOrEmpty(_filter))
        {
            args = [..args, "--filter", _filter];
        }

        if (_cover)
        {
            Directory.CreateDirectory(SgenCoverageFolderPath);
            cmdLineApp = "dotnet-coverage";
            var dotnetCommand = $"dotnet {string.Join(" ", args)}";

            args =
            [
                "collect",
                "-o", SgenCoverageFilePath,
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

        var result = await Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output => Trace.WriteLine(output, "SGEN_TEST")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output => Trace.WriteLine(output, "SGEN_TEST_ERROR")))
            .WithValidation(CommandResultValidation.None)
            .ExecuteAsync();

        if (result.ExitCode != 0 && result.ExitCode != 8) // 8 = 0 tests ran
        {
            throw new ProcessExitedException($"Source Generator test process exited with code {result.ExitCode}");
        }
    }

    private static async Task LaunchWebTests()
    {
        if (_useContainer)
        {
            await StartContainer();
        }
        else
        {
            await StartTestApp();
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
                Trace.WriteLine(output, "CODE_COVERAGE_TOOL_INSTALLATION")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, "CODE_COVERAGE_TOOL_INSTALLATION_ERROR")))
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
                Trace.WriteLine(output, "CODE_COVERAGE_TOOL_INSTALLATION")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, "CODE_COVERAGE_TOOL_INSTALLATION_ERROR")))
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
                Trace.WriteLine($"Playwright browser installation returned exit code: {exitCode}", "TEST_SETUP");
            }

            await Task.CompletedTask; // Keep method async for consistency
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Playwright browser installation failed: {ex.Message}", "TEST_SETUP");
        }
    }

    private static async Task StartContainer()
    {
        var cmdLineApp = "docker";

        string[] args =
        [
            "compose", "-f", ComposeFilePath, "up", "-d", "--build"
        ];
        Trace.WriteLine($"Starting container with: docker {string.Join(" ", args)}", "TEST_SETUP");
        Trace.WriteLine($"Working directory: {_projectFolder}", "TEST_SETUP");

        var sessionId = "geoblazor-cover";

        if (_cover)
        {
            cmdLineApp = "dotnet-coverage";
            var dockerCommand = $"docker {string.Join(" ", args)}";

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
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, "TEST_CONTAINER")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, "TEST_CONTAINER_ERROR")))
            .WithWorkingDirectory(_projectFolder)
            .ExecuteAsync(cts.Token, gracefulCts.Token);

        _testProcessId = commandTask.ProcessId;

        await WaitForHttpResponse();
    }

    private static async Task StartTestApp()
    {
        var cmdLineApp = "dotnet";

        string[] args =
        [
            "run", "--project", TestAppPath,
            "--urls", $"{TestAppUrl};{TestAppHttpUrl}",
            "--", "-c", "Release",
            "/p:GenerateXmlComments=false",
            "/p:GeneratePackage=false",
            "/p:GenerateDocs=false",
            "/p:DebugSymbols=true",
            "/p:DebugType=portable",
            "/p:UsePackageReference=false"
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
                dotnetCommand
            ];
        }

        Trace.WriteLine($"Starting test app: {cmdLineApp} {string.Join(" ", args)}", "TEST_SETUP");

        CommandTask<CommandResult> commandTask = Cli.Wrap(cmdLineApp)
            .WithArguments(args)
            .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, "TEST_APP")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, "TEST_APP_ERROR")))
            .WithWorkingDirectory(_projectFolder)
            .ExecuteAsync(cts.Token, gracefulCts.Token);

        _testProcessId = commandTask.ProcessId;

        await WaitForHttpResponse();
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
            Trace.WriteLine($"Stopping container with: docker compose -f {composeFilePath} down", "TEST_CLEANUP");

            await Cli.Wrap("docker")
                .WithArguments($"compose -f \"{composeFilePath}\" down")
                .WithValidation(CommandResultValidation.None)
                .WithStandardOutputPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, "TEST_CONTAINER_CLEANUP")))
                .ExecuteAsync(cts.Token);
        }
        catch
        {
            // ignore, these just clutter the output
        }

        await KillProcessesByTestPorts();
    }

    private static async Task StopTestApp()
    {
        await KillProcessById(_testProcessId);
        await KillProcessesByTestPorts();
    }

    private static async Task ShutdownCoverageCollection()
    {
        try
        {
            // Get the container name from the compose file
            string containerName = _proAvailable && !CoreOnly
                ? "geoblazor-pro-tests-test-app-1"
                : "geoblazor-core-tests-test-app-1";

            Trace.WriteLine($"Shutting down coverage collection in container: {containerName}", "CODE_COVERAGE");

            // Call dotnet-coverage shutdown inside the container to gracefully write coverage data
            await Cli.Wrap("docker")
                .WithArguments($"exec {containerName} /tools/dotnet-coverage shutdown geoblazor-coverage")
                .WithStandardOutputPipe(PipeTarget.ToDelegate(line =>
                    Trace.WriteLine(line, "CODE_COVERAGE_SHUTDOWN")))
                .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
                    Trace.WriteLine(line, "CODE_COVERAGE_SHUTDOWN_ERROR")))
                .ExecuteAsync();

            // Give time for coverage file to be written
            await Task.Delay(3000);
            Trace.WriteLine("Coverage shutdown command completed", "CODE_COVERAGE");
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Failed to shutdown coverage collection: {ex.Message}", "CODE_COVERAGE_ERROR");
        }
    }

    private static void CopyCoverageFromContainer()
    {
        // If coverage was enabled, copy the coverage file from the volume mount directory
        var containerCoverageFile = Path.Combine(_projectFolder, "coverage", "coverage.xml");
        var targetCoverageFile = Path.Combine(_projectFolder, $"coverage.{_coverageFormat}");

        if (File.Exists(containerCoverageFile))
        {
            File.Copy(containerCoverageFile, targetCoverageFile, true);
            Trace.WriteLine($"Coverage file copied from container: {targetCoverageFile}", "TEST_CLEANUP");
        }
        else
        {
            Trace.WriteLine($"Container coverage file not found: {containerCoverageFile}", "TEST_CLEANUP");
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
        var maxAttempts = 60 * 8;

        Exception? lastException = null;

        for (var i = 1; i <= maxAttempts; i++)
        {
            try
            {
                if (i % 10 == 0)
                {
                    Trace.WriteLine($"Waiting for Test Site at {TestAppHttpUrl}. Attempt {i} out of {maxAttempts}...",
                        "TEST_SETUP");
                }

                HttpResponseMessage response =
                    await httpClient.GetAsync(TestAppHttpUrl, cts.Token);

                if (response.IsSuccessStatusCode ||
                    response.StatusCode is >= (HttpStatusCode)300 and < (HttpStatusCode)400)
                {
                    Trace.WriteLine($"Test Site is ready! Status: {response.StatusCode}", "TEST_SETUP");

                    return;
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging SSL/connection issues
                lastException = ex;
            }

            await Task.Delay(1000, cts.Token);
        }

        throw new ProcessExitedException("Test page was not reachable within the allotted time frame", lastException);
    }

    private static async Task KillProcessById(int? processId)
    {
        if (processId.HasValue)
        {
            Process? process = null;

            try
            {
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
                process.Kill();
            }
        }
    }

    private static async Task KillProcessesByTestPorts()
    {
        try
        {
            if (OperatingSystem.IsWindows())
            {
                // Use PowerShell for more reliable Windows port killing
                await Cli.Wrap("pwsh")
                    .WithArguments($"Get-NetTCPConnection -LocalPort {_httpsPort
                    } -State Listen | Select-Object -ExpandProperty OwningProcess | ForEach-Object {{ Stop-Process -Id $_ -Force }}")
                    .WithValidation(CommandResultValidation.None)
                    .ExecuteAsync();
            }
            else
            {
                await Cli.Wrap("/bin/bash")
                    .WithArguments($"lsof -i:{_httpsPort} | awk '{{if(NR>1)print $2}}' | xargs -t -r kill -9")
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
            Trace.WriteLine($"Coverage file not found: {CoverageFilePath}", "CODE_COVERAGE_ERROR");

            return;
        }

        try
        {
            Trace.WriteLine("Generating coverage report...", "CODE_COVERAGE_REPORT");

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
                $"-reports:{CoverageFilePath};{UnitCoverageFilePath};{SgenCoverageFilePath}",
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
                    Trace.WriteLine(line, "CODE_COVERAGE_REPORT")))
                .WithStandardErrorPipe(PipeTarget.ToDelegate(line =>
                    Trace.WriteLine(line, "CODE_COVERAGE_REPORT_ERROR")))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();

            string textSummaryPath = Path.Combine(reportDir, "Summary.txt");
            string webReportPath = Path.Combine(reportDir, "index.html");

            if (File.Exists(textSummaryPath))
            {
                Trace.WriteLine(await File.ReadAllTextAsync(textSummaryPath),
                    "CODE_COVERAGE_SUCCESS");
                Trace.WriteLine($"Full report at [Coverage Report]({webReportPath})", "CODE_COVERAGE_SUCCESS");
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
            Trace.WriteLine($"Failed to generate coverage report: {ex.Message}", "CODE_COVERAGE_ERROR");
        }
    }

    private static readonly CancellationTokenSource cts = new();
    private static readonly CancellationTokenSource gracefulCts = new();
    private static readonly StringBuilder logBuilder = new();
    private static readonly Type[] testClasses = typeof(GeoBlazorTestClass).Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(typeof(GeoBlazorTestClass)))
        .ToArray();

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
    private static string _coverageFormat = string.Empty;
    private static string _coverageFileVersion = string.Empty;
    private static string? _reportGenLicenseKey;
    private static string? _filter;
    private static List<string> _filteredTests = [];

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