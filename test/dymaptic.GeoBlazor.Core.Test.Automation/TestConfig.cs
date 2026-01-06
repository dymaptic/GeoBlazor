using CliWrap;
using CliWrap.EventStream;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.Versioning;
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

    private static string ComposeFilePath => Path.Combine(_projectFolder,
        _proAvailable && !CoreOnly ? "docker-compose-pro.yml" : "docker-compose-core.yml");
    private static string TestAppPath => _proAvailable
        ? Path.Combine(_projectFolder, "..", "..", "..", "test", "dymaptic.GeoBlazor.Pro.Test.WebApp",
            "dymaptic.GeoBlazor.Pro.Test.WebApp", "dymaptic.GeoBlazor.Pro.Test.WebApp.csproj")
        : Path.Combine(_projectFolder, "..", "dymaptic.GeoBlazor.Core.Test.WebApp",
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

        string targetFramework = Assembly.GetAssembly(typeof(object))!
            .GetCustomAttribute<TargetFrameworkAttribute>()!
            .FrameworkDisplayName!
            .Replace(" ", "")
            .TrimStart('.')
            .ToLowerInvariant();
        
        _outputFolder = Path.Combine(_projectFolder, "bin", "Release", targetFramework);

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

    private static async Task EnsurePlaywrightBrowsersAreInstalled()
    {
        CommandResult result = await Cli.Wrap("pwsh")
            .WithArguments("playwright.ps1 install")
            .WithWorkingDirectory(_outputFolder)
            .ExecuteAsync();
        
        Assert.IsTrue(result.IsSuccess);
    }

    private static async Task StartContainer()
    {
        string args = $"compose -f \"{ComposeFilePath}\" up -d --build";
        Trace.WriteLine($"Starting container with: docker {args}", "TEST_SETUP");
        Trace.WriteLine($"Working directory: {_projectFolder}", "TEST_SETUP");
        StringBuilder output = new();
        StringBuilder error = new();
        int? exitCode = null;
        
        Command command = Cli.Wrap("docker")
            .WithArguments(args)
            .WithEnvironmentVariables(new Dictionary<string, string?>
            {
                ["HTTP_PORT"] = _httpPort.ToString(),
                ["HTTPS_PORT"] = _httpsPort.ToString()
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
        string args = $"run --project \"{TestAppPath}\" --urls \"{TestAppUrl};{TestAppHttpUrl}\" -- -c Release /p:GenerateXmlComments=false /p:GeneratePackage=false";
        Trace.WriteLine($"Starting test app: dotnet {args}", "TEST_SETUP");
        StringBuilder output = new();
        StringBuilder error = new();
        int? exitCode = null;
        Command command = Cli.Wrap("dotnet")
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
            catch
            {
                // ignore, these just clutter the output
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
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync(cts.Token);
            Trace.WriteLine("Container stopped successfully", "TEST_CLEANUP");
        }
        catch
        {
            // ignore, these just clutter the output
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

    private static readonly CancellationTokenSource cts = new();

    private static IConfiguration? _configuration;
    private static bool _proAvailable;
    private static int _httpsPort;
    private static int _httpPort;
    private static string _projectFolder = string.Empty;
    private static string _outputFolder = string.Empty;
    private static int? _testProcessId;
    private static bool _useContainer;
}