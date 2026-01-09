using CliWrap;
using CliWrap.EventStream;
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
    ///     Default: 2 for CI environments, 4 for local development.
    /// </summary>
    public static int BrowserPoolSize { get; private set; } = 2;

    private static string ComposeFilePath => Path.Combine(_projectFolder,
        _proAvailable && !CoreOnly ? "docker-compose-pro.yml" : "docker-compose-core.yml");
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
    private static string CoverageSessionFilePath => Path.Combine(_projectFolder, "CoverageSessionId.txt");

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new StringBuilderTraceListener(_logBuilder));
        Trace.AutoFlush = true;

        // kill old running test apps and containers
        await StopContainer();
        await StopTestApp();

        SetupConfiguration();

        if (File.Exists(CoverageSessionFilePath))
        {
            var oldSessionId = await File.ReadAllTextAsync(CoverageSessionFilePath);
            await EndCodeCoverageSession(oldSessionId);
        }

        if (_cover)
        {
            await StartCodeCoverage();
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

        if (_useContainer)
        {
            await StopContainer();
        }
        else
        {
            await StopTestApp();
        }

        await EndCodeCoverageSession(codeCoverageSessionId);
        await KillProcessById(_coverageProcessId);
        KillProcessByName("dotnet-coverage");
        await cts.CancelAsync();

        await File.WriteAllTextAsync(Path.Combine(_projectFolder, "test.txt"),
            _logBuilder.ToString());
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
            // get test project folder
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

        var renderMode = _configuration.GetValue("RENDER_MODE", nameof(BlazorMode.WebAssembly));

        if (Enum.TryParse<BlazorMode>(renderMode, true, out var blazorMode))
        {
            RenderMode = blazorMode;
        }

        if (_proAvailable)
        {
            CoreOnly = _configuration.GetValue("CORE_ONLY", false);
            ProOnly = _configuration.GetValue("PRO_ONLY", false);
        }
        else
        {
            CoreOnly = true;
            ProOnly = false;
        }

        _useContainer = _configuration.GetValue("USE_CONTAINER", false);

        // Configure browser pool size - smaller for CI, larger for local development
        var isCI = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
        var defaultPoolSize = isCI ? 2 : 4;
        BrowserPoolSize = _configuration.GetValue("BROWSER_POOL_SIZE", defaultPoolSize);
        Trace.WriteLine($"Browser pool size set to: {BrowserPoolSize} (CI: {isCI})", "TEST_SETUP");
        _cover = _configuration.GetValue("COVER", false);
        _coverageFormat = _configuration.GetValue("COVERAGE_FORMAT", "xml");

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

        if (_cover)
        {
            var testOutputPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(TestAppPath)!,
                "bin", _runConfig, _targetFramework));
            _coreProjectDllPath = Path.Combine(testOutputPath, "dymaptic.GeoBlazor.Core.dll");
            _proProjectDllPath = Path.Combine(testOutputPath, "dymaptic.GeoBlazor.Pro.dll");
        }
    }

    private static async Task StartCodeCoverage()
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
                Trace.WriteLine(output, "CODE_COVERAGE_TOOL_INSTALLATION_ERROR: TOOL INSTALLATION")))
            .ExecuteAsync();

        // Instrument Core Assembly
        await Cli.Wrap("dotnet-coverage")
            .WithArguments([
                "instrument",
                "--session-id",
                codeCoverageSessionId,
                _coreProjectDllPath
            ])
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, "CODE_COVERAGE_INSTRUMENTATION")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, "CODE_COVERAGE_INSTRUMENTATION_ERROR")))
            .ExecuteAsync();

        // Instrument Pro Assembly
        await Cli.Wrap("dotnet-coverage")
            .WithArguments([
                "instrument",
                "--session-id",
                codeCoverageSessionId,
                _proProjectDllPath
            ])
            .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, "CODE_COVERAGE_INSTRUMENTATION")))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                Trace.WriteLine(output, "CODE_COVERAGE_INSTRUMENTATION_ERROR")))
            .ExecuteAsync();

        await File.WriteAllTextAsync(CoverageSessionFilePath, codeCoverageSessionId);

        // Start Coverage Collection Server
        var command = Cli.Wrap("dotnet-coverage")
            .WithArguments([
                "collect",
                "-o",
                Path.Combine(_projectFolder, "coverage"),
                "--session-id",
                codeCoverageSessionId,
                "--server-mode",
                "-f",
                _coverageFormat,
                "-o",
                $"coverage.{_coverageFormat}"
            ]);

        var exitCode = -1;

        _ = Task.Run(async () =>
        {
            await foreach (var cmdEvent in command.ListenAsync())
            {
                switch (cmdEvent)
                {
                    case StartedCommandEvent started:
                        Trace.WriteLine($"Process started; ID: {started.ProcessId}", "CODE_COVERAGE_SERVER");
                        _coverageProcessId = started.ProcessId;

                        break;
                    case StandardOutputCommandEvent stdOut:
                        Trace.WriteLine($"Out> {stdOut.Text}", "CODE_COVERAGE_SERVER");

                        break;
                    case StandardErrorCommandEvent stdErr:
                        Trace.WriteLine($"Err> {stdErr.Text}", "CODE_COVERAGE_SERVER_ERROR");

                        break;
                    case ExitedCommandEvent exited:
                        exitCode = exited.ExitCode;
                        Trace.WriteLine($"Process exited; Code: {exited.ExitCode}", "CODE_COVERAGE_SERVER");

                        break;
                }
            }

            if (exitCode != 0)
            {
                throw new Exception($"Code Coverage Server failed with exit code {exitCode}");
            }
        });
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
        var args = $"compose -f \"{ComposeFilePath}\" up -d --build";
        Trace.WriteLine($"Starting container with: docker {args}", "TEST_SETUP");
        Trace.WriteLine($"Working directory: {_projectFolder}", "TEST_SETUP");
        StringBuilder output = new();
        StringBuilder error = new();
        int? exitCode = null;

        var command = Cli.Wrap("docker")
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["HTTP_PORT"] = _httpPort.ToString(), ["HTTPS_PORT"] = _httpsPort.ToString()
            })
            .WithWorkingDirectory(_projectFolder);

        await foreach (var cmdEvent in command.ListenAsync())
        {
            switch (cmdEvent)
            {
                case StartedCommandEvent started:
                    output.AppendLine($"Process started; ID: {started.ProcessId}");
                    _testProcessId = started.ProcessId;

                    break;
                case StandardOutputCommandEvent stdOut:
                    output.AppendLine($"Out> {stdOut.Text}");

                    break;
                case StandardErrorCommandEvent stdErr:
                    error.AppendLine($"Err> {stdErr.Text}");

                    break;
                case ExitedCommandEvent exited:
                    exitCode = exited.ExitCode;
                    output.AppendLine($"Process exited; Code: {exited.ExitCode}");

                    break;
            }
        }

        Trace.WriteLine($"Docker output: {output}", "TEST_SETUP");

        if (exitCode != 0)
        {
            throw new Exception($"Docker compose failed with exit code {exitCode}. Error: {error}");
        }

        Trace.WriteLine($"Docker error output: {error}", "TEST_SETUP");

        await WaitForHttpResponse();
    }

    private static async Task StartTestApp()
    {
        var args = $"run --project \"{TestAppPath}\" --urls \"{TestAppUrl};{TestAppHttpUrl
        }\" -- -c Release /p:GenerateXmlComments=false /p:GeneratePackage=false";
        Trace.WriteLine($"Starting test app: dotnet {args}", "TEST_SETUP");
        StringBuilder output = new();
        StringBuilder error = new();
        int? exitCode = null;

        var command = Cli.Wrap("dotnet")
            .WithArguments(args)
            .WithWorkingDirectory(_projectFolder);

        _ = Task.Run(async () =>
        {
            await foreach (var cmdEvent in command.ListenAsync())
            {
                switch (cmdEvent)
                {
                    case StartedCommandEvent started:
                        output.AppendLine($"Process started; ID: {started.ProcessId}");
                        _testProcessId = started.ProcessId;

                        break;
                    case StandardOutputCommandEvent stdOut:
                        output.AppendLine($"Out> {stdOut.Text}");

                        break;
                    case StandardErrorCommandEvent stdErr:
                        error.AppendLine($"Err> {stdErr.Text}");

                        break;
                    case ExitedCommandEvent exited:
                        exitCode = exited.ExitCode;
                        output.AppendLine($"Process exited; Code: {exited.ExitCode}");

                        break;
                }
            }

            Trace.WriteLine($"Test App output: {output}", "TEST_SETUP");

            if (exitCode != 0)
            {
                throw new Exception($"Test app failed with exit code {exitCode}. Error: {error}");
            }

            Trace.WriteLine($"Test app error output: {error}", "TEST_SETUP");
        });

        await WaitForHttpResponse();
    }

    private static async Task StopTestApp()
    {
        await KillProcessById(_testProcessId);

        await KillProcessesByTestPorts();
    }

    private static async Task StopContainer()
    {
        try
        {
            Trace.WriteLine($"Stopping container with: docker compose -f {ComposeFilePath} down", "TEST_CLEANUP");

            await Cli.Wrap("docker")
                .WithArguments($"compose -f \"{ComposeFilePath}\" down")
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync(cts.Token);
            Trace.WriteLine("Container stopped successfully", "TEST_CLEANUP");
        }
        catch
        {
            // ignore, these just clutter the output
        }

        await KillProcessesByTestPorts();
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

        for (var i = 1; i <= maxAttempts; i++)
        {
            try
            {
                var response =
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

    private static void KillProcessByName(string processName)
    {
        Process.GetProcessesByName(processName)
            .ToList()
            .ForEach(p => p.Kill());
    }

    private static async Task EndCodeCoverageSession(string sessionId)
    {
        try
        {
            await Cli.Wrap("dotnet-coverage")
                .WithArguments([
                    "shutdown",
                    sessionId
                ])
                .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                    Trace.WriteLine(output, "CODE_COVERAGE: SHUTDOWN")))
                .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                    Trace.WriteLine(output, "CODE_COVERAGE_ERROR: SHUTDOWN")))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();
        }
        catch
        {
            // ignore, these just clutter the test output
        }

        try
        {
            await Cli.Wrap("dotnet-coverage")
                .WithArguments([
                    "uninstrument",
                    _coreProjectDllPath
                ])
                .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                    Trace.WriteLine(output, "CODE_COVERAGE: UN-INSTRUMENTATION")))
                .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                    Trace.WriteLine(output, "CODE_COVERAGE_ERROR: UN-INSTRUMENTATION")))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();
        }
        catch
        {
            // ignore, these just clutter the test output
        }

        try
        {
            await Cli.Wrap("dotnet-coverage")
                .WithArguments([
                    "uninstrument",
                    _proProjectDllPath
                ])
                .WithStandardOutputPipe(PipeTarget.ToDelegate(output =>
                    Trace.WriteLine(output, "CODE_COVERAGE: UN-INSTRUMENTATION")))
                .WithStandardErrorPipe(PipeTarget.ToDelegate(output =>
                    Trace.WriteLine(output, "CODE_COVERAGE_ERROR: UN-INSTRUMENTATION")))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();
        }
        catch
        {
            // ignore, these just clutter the test output
        }
    }

    private static readonly CancellationTokenSource cts = new();
    private static readonly string codeCoverageSessionId = Guid.NewGuid().ToString();
    private static readonly StringBuilder _logBuilder = new();

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
    private static int? _coverageProcessId;
    private static string _coverageFormat = string.Empty;
    private static string _coreProjectDllPath = string.Empty;
    private static string _proProjectDllPath = string.Empty;
}