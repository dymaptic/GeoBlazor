using CliWrap;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;


[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]


namespace dymaptic.GeoBlazor.Core.Test.Automation;

[TestClass]
public class TestConfig
{
    public static string TestAppUrl { get; private set; } = "";
    public static BlazorMode RenderMode { get; private set; }
    public static bool CoreOnly { get; private set; }
    public static bool ProOnly { get; private set; }

    private static string ComposeFilePath => Path.Combine(_projectFolder!,
        _proAvailable && !CoreOnly ? "docker-compose-pro.yml" : "docker-compose.core.yml");
    private static string TestAppPath => _proAvailable
        ? Path.Combine(_projectFolder!, "..", "..", "..", "test", "dymaptic.GeoBlazor.Pro.Test.WebApp",
            "dymaptic.GeoBlazor.Pro.Test.WebApp", "dymaptic.GeoBlazor.Pro.Test.WebApp.csproj")
        : Path.Combine(_projectFolder!, "..", "dymaptic.GeoBlazor.Core.Test.WebApp",
            "dymaptic.GeoBlazor.Core.Test.WebApp.csproj");
    private static string TestAppHttpUrl => $"http://localhost:{_httpPort}";

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.AutoFlush = true;
        
        // kill old running test apps and containers
        await StopContainer();
        await StopTestApp();
        
        SetupConfiguration();

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
        if (_useContainer)
        {
            await StopContainer();
        }
        else
        {
            await StopTestApp();
        }
        await cts.CancelAsync();
    }

    private static void SetupConfiguration()
    {
        _projectFolder = Assembly.GetAssembly(typeof(TestConfig))!.Location;

        while (_projectFolder.Contains("bin"))
        {
            // get test project folder
            _projectFolder = Path.GetDirectoryName(_projectFolder)!;
        }

        // assemblyLocation = GeoBlazor.Pro/GeoBlazor/test/dymaptic.GeoBlazor.Core.Test.Automation
        // this pulls us up to GeoBlazor.Pro then finds the Dockerfile
        var proDockerPath = Path.Combine(_projectFolder, "..", "..", "..", "Dockerfile");
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
    }

    private static async Task StartContainer()
    {
        ProcessStartInfo startInfo = new("docker",
            $"compose -f \"{ComposeFilePath}\" up -d --build")
        {
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            WorkingDirectory = _projectFolder!
        };

        Trace.WriteLine($"Starting container with: docker {startInfo.Arguments}", "TEST_SETUP");
        Trace.WriteLine($"Working directory: {_projectFolder}", "TEST_SETUP");

        var process = Process.Start(startInfo);
        Assert.IsNotNull(process);
        _testProcessId = process.Id;

        // Capture output asynchronously to prevent deadlocks
        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();

        await process.WaitForExitAsync();

        var output = await outputTask;
        var error = await errorTask;

        if (!string.IsNullOrWhiteSpace(output))
        {
            Trace.WriteLine($"Docker output: {output}", "TEST_SETUP");
        }

        if (!string.IsNullOrWhiteSpace(error))
        {
            Trace.WriteLine($"Docker error: {error}", "TEST_SETUP");
        }

        if (process.ExitCode != 0)
        {
            throw new Exception($"Docker compose failed with exit code {process.ExitCode}. Error: {error}");
        }

        await WaitForHttpResponse();
    }

    private static async Task StartTestApp()
    {
        ProcessStartInfo startInfo = new("dotnet",
            $"run --project \"{TestAppPath}\" --urls \"{TestAppUrl};{TestAppHttpUrl}\" -- -c Release /p:GenerateXmlComments=false /p:GeneratePackage=false")
        {
            CreateNoWindow = true,
            UseShellExecute = false,
            WorkingDirectory = _projectFolder!
        };

        Trace.WriteLine($"Starting test app: dotnet {startInfo.Arguments}", "TEST_SETUP");

        var process = Process.Start(startInfo);
        Assert.IsNotNull(process);
        _testProcessId = process.Id;

        await WaitForHttpResponse();
    }

    private static async Task StopTestApp()
    {
        if (_testProcessId.HasValue)
        {
            Process? process = null;

            try
            {
                process = Process.GetProcessById(_testProcessId.Value);

                if (_useContainer)
                {
                    await process.StandardInput.WriteLineAsync("exit");
                    await Task.Delay(5000);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                    "ERROR_TEST_APP");
            }

            if (process is not null && !process.HasExited)
            {
                process.Kill();
            }

            await KillOrphanedTestRuns();
        }
    }
    
    private static async Task StopContainer()
    {
        try
        {
            Trace.WriteLine($"Stopping container with: docker compose -f {ComposeFilePath} down", "TEST_CLEANUP");
            await Cli.Wrap("docker")
                .WithArguments($"compose -f \"{ComposeFilePath}\" down")
                .ExecuteAsync(cts.Token);
            Trace.WriteLine("Container stopped successfully", "TEST_CLEANUP");
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                _useContainer ? "ERROR_CONTAINER" : "ERROR_TEST_APP");
        }

        await KillOrphanedTestRuns();
    }

    private static async Task WaitForHttpResponse()
    {
        // Configure HttpClient to ignore SSL certificate errors (for self-signed certs in Docker)
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
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

                if (response.IsSuccessStatusCode || response.StatusCode is >= (HttpStatusCode)300 and < (HttpStatusCode)400)
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
                Trace.WriteLine($"Waiting for Test Site at {TestAppHttpUrl}. Attempt {i} out of {maxAttempts}...", "TEST_SETUP");
            }

            await Task.Delay(1000, cts.Token);
        }

        throw new ProcessExitedException("Test page was not reachable within the allotted time frame");
    }

    private static async Task KillOrphanedTestRuns()
    {
        try
        {
            if (OperatingSystem.IsWindows())
            {
                // Use PowerShell for more reliable Windows port killing
                await Cli.Wrap("pwsh")
                    .WithArguments($"Get-NetTCPConnection -LocalPort {_httpsPort} -State Listen | Select-Object -ExpandProperty OwningProcess | ForEach-Object {{ Stop-Process -Id $_ -Force }}")
                    .ExecuteAsync();
            }
            else
            {
                await Cli.Wrap("/bin/bash")
                    .WithArguments($"lsof -i:{_httpsPort} | awk '{{if(NR>1)print $2}}' | xargs -t -r kill -9")
                    .ExecuteAsync();
            }
        }
        catch (Exception ex)
        {
            // Log the exception but don't throw - it's common for no processes to be running on the port
            Trace.WriteLine($"Warning: Could not kill processes on port {_httpsPort}: {ex.Message}",
                "ERROR-TEST_CLEANUP");
        }
    }

    private static readonly CancellationTokenSource cts = new();

    private static IConfiguration? _configuration;
    private static bool _proAvailable;
    private static int _httpsPort;
    private static int _httpPort;
    private static string _projectFolder = string.Empty;
    private static int? _testProcessId;
    private static bool _useContainer;
}