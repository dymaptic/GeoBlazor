#!/usr/bin/env dotnet

// GBTest.cs - GeoBlazor Test Runner
// Runs the GeoBlazor Core automation test project via `dotnet run`.
// Supports configuration, test filtering, code coverage, and container execution.
//
// Usage: dotnet ./build-scripts/GBTest.cs [options]
//
// Options:
//   -h, --help             Show this help message and exit
//   -c, --configuration    Build configuration (default: Release)
//   -f, --filter           Test filter expression passed to dotnet test
//   -p, --percentage       Percentage of tests that must pass to be counted as successful (default 90%)
//       --cover            Enable code coverage collection (sets COVER=true)
//       --container        Run tests in a container (sets USE_CONTAINER=true)

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

// Default option values
bool cover = false;
bool container = false;
string config = "Release";
string? filter = null;
int percentage = 90;

// Parse command-line arguments
for (int i = 0; i < args.Length; i++)
{
    switch (args[i].ToLowerInvariant())
    {
        case "-h":
        case "--help":
            Console.WriteLine("""
                GBTest - GeoBlazor Test Runner

                Usage: dotnet ./build-scripts/GBTest.cs [options]

                Options:
                  -h, --help             Show this help message and exit
                  -c, --configuration    Build configuration (default: Release)
                  -f, --filter           Test filter expression passed to dotnet test
                  -p, --percentage       Percentage of tests that must pass to be counted as successful (default 90%)
                      --cover            Enable code coverage collection (sets COVER=true)
                      --container        Run tests in a container (sets USE_CONTAINER=true)

                Examples:
                  dotnet ./build-scripts/GBTest.cs
                  dotnet ./build-scripts/GBTest.cs -c Debug
                  dotnet ./build-scripts/GBTest.cs --filter "FullyQualifiedName~MapView"
                  dotnet ./build-scripts/GBTest.cs --cover --container
                """);
            return 0;
        case "--cover":
            cover = true;
            break;
		case "--container":
			container = true;
			break;
        case "-c":
        case "--configuration":
            if (i + 1 < args.Length)
            {
                config = args[++i];
            }
            break;
        case "-f":
        case "--filter":
            if (i + 1 < args.Length)
            {
                filter = args[++i];
            }
            break;
        case "-p":
        case "--percentage":
            if (i + 1 < args.Length && int.TryParse(args[++i], out int p))
            {
                percentage = p;
            }
            break;
    }
}

// Resolve paths relative to this script's location
string scriptsDir = GetScriptsDirectory();

string testProjectDir = Path.GetFullPath(
    Path.Combine(scriptsDir, "..", "test", "dymaptic.GeoBlazor.Core.Test.Automation"));

string testProjectFilePath = Path.Combine(testProjectDir, "dymaptic.GeoBlazor.Core.Test.Automation.csproj");

// Build the argument list for `dotnet run`
List<string> buildArgs =
[
    "--project", testProjectFilePath,
    "-c", config,
    "--ignore-exit-code", "2"
];

if (filter != null)
{
    buildArgs = [..buildArgs, "--filter", filter];
}

// Set environment variables to toggle optional features
Dictionary<string, string>? environmentVariables = [];

if (cover)
{
    environmentVariables["COVER"] = "true";
}

if (container)
{
	environmentVariables["USE_CONTAINER"] = "true";
}

// Execute the test project
await RunDotnetCommandWithOutputAsync(testProjectDir, "run", buildArgs, environmentVariables);

// Read the test output log
string testOutputLogPath = Path.Combine(testProjectDir, "test-run.log");

Regex finalCountRegex = new(@"^.*FINAL_SUMMARY: (?<passed>\d+) / (?<total>\d+) tests passed.\s*$");

bool failed = false;
foreach (string line in await File.ReadAllLinesAsync(testOutputLogPath))
{
    if (line.Contains("FINAL_SUMMARY"))
    {
        Console.WriteLine(line);
        if (finalCountRegex.Match(line) is { } match)
        {
            int total = int.Parse(match.Groups["total"].Value);
            int passed = int.Parse(match.Groups["passed"].Value);
            double passedPercentage = (double)passed / total * 100;
            Console.WriteLine($"Test results: {passed} / {total} tests passed ({passedPercentage:F2}%).");
            if (passedPercentage < percentage)
            {
                Console.WriteLine($"Test failure: Passed percentage {passedPercentage:F2}% is below the required {percentage}%.");
                failed = true;
            }
        }
    }
}

if (failed)
{
    return 1;
}

return 0;


/// <summary>
/// Runs a dotnet command and captures both stdout and stderr output.
/// Output is written to the console in real-time.
/// Handles Ctrl+C by forwarding the kill signal to the child process.
/// </summary>
/// <param name="workingDirectory">The working directory for the command.</param>
/// <param name="command">The dotnet command (e.g., "build", "restore").</param>
/// <param name="args">The arguments to pass to the command.</param>
/// <param name="environmentVariables">Optional environment variables to set for the process.</param>
/// <returns>The exit code of the process.</returns>
static async Task<int> RunDotnetCommandWithOutputAsync(string workingDirectory,
    string command, IEnumerable<string> args, Dictionary<string, string>? environmentVariables)
{
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"{command} {string.Join(" ", args.Where(a => !string.IsNullOrWhiteSpace(a)))}",
        WorkingDirectory = workingDirectory,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    if (environmentVariables != null)
    {
        foreach (var kvp in environmentVariables)
        {
            psi.Environment[kvp.Key] = kvp.Value;
        }
    }

    using var process = Process.Start(psi);
    if (process == null)
    {
        return 1;
    }

    // Handle Ctrl+C by killing the child process
    Console.CancelKeyPress += (_, e) =>
    {
        e.Cancel = true; // Prevent immediate termination of this script
        if (!process.HasExited)
        {
            try
            {
                process.Kill(entireProcessTree: true);
            }
            catch
            {
                // Process may have already exited
            }
        }
    };

    process.OutputDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync();

    return process.ExitCode;
}

/// <summary>
/// Gets the directory containing the build scripts.
/// When running as a .cs file, uses [CallerFilePath]. When running as a compiled DLL,
/// calculates the path relative to the DLL location.
/// </summary>
/// <param name="callerFilePath">Automatically populated with the source file path at compile time.</param>
/// <returns>The absolute path to the build-scripts directory.</returns>
static string GetScriptsDirectory([CallerFilePath] string? callerFilePath = null)
{
    // When running as a pre-compiled DLL, [CallerFilePath] contains the compile-time path
    // which is invalid at runtime (especially in Docker containers).
    // Detect this by checking if the file exists at the caller path.
    if (!string.IsNullOrEmpty(callerFilePath) && File.Exists(callerFilePath))
    {
        return Path.GetDirectoryName(callerFilePath)!;
    }

    // Running as a DLL - use AppContext.BaseDirectory which points to the DLL location
    // The DLL is in build-tools/, and scripts are in build-scripts/ (sibling directory)
    string dllDirectory = AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    string parent = Path.GetDirectoryName(dllDirectory)!;
    while (Path.GetFileName(parent) != "GeoBlazor")
    {
        parent = Path.GetDirectoryName(parent)!;
    }
    return Path.Combine(parent!, "build-scripts");
}