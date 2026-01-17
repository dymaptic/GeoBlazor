using CliWrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text;


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
    private static string CoreRepoRoot => Path.GetFullPath(Path.Combine(_projectFolder, "..", ".."));
    private static string ProRepoRoot => Path.GetFullPath(Path.Combine(_projectFolder, "..", "..", ".."));
    private static string CoreProjectPath =>
        Path.GetFullPath(Path.Combine(CoreRepoRoot, "src", "dymaptic.GeoBlazor.Core"));
    private static string ProProjectPath =>
        Path.GetFullPath(Path.Combine(ProRepoRoot, "src", "dymaptic.GeoBlazor.Pro"));

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new StringBuilderTraceListener(logBuilder));
        Trace.AutoFlush = true;

        SetupConfiguration();

        // kill old running test apps and containers
        await StopContainer(CoreComposeFilePath);
        await StopContainer(ProComposeFilePath);
        await StopTestApp();

        if (_cover)
        {
            await InstallCodeCoverageTools();
        }

        await EnsurePlaywrightBrowsersAreInstalled();

        if (_useContainer)
        {
            await StartContainer();
        }
        else
        {
            await StartTestApp();
        }
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        // Dispose browser pool first
        if (BrowserPool.TryGetInstance(out var pool) && pool is not null)
        {
            Trace.WriteLine("Disposing browser pool...", "TEST_CLEANUP");
            await pool.DisposeAsync().ConfigureAwait(false);
            Trace.WriteLine("Browser pool disposed", "TEST_CLEANUP");
        }

        cts.CancelAfter(5000);

        await gracefulCts.CancelAsync();

        await Task.Delay(5000);

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

        await File.WriteAllTextAsync(Path.Combine(_projectFolder, "test-run.log"),
            logBuilder.ToString());
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

        var envArgs = Environment.GetCommandLineArgs();

        if (_proAvailable)
        {
            CoreOnly = _configuration.GetValue("CORE_ONLY", false)
                || (envArgs.Contains("--filter") && (envArgs[envArgs.IndexOf("--filter") + 1] == "CORE_"));

            ProOnly = _configuration.GetValue("PRO_ONLY", false)
                || (envArgs.Contains("--filter") && (envArgs[envArgs.IndexOf("--filter") + 1] == "PRO_"));
        }
        else
        {
            CoreOnly = true;
            ProOnly = false;
        }

        _useContainer = _configuration.GetValue("USE_CONTAINER", false);

        // Configure browser pool size - larger pools improve parallelism
        IsCI = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
        var defaultPoolSize = IsCI ? 4 : 8; // Doubled from 2/4 to 4/8 for better parallelization
        BrowserPoolSize = _configuration.GetValue("BROWSER_POOL_SIZE", defaultPoolSize);
        Trace.WriteLine($"Browser pool size set to: {BrowserPoolSize} (CI: {IsCI})", "TEST_SETUP");

        _cover = _configuration.GetValue("COVER", false)

            // only run coverage on a full test run or a full CORE or full PRO test
            && (!envArgs.Contains("--filter") || (envArgs[envArgs.IndexOf("--filter") + 1] == "CORE_")
                || (envArgs[envArgs.IndexOf("--filter") + 1] == "PRO_"));

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

    private static async Task InstallCodeCoverageTools()
    {
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
        var result = await commandTask;

        if (result.ExitCode != 0)
        {
            throw new ProcessExitedException($"Container failed to start: {result.ExitCode}");
        }

        await WaitForHttpResponse();
    }

    private static async Task StartTestApp()
    {
        var cmdLineApp = "dotnet";

        string[] args =
        [
            "run", "--project", $"\"{TestAppPath}\"",
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
                .WithStandardErrorPipe(PipeTarget.ToDelegate(line => Trace.WriteLine(line, "TEST_CONTAINER_ERROR")))
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

        for (var i = 1; i <= maxAttempts; i++)
        {
            try
            {
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
                if (i % 10 == 0)
                {
                    Trace.WriteLine($"Connection attempt {i} failed: {ex.Message}", "TEST_SETUP");
                }
            }

            if (i % 10 == 0)
            {
                Trace.WriteLine($"Waiting for Test Site at {TestAppHttpUrl}. Attempt {i} out of {maxAttempts}...",
                    "TEST_SETUP");
            }

            await Task.Delay(1000, cts.Token);
        }

        throw new ProcessExitedException("Test page was not reachable within the allotted time frame");
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

        if (!File.Exists(CoverageFilePath))
        {
            Trace.WriteLine($"Coverage file not found: {CoverageFilePath}", "CODE_COVERAGE_ERROR");

            return;
        }

        try
        {
            Trace.WriteLine("Generating coverage report...", "CODE_COVERAGE_REPORT");

            List<string> assemblyFilters = CoreOnly
                ? ["+dymaptic.GeoBlazor.Core.dll"]
                : ProOnly
                    ? ["+dymaptic.GeoBlazor.Pro.dll"]
                    : ["+dymaptic.GeoBlazor.Core.dll", "+dymaptic.GeoBlazor.Pro.dll"];

            List<string> sourceDirs = CoreOnly
                ? [CoreProjectPath]
                : ProOnly
                    ? [ProProjectPath]
                    : [CoreProjectPath, ProProjectPath];

            List<string> args =
            [
                $"-reports:{CoverageFilePath}",
                $"-targetdir:{reportDir}",
                "-reporttypes:Html;HtmlSummary;TextSummary;Badges",

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
}