using CliWrap;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Diagnostics;
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
        await KillOrphanedTestRuns();
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
        await StopTestAppOrContainer();
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
            .AddEnvironmentVariables()
            .AddDotEnvFile(true, true)
            .AddJsonFile("appsettings.json", true)
#if DEBUG
            .AddJsonFile("appsettings.Development.json", true)
#else
            .AddJsonFile("appsettings.Production.json", true)
#endif
            .AddUserSecrets<TestConfig>()
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
            CreateNoWindow = false, WorkingDirectory = _projectFolder!
        };

        var process = Process.Start(startInfo);
        Assert.IsNotNull(process);
        _testProcessId = process.Id;

        await WaitForHttpResponse();
    }

    private static async Task StartTestApp()
    {
        ProcessStartInfo startInfo = new("dotnet",
            $"run --project \"{TestAppPath}\" -lp https --urls \"{TestAppUrl};{TestAppHttpUrl}\"")
        {
            CreateNoWindow = false, WorkingDirectory = _projectFolder!
        };
        var process = Process.Start(startInfo);
        Assert.IsNotNull(process);
        _testProcessId = process.Id;

        await WaitForHttpResponse();
    }

    private static async Task StopTestAppOrContainer()
    {
        if (_useContainer)
        {
            try
            {
                await Cli.Wrap("docker")
                    .WithArguments($"compose -f {ComposeFilePath} down")
                    .ExecuteAsync(cts.Token);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                    _useContainer ? "ERROR_CONTAINER" : "ERROR_TEST_APP");
            }
        }

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
                    _useContainer ? "ERROR_CONTAINER" : "ERROR_TEST_APP");
            }

            if (process is not null && !process.HasExited)
            {
                process.Kill();
            }

            await KillOrphanedTestRuns();
        }
    }

    private static async Task WaitForHttpResponse()
    {
        using HttpClient httpClient = new();

        var maxAttempts = 60;

        for (var i = 1; i <= maxAttempts; i++)
        {
            try
            {
                var response =
                    await httpClient.GetAsync(TestAppHttpUrl, cts.Token);

                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine($"Test Site is ready! Status: {response.StatusCode}", "TEST_SETUP");

                    return;
                }
            }
            catch
            {
                // ignore, service not ready
            }

            if (i % 5 == 0)
            {
                Trace.WriteLine($"Waiting for Test Site. Attempt {i} out of {maxAttempts}...", "TEST_SETUP");
            }

            await Task.Delay(2000, cts.Token);
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
                    .WithArguments($"Get-NetTCPConnection -LocalPort {_httpsPort
                    } -State Listen | Select-Object -ExpandProperty OwningProcess | ForEach-Object {{ Stop-Process -Id $_ -Force }}")
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

    private static string? _projectFolder;
    private static int? _testProcessId;
    private static bool _useContainer;
}